using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance ;
    public int Play_Gold = 0;
    public int Play_Point = 0;
    public int Play_Lv = 0;
    public int Play_count = 2;
    public int Play_Life = 8;
    public int cake_count = 8;
    public int Ant_Respawner = 0;

    public int Lv_Per_Ant = 20;
   


    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
