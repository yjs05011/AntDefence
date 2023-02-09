using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUi : MonoBehaviour
{
    public Sprite[] heavyCanonList;
    public Sprite[] QuickCanonList;
    public Sprite[] DownGradeList;
    public Image[] ButtonImg = new Image[3];

    public Canon canon = null;

    private bool isCheck = true;
    private bool isClicked = true;
    // Start is called before the first frame update
    void Start()
    {
        canon = transform.GetComponentInParent<Canon>();
        ButtonImg[0] = transform.GetChild(0).GetComponent<Image>();
        ButtonImg[1] = transform.GetChild(1).GetComponent<Image>();
        ButtonImg[2] = transform.GetChild(2).GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canon.First_Upgrade)
        {
            ButtonImg[0].sprite = heavyCanonList[1];
            ButtonImg[1].sprite = QuickCanonList[1];
            ButtonImg[2].sprite = DownGradeList[1];

        }
        else if (!canon.First_Upgrade)
        {
            ButtonImg[0].sprite = heavyCanonList[0];
            ButtonImg[1].sprite = QuickCanonList[0];
            ButtonImg[2].sprite = DownGradeList[0];
        }
        if(GameManager.instance.ClickedChk){
            gameObject.SetActive(false);
        }

           
        

    }
    public void HeavyCanon()
    {
        if (canon.First_Upgrade)
        {
            // Debug.Log("not yet");
        }
        else
        {
            if (GameManager.instance.Play_Gold >= 30)
            {
                canon.First_Upgrade = true;
                canon.damage *= 2;
                canon.canonArrow.sprite = canon.canonSprite[1]; 
                Debug.Log(canon.damage);
            }


        }
        
    }

    public void QuickCanon()
    {
        if (canon.First_Upgrade)
        {
            // Debug.Log("not yet");
        }
        else
        {
            if (GameManager.instance.Play_Gold >= 30)
            {
                canon.First_Upgrade = true;
                canon.shotSpeed *= 2;
                canon.canonArrow.sprite = canon.canonSprite[2]; 
                Debug.Log(canon.shotSpeed);
            }


        }
    }

    public void DownGrade()
    {
        if (canon.First_Upgrade)
        {
            // Debug.Log("not yet");
        }
        else
        {
            canon.gameObject.SetActive(false);
            canon.damage =5;
            canon.shotSpeed =4f;
            canon.isClicked =false;
            canon.canonArrow.sprite = canon.canonSprite[0];
        }
    }
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
