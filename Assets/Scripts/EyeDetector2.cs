using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;


public class EyeDetector2 : MonoBehaviour
{
    public WebCamTexture _webCamTexture;
    CascadeClassifier cascade;
    OpenCvSharp.Rect PlayerEyes;
    public float eyeY;
    public float eyeX;
   
  
    // Start is called before the first frame update
    void Start()
    {
     
        _webCamTexture=new WebCamTexture();
        _webCamTexture.Play();
        Debug.Log(_webCamTexture.isPlaying);
        cascade = new CascadeClassifier(Application.dataPath+@"/OpenCV+Unity/Demo/Face_Detector/haarcascade_mcs_eyepair_big.xml");

    }

    void Update(){
        Mat frame=OpenCvSharp.Unity.TextureToMat(_webCamTexture);
        findNewEyes(frame);
        display(frame);
    }



      

     void findNewEyes(Mat frame){
        var Eyes=cascade.DetectMultiScale(frame,1.1,1,HaarDetectionType.ScaleImage);
        if(Eyes.Length>=1){
            Debug.Log(Eyes[0].Location);
            PlayerEyes=Eyes[0];
            eyeY=Eyes[0].Y;
            eyeX=Eyes[0].X;
        }
     }

    void display(Mat frame){
            
        if(PlayerEyes!=null){
            frame.Rectangle(PlayerEyes,new Scalar(0,0,255),2);
        }
        Texture NewTexture =OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture=NewTexture;

    }
  
    
}
    

