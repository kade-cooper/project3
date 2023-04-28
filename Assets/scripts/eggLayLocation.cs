using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggLayLocation : MonoBehaviour
{
    public GameObject layEggButton;
    public GameObject egg;
    public GameObject player;
    private bool playerIn=false;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            layEggButton.SetActive(true);
            playerIn=true;
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            layEggButton.SetActive(false);
            playerIn=false;
        }
    }
    public void layEgg(){
        if(playerIn==true){
            Instantiate(egg,this.transform.position, Quaternion.identity);
            player.SendMessage("IncreaseEggCount");
            Destroy(this.gameObject);
        }
    }
}
