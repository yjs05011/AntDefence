using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TowerMaker1: MonoBehaviour,IDragHandler,IPointerDownHandler{


    public Canon Tower = null;
    public Canvas canvas = null;
    private bool isClicked = false;
    private bool tower = false;
    private float PosX = default;
    private float PosY = default;
    private Vector2 Pos = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
        Tower = TowerSpawner.instance.Tower_Number.Pop().GetComponent<Canon>();
        Tower.gameObject.SetActive(true);
        Tower.transform.position = transform.position;
        Debug.Log($"Position : {transform.position}");


    }
    public void OnDrag(PointerEventData eventData)
    {
        if(!isClicked){
            return;
        }
       
           
        tower =false;
            
        
        Vector2 mousePositionDelta = eventData.delta / canvas.scaleFactor;
        Tower.rectTransform.anchoredPosition += mousePositionDelta;


    }
    public void OnPointerUp(PointerEventData eventData)
    {

        isClicked = false;
    }
    
   
}

