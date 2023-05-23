using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;


public class EyeDetector : MonoBehaviour
{
    public WebCamTexture _webCamTexture;
    CascadeClassifier cascade;
    OpenCvSharp.Rect PlayerEyes;
    public float eyeY;
    public float eyeX;
    public GameObject glasses;
    public GameObject sunglasses;
    private GameObject ClonedGlasses;
    float norm;
    float norm2;
    bool glassesInstantiated = false;
    private bool used = false;
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


        if(!used && Input.GetKey(KeyCode.A))
        {
            Replace(glasses, sunglasses);
            Debug.Log("Replaced");
            used=true;
        }


    }

     void findNewEyes(Mat frame){
        var Eyes=cascade.DetectMultiScale(frame,1.1,1,HaarDetectionType.ScaleImage);
        if(Eyes.Length>0){
           
            PlayerEyes=Eyes[0];
            eyeY=Eyes[0].Y;
            eyeX=Eyes[0].X;

            norm = Mathf.Clamp(eyeY / Screen.height, 0.0f, 1.0f);
            norm2 = Mathf.Clamp(eyeX / Screen.width, 0.0f, 1.0f);
            
            float targetY = Mathf.Lerp(-1.0f, 1.0f, norm);
            float targetX = Mathf.Lerp(-1.0f, 1.0f, norm2);
         
           
            if (!glassesInstantiated) {
                /*ClonedGlasses = Instantiate(glasses);*/
                UnityEngine.Transform newTransform = new UnityEngine.GameObject().transform;
                newTransform.position = new UnityEngine.Vector3(targetX, targetY, 0);
                ClonedGlasses = Instantiate(glasses, newTransform);
                glassesInstantiated = true;
                
            Debug.Log(newTransform.position.x);
            Debug.Log(newTransform.position.y);
            }
            
        }
     }

    void display(Mat frame){
            
        if(PlayerEyes!=null){
            frame.Rectangle(PlayerEyes,new Scalar(0,0,255),2);
        }
        Texture NewTexture =OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture=NewTexture;

    }
    void Replace(GameObject obj1, GameObject obj2){
        Instantiate(obj2,obj1.transform.position, Quaternion.identity);
         DestroyImmediate (obj1, true);
        //Destroy(obj1);
    }
    
}
    

