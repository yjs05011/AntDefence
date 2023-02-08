using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ant : MonoBehaviour
{
    public float Ant_Hp = 20;
    public float Max_Hp = 20;
    private bool has_Cake = false;

    private BoxCollider2D ant_hitBox = null;

    private Image hp_bar = null;
    private Rigidbody2D ant_rigid = null;
    public GameObject cake = null;

    private bool chk = false;

    private bool coroutineChk = false;
    private float randomX= 0;
    private float randomY= 0f;
    private bool isFake = false;

    // Start is called before the first frame update
    void Start()
    {
        ant_hitBox = gameObject.GetComponent<BoxCollider2D>();
        hp_bar = transform.GetChild(2).gameObject.GetComponent<Image>();
        ant_rigid = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        hp_bar.fillAmount = Mathf.Lerp(hp_bar.fillAmount, Ant_Hp / Max_Hp, Time.deltaTime);
        cake.SetActive(has_Cake);
        Move();



        if (Ant_Hp <= 0)
        {
            Die();
        }


    }

    private void Move()
    {
        if (!has_Cake)
        {

            if (!chk)
            {
                if(isFake){
                    Direction(randomX,randomY);
                    ant_rigid.position = Vector2.MoveTowards(transform.position,new Vector2(randomX, randomY) , 0.02f);
                }else{  
                    Direction(6, -2.16f);
                    ant_rigid.position = Vector2.MoveTowards(transform.position, new Vector2(6, -2.16f), 0.05f);

                }
                
                if (!coroutineChk)
                {
                    StartCoroutine(Waiting());
                   

                }
                
                
            }
        }
        else
        {



            if (!chk)
            {
                if(isFake){
                    Direction(randomX,randomY);
                    ant_rigid.position = Vector2.MoveTowards(transform.position,new Vector2(randomX, randomY) , 0.02f);
                }else{  
                    Direction(transform.parent.position.x, transform.parent.position.y);
                    ant_rigid.position = Vector2.MoveTowards(transform.position, transform.parent.position, 0.02f);
                }
               
                if (!coroutineChk)
                {
                    StartCoroutine(Waiting());

                }
            }
            if (transform.position == transform.parent.position)
            {
                GameManager.instance.Play_Life--;
                gameObject.SetActive(false);
                GameManager.instance.Ant_Respawner--;
            }
        }
    }
    private void Die(){
        if (has_Cake)
            {
                has_Cake = false;

            }
            else
            {
                transform.position = transform.parent.position;
                GameManager.instance.Ant_Respawner--;
                Ant_Hp = 20 + GameManager.instance.Play_Lv * 3;
                gameObject.SetActive(false);
                AntSpawnner.instance.Ant_Number.Push(gameObject);
            }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "UpperWall")
        {
            ant_rigid.velocity = new Vector2(0, 0);
            Debug.Log("is Tag");
        }
        if (other.transform.tag == "UnderWall")
        {
            ant_rigid.velocity = new Vector2(0, 0);
            Debug.Log("is Tag");
        }
        if (other.transform.tag == "LeftWall")
        {
            ant_rigid.velocity = new Vector2(0, 0);
            Debug.Log("is Tag");
        }
        if (other.transform.tag == "RightWall")
        {
            ant_rigid.velocity = new Vector2(0, 0);
            Debug.Log("is Tag");
        }
        if (other.transform.tag == "Cake")
        {
            if (GameManager.instance.cake_count > 0)
            {
                Debug.Log("Cake");
                has_Cake = true;
                GameManager.instance.cake_count--;
            }



        }
        if (other.transform.tag == "Hole")
        {
            if (has_Cake)
            {
                Debug.Log("return");
                GameManager.instance.Play_Life--;
                gameObject.SetActive(false);
                has_Cake = false;
                GameManager.instance.Ant_Respawner--;
                AntSpawnner.instance.Ant_Number.Push(gameObject);

            }



        }
    }
    public IEnumerator Waiting()
    {
        coroutineChk = true;
        yield return new WaitForSeconds(Random.Range(0,1f));
        randomX= Random.Range(-1280f,1280f);
        randomY= Random.Range(-720f,720f);
        
        // ant_rigid.position = Vector2.MoveTowards(transform.position,new Vector2(randomX, randomY) , 0.02f);
        coroutineChk = false;
        chk = true;
        yield return new WaitForSeconds(Random.Range(0,1f));

        int randomNum = Random.Range(0,2);
        if(randomNum == 0){
            isFake = true;
        }else{ isFake =false; }
        chk =false;
    }
    void Direction(float x, float y)
    {
        Vector2 direction = new Vector2(transform.position.x - x, transform.position.y - y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, 1);
        transform.rotation = rotation;
    }


}
