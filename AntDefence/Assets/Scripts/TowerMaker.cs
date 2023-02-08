using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TowerMaker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
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
        if(GameManager.instance.Play_Gold>=50){
            GameManager.instance.Play_Gold -= 50;
            isClicked = true;
            Tower = TowerSpawner.instance.Tower_Number.Pop().GetComponent<Canon>();
            Tower.gameObject.SetActive(true);
            Tower.transform.position = transform.position;
        }
       
        // Debug.Log($"Position : {transform.position}");


    }
    public void OnDrag(PointerEventData eventData)
    {
        if(!isClicked){
            return;
        }
       
            
        
        Vector2 mousePositionDelta = eventData.delta / canvas.scaleFactor;
        Tower.rectTransform.anchoredPosition += mousePositionDelta;

        // Debug.Log($"Tower Position:{Tower.rectTransform.anchoredPosition}");


    }
    public void OnPointerUp(PointerEventData eventData)
    {

        if (isClicked)
        {
            if (Tower.rectTransform.anchoredPosition.y > -220f)
            {
                isClicked = false;
            }
            else
            {
                isClicked = false;
                Tower.gameObject.SetActive(false);
                TowerSpawner.instance.Tower_Number.Push(Tower.gameObject);
            }
        }

    }
    
   
}

