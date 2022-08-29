using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicPlayer : MonoBehaviour
{
    public List<AudioClip> Clips = new List<AudioClip>();

    private static AudioSource MusicSource;

    private AudioClip CurrentTrack;

    private float length; 

    private Coroutine Loop;

    private MusicQueue Queue;

    // Start is called before the first frame update
    void Start()
    {
        Queue = new MusicQueue(Clips);
        MusicSource = GetComponent<AudioSource>();
        StartClip();
    }

    public void PlayClip(AudioClip music)
    {
        MusicSource.Stop();
        MusicSource.clip = music;
        MusicSource.Play();
    }

    public void StopClip()
    {
        if (Loop != null)
            StopCoroutine(Loop);
    }

    public void StartClip()
    {
        Loop = StartCoroutine(Queue.LoopMusic(this, 0, PlayClip));
    }

    
}

public class MusicQueue
{
    private List<AudioClip> Clips;

    public MusicQueue(List<AudioClip> clips)
    {
        this.Clips = clips;
    }

    public IEnumerator LoopMusic(MonoBehaviour player, float delay, Action<AudioClip> playFunction)
    {
        while (true)
        {
            yield return player.StartCoroutine(Run(Randomize(Clips), delay, playFunction));
        }
    }

    public IEnumerator Run(List<AudioClip> tracks, float delay, Action<AudioClip> playFunction)
    {
        foreach (AudioClip clip in Clips)
        {
            playFunction(clip);
            yield return new WaitForSeconds(clip.length + delay);
        }
    }

    public List<AudioClip> Randomize(List<AudioClip> tracks)
    {
        List<AudioClip> copy = new List<AudioClip>(tracks);

        int n = copy.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            AudioClip value = copy[k];
            copy[k] = copy[n];
            copy[n] = value;
        }

        return copy;
    }
}