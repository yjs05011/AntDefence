using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawnner : MonoBehaviour
{
    public GameObject Ant = null;
    public Stack<GameObject> Ant_Number = null;
    private int totalAnt = 10;
    public static AntSpawnner instance = null;
    private bool chk = false;
    private int poolingCount = 0;
    private int count = 4;
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
       Ant_Number = new Stack<GameObject>();
            for (int i = 0; i < 10; i++)
            {
                GameObject Objs = Instantiate(Ant);
                Objs.transform.SetParent(gameObject.transform);
                Objs.SetActive(false);
                Ant_Number.Push(Objs);

            }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.Play_count == -1)
        {
            if(GameManager.instance.Ant_Respawner <6)
            if (!chk)
            {
                chk = true;
                StartCoroutine("Waiting");
                if (count == 4)
                {
                    GameObject Ant = Ant_Number.Pop();
                    Ant.transform.SetLocalPositionAndRotation(transform.parent.position,new Quaternion(0,0,0,0));
                    Ant.SetActive(true);
                    
                    GameManager.instance.Ant_Respawner ++;

                    count = 0;
                }
            }

        }
        // GameManager.instance.Play_Life가 깍이면 gameObject.Image.Sprite = Sprite[playerLife]
        
    }
    public IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        chk = false;
        count++;
    }
}
