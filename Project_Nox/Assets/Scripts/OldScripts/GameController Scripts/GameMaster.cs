using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    //public HUDcontroller hudController;
    //public ExitSign exitSign;
    public int keysCollected = 0;
    
    public float keys;
    public GameObject[] keyList;

    void Awake() { instance = this; }

    public void KeyPickup() {
        keysCollected++;
        //if (keysCollected == keys) 
        //{ ExitSign.instance.finished = true; }
    }

    public void ReStart() {
        keysCollected = 0;
        for (int i = 0; i < keyList.Length; i++) {
            keyList[i].SetActive(true);
            if (i >= keyList.Length) {
                i = 0;
            }
        }
    }
}
