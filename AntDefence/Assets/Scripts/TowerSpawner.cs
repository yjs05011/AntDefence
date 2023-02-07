using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
  public GameObject Tower = null;
    public Stack<GameObject> Tower_Number = null;
    private int totalAnt = 10;
    public static TowerSpawner instance = null;
    private bool chk = false;
    private int poolingCount = 0;
    private int count = 0;
    void Awake(){
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       Tower_Number = new Stack<GameObject>();
            for (int i = 0; i < 100; i++)
            {
                GameObject Objs = Instantiate(Tower);
                Objs.transform.SetParent(gameObject.transform);
                Objs.SetActive(false);
                Tower_Number.Push(Objs);

            }
    }

    // Update is called once per frame
    void Update()
    {
       
        
        // GameManager.instance.Play_Life가 깍이면 gameObject.Image.Sprite = Sprite[playerLife]
        
    }

}
