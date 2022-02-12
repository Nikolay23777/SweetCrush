using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Destructible2D
{
    public class TAP : MonoBehaviour
    {
       public UI_Control uic;
       
       
        
        // Start is called before the first frame update
        void Start()
        {

        }
        int hhhh;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                 Time.timeScale = 1;
            //isklisc = true;
             //Debug.Log("dddd");
            uic.PLAY_PODSKAZKA();
            }
            if (Input.touchCount > hhhh)
            {
                hhhh = Input.touchCount;
                Time.timeScale = 1;
                //isklisc = true;
               // Debug.Log("dddd");
                uic.PLAY_PODSKAZKA();
            }
        }
        
    }
}