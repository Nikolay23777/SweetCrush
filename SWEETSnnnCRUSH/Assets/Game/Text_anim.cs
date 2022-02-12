using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_anim : MonoBehaviour
{
    // Start is called before the first frame update
    private Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play();
    }
}
