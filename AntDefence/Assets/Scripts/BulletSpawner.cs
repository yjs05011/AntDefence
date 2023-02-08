using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet = null;
    public Stack<GameObject> Bullet_Number = null; 
    private int TotalBullet = 300;
    public static BulletSpawner instance = null;

    void Awake(){
        if( null == instance){
            instance = this;

        }
        else{
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Bullet_Number = new Stack<GameObject>();
        for(int i = 0; i<TotalBullet; i++){
            GameObject objs = Instantiate(bullet);
            objs.transform.SetParent(gameObject.transform, false);
            objs.SetActive(false);
            Bullet_Number.Push(objs);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
