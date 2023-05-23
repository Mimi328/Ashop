using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glasses : MonoBehaviour
{

     private Rigidbody rb;
    public EyeDetector2 Eye;
     float norm;
    float norm2;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        norm = Mathf.Clamp(Eye.eyeY / Screen.height, 0.0f, 1.0f);
        norm2 = Mathf.Clamp(Eye.eyeX / Screen.width, 0.0f, 1.0f);

        float targetY = Mathf.Lerp(-1.0f, 1.0f, norm);
        float targetX = Mathf.Lerp(-1.0f, 1.0f, norm2);
        Debug.Log("targetX"+targetX.ToString() + ", targetY " + targetY.ToString());
        /*Vector3 movement = new Vector3(targetX, 0,targetY) * 1.5f;
        rb.velocity = movement;*/
        
           
        Vector3 targetPosition = new Vector3(targetX,targetY, 0) * 1.5f;
        rb.MovePosition( targetPosition );
   
          
            
    }
}
