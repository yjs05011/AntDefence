using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canon : MonoBehaviour
{
    public CircleCollider2D canonCircle = null;
    public Image canonRangeImg= null;
    private float range = 200;
    public RectTransform rectTransform = null;
    public bool First_Upgrade =false;
    public bool heavyCanon1 =false;

    public bool BigCanon1 =false;

    public int damage = 5;

    public float shotSpeed = 4f;

    public bool isClicked = false;
    public GameObject upgradeUi = null;
    public GameObject bullet =null;
    public Vector2 canonPosition =default;
    public Image canonArrow = default;
    public float distance = 0;
    private bool nearEnemy = false;
    private bool routinChk = true;
    // Start is called before the first frame update
    void Start()
    {
        canonRangeImg = transform.GetChild(0).gameObject.GetComponent<Image>();
        canonCircle = gameObject.GetComponent<CircleCollider2D>();
        rectTransform = gameObject.GetComponent<RectTransform>();
        canonCircle.radius = range;
        canonArrow = transform.GetChild(1).gameObject.GetComponent<Image>();
        canonRangeImg.rectTransform.sizeDelta = new Vector2(range*2,range*2);
    }

    // Update is called once per frame
    void Update()
    {


        // Debug.Log($"Ui : {upgradeUi.transform.position}");
        Direction(canonArrow,canonPosition.x,canonPosition.y);
        if(nearEnemy){
            if(routinChk)
            {
                Debug.Log(nearEnemy);
                routinChk = false;
                StartCoroutine(Shooting());
            }
        }
        if(GameManager.instance.ClickedChk){
            upgradeUi.SetActive(false);
        }
    }

    public void OnTriggerStay2D(Collider2D other) {
        if(other.transform.tag == "Ant"){
           nearEnemy = true;
           canonPosition = other.transform.position; 
           
        }else{nearEnemy = false;}

    }

    public void UpgradeButton()
    {
        
        Debug.Log("ok");
        SetActiveUi(upgradeUi.activeSelf);

    }
     void Direction(Image img ,float x, float y)
    {
        Vector2 direction = new Vector2(img.transform.position.x - x, img.transform.position.y - y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 270f, Vector3.forward);
        Quaternion rotation = Quaternion.Slerp(img.transform.rotation, angleAxis, 1);
        img.transform.rotation = rotation;
    }
     public IEnumerator Shooting()
    {
        routinChk = false;
        Debug.Log("Shot");
        Bullet bullet = BulletSpawner.instance.Bullet_Number.Pop().GetComponent<Bullet>();
        bullet.damage = damage;
        bullet.range = range;
        bullet.transform.position = transform.position;
        bullet.transform.rotation = canonArrow.rectTransform.rotation;
        bullet.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f/shotSpeed);
        

        routinChk = true;
        
        // ant_rigid.position = Vector2.MoveTowards(transform.position,new Vector2(randomX, randomY) , 0.02f);
       
    }
    public void SetActiveUi(bool SetActive){
         if (SetActive)
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
