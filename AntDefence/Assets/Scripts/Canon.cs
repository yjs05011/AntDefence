using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canon : MonoBehaviour
{
    public CircleCollider2D canonCircle = null;
    public Image canonRangeImg= null;
    public float range = 2;
    public RectTransform rectTransform = null;
    public bool First_Upgrade =false;
    public bool heavyCanon1 =false;

    public bool BigCanon1 =false;

    public int damage = 5;

    public float shotSpeed = 0.5f;

    public bool isClicked = false;
    public GameObject upgradeUi = null;

    public 
    // Start is called before the first frame update
    void Start()
    {
        canonRangeImg = transform.GetChild(0).gameObject.GetComponent<Image>();
        canonCircle = gameObject.GetComponent<CircleCollider2D>();
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        canonCircle.radius = range;

        canonRangeImg.rectTransform.sizeDelta = new Vector2(range*range,range*range);

        Debug.Log($"Ui : {upgradeUi.transform.position}");
    }

    public void OnTriggerStay2D(Collider2D other) {
        if(other.transform.tag == "Ant"){
            Debug.Log("is Target");
        }
    }

    public void UpgradeButton()
    {
        if (upgradeUi.activeSelf)
        {
            upgradeUi.SetActive(false);
        }
        else
        {
            isClicked = true;
            upgradeUi.SetActive(true);
            upgradeUi.transform.position = new Vector2(-0.5f, -3.94f);
        }

    }
}
