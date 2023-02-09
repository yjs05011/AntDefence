using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigid = null;
    public float damage = 0;
    public float range = 0;
    public Vector2 startPosition = default;

    public Ant ant =default;

    // Start is called before the first frame update
    void Start()
    {
        rigid =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = transform.up * 10f;
        Debug.Log($"Pos :{Vector2.Distance(startPosition,transform.GetComponent<RectTransform>().anchoredPosition)}");
        if(range*1.2 < Vector2.Distance(startPosition,transform.GetComponent<RectTransform>().anchoredPosition)){
            gameObject.SetActive(false);
            BulletSpawner.instance.Bullet_Number.Push(gameObject);
        }
    }

    private void OnEnable() {
        startPosition =transform.GetComponent<RectTransform>().anchoredPosition;}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Ant")
        {
            ant = other.transform.GetComponent<Ant>();
            ant.Ant_Hp -= damage;
            gameObject.SetActive(false);
            BulletSpawner.instance.Bullet_Number.Push(gameObject);
            Debug.Log($"Ant : {ant.Ant_Hp}");
        }
    }
}
