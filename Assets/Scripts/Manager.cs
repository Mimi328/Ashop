using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Manager : MonoBehaviour
{
    public GameObject start;
    public Plane Facecamera;
    public GameObject On;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=0f;
        On.SetActive(false);
        //bird=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void startBtn(){
        Time.timeScale=1f;
        start.SetActive(false);
        Facecamera._webCamTexture.Play();

    }
    //void instantiateGlasses(){  }
}
