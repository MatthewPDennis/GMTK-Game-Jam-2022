using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform OriginalParent = null;

    public GameObject PlaceHolder = null;

    public Transform PlaceHolderParent = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Create placeholder object to maintain space in list where dragged object used to be
        PlaceHolder = new GameObject();
        PlaceHolder.transform.SetParent(this.transform.parent);
        LayoutElement le = PlaceHolder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;
        PlaceHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex()); //Maintain place in line

        //Save original parent so dragged object can snap back to origin when dropped
        OriginalParent = this.transform.parent;
        PlaceHolderParent = OriginalParent;
        this.transform.SetParent(this.transform.parent.parent);

        //Ensure elements under dragged object can still register to mouse pointer
        GetComponent<CanvasGroup>().blocksRaycasts = false;


    }

    public void OnDrag(PointerEventData eventData)
    {
        //Update dragged object position to mouse pointer position
        this.transform.position = eventData.position;

        
        //Allow dragged object to move around inside original list, pushing objects to the right or left as appropriate OR over destination list
        if (PlaceHolder.transform.parent != PlaceHolderParent)
            PlaceHolder.transform.SetParent(PlaceHolderParent);
        int newSibIndex = PlaceHolderParent.childCount - 1;
        for (int i = 0; i < PlaceHolderParent.childCount; i++)
        {
            if (this.transform.position.y > PlaceHolderParent.GetChild(i).position.y)
            {
                newSibIndex = i;
                if (PlaceHolder.transform.GetSiblingIndex() < newSibIndex)
                    newSibIndex--;
                break;
            }
        }
        PlaceHolder.transform.SetSiblingIndex(newSibIndex);
        

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Reset dragged object's parent to saved parent
        this.transform.SetParent(OriginalParent);
        this.transform.SetSiblingIndex(PlaceHolder.transform.GetSiblingIndex()); //Reset position in line

        //Allow objects to block mouse pointer again
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        //Remove placeholder object
        Destroy(PlaceHolder);
        PlaceHolder = null;
        OriginalParent = null;



    }

}
