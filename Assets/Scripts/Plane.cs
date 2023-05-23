using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;

public class Plane : MonoBehaviour
{
     public WebCamTexture _webCamTexture;
    CascadeClassifier cascade;
    CascadeClassifier cascade2;
    
    OpenCvSharp.Rect PlayerEyes;
    
    public float eyeY;
    public float eyeX;
    public GameObject glasses;
    private GameObject ClonedGlasses;
    float norm;
    float norm2;
    
    bool glassesInstantiated = false;

    // Start is called before the first frame update
    void Start()
    {
         
        _webCamTexture=new WebCamTexture();
        _webCamTexture.Play();
        Debug.Log(_webCamTexture.isPlaying);
        //cascade = new CascadeClassifier(Application.dataPath+@"/OpenCV+Unity/Demo/Face_Detector/haarcascade_eye.xml");
       cascade2 = new CascadeClassifier(Application.dataPath+@"/OpenCV+Unity/Demo/Face_Detector/haarcascade_mcs_eyepair_big.xml");

    }

    // Update is called once per frame
    void Update()
    {
        Mat frame=OpenCvSharp.Unity.TextureToMat(_webCamTexture);
        //What is mat data type? Mat(int rows, int cols, int type)
        /*This line creates a new instance of a Mat object, 
        which is short for "matrix." The Mat data type is a multi-dimensional array that is used to represent images or matrices in OpenCVSharp. In this line, the TextureToMat() method is called to convert a texture (which is the _webCamTexture variable) into a Mat object. The resulting Mat object represents a single frame from the webcam video stream.*/
        findNewEyes(frame);
        display(frame);
    }

     void findNewEyes(Mat frame){
        var Eyes=cascade2.DetectMultiScale(frame,1.1,1,HaarDetectionType.ScaleImage);
       //DetectMultiScale is a method provided by the cascade classifier object which is used to detect objects in a given frame or image.
        //frame refers to the input image or frame in which the face detection needs to be performed.
        //If faces are found, it returns the positions of detected faces as Rect(x,y,w,h).
        if(Eyes.Length>=1){
           // Debug.Log(Faces[0].Location);
            PlayerEyes=Eyes[0];
            eyeY=Eyes[0].Y;
            eyeX=Eyes[0].X;

            norm = Mathf.Clamp(eyeY / Screen.height, 0.0f, 1.0f);
            norm2 = Mathf.Clamp(eyeX / Screen.width, 0.0f, 1.0f);
            
            float targetY = Mathf.Lerp(-1.0f, 1.0f, norm);
            float targetX = Mathf.Lerp(-1.0f, 1.0f, norm2);
            
            /*UnityEngine.Transform newTransform = new UnityEngine.GameObject().transform;
            // set the position of the Transform to the location of the detected face
            newTransform.position = new UnityEngine.Vector3(targetX, targetY, 0);
            // instantiate the glasses prefab using the new Transform
            
            ClonedGlasses = Instantiate(glasses, newTransform);*/
              if (!glassesInstantiated) {
                // instantiate the glasses prefab only once
                ClonedGlasses = Instantiate(glasses);
                glassesInstantiated = true;
            }
            // set the position of the glasses prefab to the center of the eyes
            //ClonedGlasses.transform.position = new Vector3(targetX ,0, targetY);
             ClonedGlasses.transform.position = new Vector3(targetX,targetY, 0 );

        // rotate the glasses to align with the eyes
            //ClonedGlasses.transform.rotation = Quaternion.LookRotation(Vector3.forward, ClonedGlasses.transform.position - new Vector3(targetX,targetY, 0 ));
   
            Debug.Log(ClonedGlasses.transform.position.x);
            Debug.Log(ClonedGlasses.transform.position.y);
                 
          

        }
    }

   
    void display(Mat frame){
      
       
        if(PlayerEyes!=null){

            frame.Rectangle(PlayerEyes,new Scalar(0,0,255),2);
        }
        Texture NewTexture =OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture=NewTexture;

    }}
    
    

