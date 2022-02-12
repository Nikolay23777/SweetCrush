using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basground_cont : MonoBehaviour
{
    public Transform bg1;
    public Transform bg2;

    public float speed;


    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bg1.position -= new Vector3(speed,0,0);
        bg2.position -= new Vector3(speed, 0, 0);

        if (bg1.position.x <= -22f)
        {
            bg1.position = new Vector3(22f, 0, gameObject.transform.position.z);
        }
        if (bg2.position.x <= -22f)
        {
            bg2.position = new Vector3(22f, 0, gameObject.transform.position.z);
        }
    }
}
