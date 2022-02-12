using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Destructible2D
{
    public class Pref_obj : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject[] obj_all;
        public D2dThrower gen;
        public void GEN_obj()
        {
            //отбираем массив сладостей
            GameObject[] obj = new GameObject[15];
            for(int i = 0; i < obj.Length; i++) {
                int index = UnityEngine.Random.Range(0,obj_all.Length);
                obj[i] = obj_all[index];
            }
            gen.ThrowPrefabs = obj;
        }
        void Start()
        {

        }

     
    }
}