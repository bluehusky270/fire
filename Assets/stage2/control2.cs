using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control2 : MonoBehaviour
{
    Vector3 mv = Vector3.zero;
    float fr;
    float lr;
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fr = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).x;
        lr = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).y;
        mv.x = fr;
        mv.z = lr;
        transform.Translate(mv * speed * Time.deltaTime);
        if(OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            transform.position=transform.position + new Vector3(0,-speed*Time.deltaTime,0);
        }
    }
}
