using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BackGround : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData){
        GameManager.instance.ClickedChk =true;

     }
    public void OnPointerUp(PointerEventData eventData){
        GameManager.instance.ClickedChk =false;
    }
}
