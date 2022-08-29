using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("Dropped on " + gameObject.name);

        //Reset dragged object's original parent to whatever it was dropped on
        var draggedObj = eventData.pointerDrag.GetComponent<DragAndDrop>();
        if (draggedObj != null)
            draggedObj.OriginalParent = this.transform;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Pointer entered");

        if (eventData.pointerDrag == null) return;

        var draggedObj = eventData.pointerDrag.GetComponent<DragAndDrop>();
        if (draggedObj != null)
            draggedObj.PlaceHolderParent = this.transform;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Pointer exited");

        if (eventData.pointerDrag == null) return;

        var draggedObj = eventData.pointerDrag.GetComponent<DragAndDrop>();
        if (draggedObj != null && draggedObj.PlaceHolderParent == this.transform)
            draggedObj.OriginalParent = this.transform;
    }


}
