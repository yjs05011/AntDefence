using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class TowerMaker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Canon Tower = null;
    public Canvas canvas = null;
    private bool isClicked = false;
    private bool tower = false;
    private float PosX = default;
    private float PosY = default;
    private Vector2 Pos = Vector2.zero;
    private TMP_Text price = null;


    // Start is called before the first frame update
    void Start()
    {
        price = transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        price.text = $"{GameManager.instance.canon_price}";
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(GameManager.instance.Play_Gold>= GameManager.instance.canon_price){
            GameManager.instance.Play_Gold -= GameManager.instance.canon_price;
            isClicked = true;
            Tower = TowerSpawner.instance.Tower_Number.Pop().GetComponent<Canon>();
            
            Tower.gameObject.SetActive(true);
            Tower.isMount = false;
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
                Tower.isMount = true;
                GameManager.instance.canon_price +=10;
                GameManager.instance.canon_total ++;
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

