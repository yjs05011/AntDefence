using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canon : MonoBehaviour
{
    private CircleCollider2D canonCircle = null;
    private Image canonRangeImg= null;
    private float range = 2;
    // Start is called before the first frame update
    void Start()
    {
        canonRangeImg = transform.GetChild(0).gameObject.GetComponent<Image>();
        canonCircle = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        canonCircle.radius = range;

        canonRangeImg.rectTransform.sizeDelta = new Vector2(range,range);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.transform.tag == "Ant"){
            Debug.Log("is Target");
        }
    }
}
