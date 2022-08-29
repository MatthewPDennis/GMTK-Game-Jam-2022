using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Dice : MonoBehaviour
{
    /// <summary>
    /// Resultant values from a single click of the Roll Dice button
    /// </summary>
    public int[] DiceValues;

    /// <summary>
    /// Ordered array of die sprites from 1 (DiceImages[0]) to 6 (DiceImages[5])
    /// </summary>
    public Sprite[] DiceImages;

    public bool DisplayThirdDie;

    public bool FinishedRolling;

    private Image[] DiceComponents;

    private T GetChildComponentByName<T>(string name) where T : Component
    {
        foreach (T component in GetComponentsInChildren<T>(true))
        {
            if (String.Compare(component.gameObject.name, name) == 0)
                return component;
        }

        return null;
    }

    void Start()
    {
        //This function runs twice for some reason. Don't have time to troubleshoot unity internals, but I can stop it the second time around.
        if (DiceComponents == null)
        {
            //Get and store dice components so we can turn them on or off more easily later.
            DiceComponents = new Image[3];

            int i = 0;
            var image = GetChildComponentByName<Image>("DieOne");
            if (image != null)
            {
                DiceComponents[i++] = image;
                image.gameObject.SetActive(false);
            }

            image = GetChildComponentByName<Image>("DieTwo");
            if (image != null)
            {
                DiceComponents[i++] = image;
                image.gameObject.SetActive(false);
            }

            image = GetChildComponentByName<Image>("DieThree");
            if (image != null)
            {
                DiceComponents[i++] = image;
                image.gameObject.SetActive(false);
            }
        }

    }

    void Update()
    {
        
    }

    public void StartNewTurn()
    {
        FinishedRolling = false;
    }

    /// <summary>
    /// Fakes a dice roll using a RNG, records it in DiceValues
    /// Updates a die imaage with the appropriate sprite
    /// Turns dice on or off as appropriate
    /// </summary>
    public void RollDiceFake()
    {
        if (FinishedRolling) return;

        //Instantiate and fill all three dice
        DiceValues = new int[3];
        for (int i = 0; i < DiceValues.Length; i++)
        {
            int result = UnityEngine.Random.Range(1, 7);
            DiceValues[i] = result;
            //Set sprite appropriately based on result
            var image = this.transform.GetChild(i).GetComponent<Image>();
            image.sprite = DiceImages[result - 1];
        }

        //Activate dice components as appropriate.
        DiceComponents[0].gameObject.SetActive(true);
        DiceComponents[1].gameObject.SetActive(true);
        DiceComponents[2].gameObject.SetActive(DisplayThirdDie);

        FinishedRolling = true;
    }


}
