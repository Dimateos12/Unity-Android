using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWM : MonoBehaviour {

     public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public bool shootStop = false;
    private int countMonsters = 0;
    
	// Use this for initialization
	void Start () {
         InvokeRepeating("SpawnObject", spawnTime, spawnDelay);	
	}
	
    void Update (){
        if(countMonsters >= 3){
            shootStop = true;
        }
    }
    
    public void SpawnObject() {
        if(!shootStop){
            Instantiate(spawnee, transform.position, transform.rotation);
            countMonsters++;
            if(stopSpawning) {
                CancelInvoke("SpawnObject");
            }
        }
        
    }

    

}