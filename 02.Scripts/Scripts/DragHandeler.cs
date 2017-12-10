using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {

    
    public static GameObject uiBeingDragged;

    
    Vector3 endPosition;   
    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData)
    {
        uiBeingDragged = gameObject;
        //startPosition = transform.position;
        //startParent = transform.parent;
    }
    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    #endregion

    #region IEndDragHandler implementation

    
    public void OnEndDrag(PointerEventData eventData)
    {
        
        uiBeingDragged = null;

       
    }
    #endregion

}
