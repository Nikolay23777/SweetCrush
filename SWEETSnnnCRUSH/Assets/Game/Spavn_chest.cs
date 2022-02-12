using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Destructible2D
{
    public class Spavn_chest : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject chest;
        public GameObject kol;
        public void Spavn()
        {
            kol.SetActive(true);
            GameObject gm= Instantiate(chest, new Vector3(0, 0, 0), Quaternion.identity);
            gm.transform.localScale = new Vector3(1.958f,1.378f,0);
        }


    }
}