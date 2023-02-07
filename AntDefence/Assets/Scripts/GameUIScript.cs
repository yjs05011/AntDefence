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


    // Start is called before the first frame update
    void Start()
    {
        
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
