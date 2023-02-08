using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseUi = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick(){
        pauseUi.SetActive(true);
        Time.timeScale=0f;
    }
    public void Restart(){
        SceneManager.LoadScene("Main");
        Time.timeScale=1f;
    }
    public void ClosePause(){
        pauseUi.SetActive(false);
        Time.timeScale=1f;
    }
}
