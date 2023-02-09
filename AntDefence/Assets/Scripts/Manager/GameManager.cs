using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance ;
    public int Play_Gold ;
    public int Play_Point;
    public int Play_Lv ;
    public int Play_count;
    public int Play_Life;
    public int cake_count;
    public int Ant_Respawner;
    public int canon_total;
    public int canon_price; 
    public int Lv_Per_Ant;
    public bool ClickedChk = false;


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
        if(Lv_Per_Ant ==0){
            Play_Lv ++;
            Lv_Per_Ant =12;
        }
    }
}
