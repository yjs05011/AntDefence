using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{
    public TMP_Text[] uiText = default;
    public GameObject countText = default;
    
    private bool countChk = false;
    public Sprite[] cakeImg = default;

    public Image cakeImage = null;
    public Image gameoverImg= null;


    // Start is called before the first frame update
    void Start()
    {
        
        GameManager.instance.Play_count = 3;
        GameManager.instance.Play_Gold =300;
        GameManager.instance.Play_Lv = 0;
        GameManager.instance.cake_count = 8;
        GameManager.instance.Play_Life = 8;
        GameManager.instance.Play_Point=0;
        GameManager.instance.Lv_Per_Ant= 12;
        GameManager.instance.Ant_Respawner =0;
        GameManager.instance.canon_total = 0;
        GameManager.instance.canon_price = 50;
        uiText[0].text = $"{GameManager.instance.Play_count}";
        StartCoroutine(Counter());
        uiText[1].text = $"{GameManager.instance.Play_Lv}";
        uiText[2].text = $"{GameManager.instance.Play_Gold}";
        uiText[3].text = $"{GameManager.instance.Play_Point}";
        
    }

    // Update is called once per frame
    void Update()
    
    {
        cakeImage.sprite = cakeImg[GameManager.instance.cake_count];
        uiText[1].text = $"{GameManager.instance.Play_Lv}";
        uiText[2].text = $"{GameManager.instance.Play_Gold}";
        uiText[3].text = $"{GameManager.instance.Play_Point}";
        if(GameManager.instance.Play_Life ==0){
            gameoverImg.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }
    IEnumerator Counter(){
        while(true){
            
            yield return new WaitForSeconds(1f);
            GameManager.instance.Play_count --;
            uiText[0].text = $"{GameManager.instance.Play_count}";
            if(GameManager.instance.Play_count == -1){
                countText.SetActive(false);
                break;
            }
        }
       
    }
}
