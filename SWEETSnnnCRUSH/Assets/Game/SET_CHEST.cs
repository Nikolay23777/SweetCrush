using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Destructible2D
{
    public class SET_CHEST : MonoBehaviour
    {
        // Start is called before the first frame update
        public Level_progresss LV;

        public void ZZZZTRIGGER1()
        {
         //   Debug.Log("000000");
            LV.ANIM_a1_trigger();
        }
        public void ZZZZTRIGGER2()
        {
            LV.ANIM_a2_trigger();
            Debug.Log("000000");
        }
        /*
        public void ZZZZTRIGGER3()
        {
            LV.ANIM_a3_trigger();
        }
        */
        /*
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        */
    }
}