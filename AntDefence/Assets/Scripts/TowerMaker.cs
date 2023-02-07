using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TowerMaker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject Tower = null;
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
        tower = true;
        Debug.Log(isClicked);
        Debug.Log(tower);

    }
    // 마우스 버튼에서 손을 뗐을 대 동작하는 함수
    public void OnPointerUp(PointerEventData eventData)
    {

        isClicked = false;
    }

    // 마우스를 드래그 중일 때 동작하는 함수
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("is Drag");
        if (isClicked)
        {
            if (tower)
            {
                Tower = TowerSpawner.instance.Tower_Number.Pop();
                PosX = Input.mousePosition.x;
                PosY = Input.mousePosition.y;
                Pos = Input.mousePosition;
                Debug.Log($"PosX :{PosX}");
                Debug.Log($"PosY :{PosY}");
                Tower.SetActive(true);
                tower = false;
            }
            Pos += eventData.delta / canvas.scaleFactor;
            Pos = transform.localToWorldMatrix * Pos;
            // Vector2 mousePosition = new Vector2(transform.position.x + (Input.mousePosition.x - PosX), transform.position.y + (Input.mousePosition.y - PosY));
            
            Tower.transform.position = Pos;
            Debug.Log($"{Pos}");
        }
    }
}

