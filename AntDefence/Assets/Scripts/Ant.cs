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
        hp_bar.fillAmount = Mathf.Lerp(hp_bar.fillAmount,Ant_Hp / Max_Hp,Time.deltaTime);
        cake.SetActive(has_Cake);
        if (!has_Cake)
        {
           Direction(6,-2.16f);
            if (!chk)
            {
                ant_rigid.position = Vector2.MoveTowards(transform.position, new Vector2(6, -2.16f), 0.05f);
                if (!coroutineChk)
                {
                    StartCoroutine(Waiting());

                }
            }
        }
        else
        {
           Direction(transform.parent.position.x,transform.parent.position.y);

            
            if (!chk)
            {
                ant_rigid.position = Vector2.MoveTowards(transform.position, transform.parent.position, 0.02f);
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

        
        if (Ant_Hp <= 0)
        {
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


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "UpperWall")
        {
            ant_rigid.velocity = new Vector2(0, 0);
            Debug.Log("is Tag");
            ant_rigid.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 0));
        }
        if (other.transform.tag == "UnderWall")
        {
            ant_rigid.velocity = new Vector2(0, 0);
            Debug.Log("is Tag");
            ant_rigid.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(0, 1f));
        }
        if (other.transform.tag == "LeftWall")
        {
            ant_rigid.velocity = new Vector2(0, 0);
            Debug.Log("is Tag");
            ant_rigid.velocity = new Vector2(Random.Range(0, 1f), Random.Range(-1f, 1f));
        }
        if (other.transform.tag == "RightWall")
        {
            ant_rigid.velocity = new Vector2(0, 0);
            Debug.Log("is Tag");
            ant_rigid.velocity = new Vector2(Random.Range(-1f, 0), Random.Range(-1f, 1f));
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
        ant_rigid.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        coroutineChk = false;
        chk = true;
        yield return new WaitForSeconds(Random.Range(0,1f));
        chk =false;
    }
    void Direction(float x, float y)
    {
        Vector2 direction = new Vector2(transform.position.x - x, transform.position.y - y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, 10);
        transform.rotation = rotation;
    }


}
