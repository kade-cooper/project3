using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private int eggcount = 0;
    public int maxEggs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseEggCount(){
        eggcount+=1;
        if(eggcount==maxEggs){
            SceneManager.LoadScene("after");
        }
    }
    
}
