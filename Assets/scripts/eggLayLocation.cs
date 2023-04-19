using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggLayLocation : MonoBehaviour
{
    public GameObject layEggButton;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            layEggButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            layEggButton.SetActive(false);
        }
    }
}
