using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
namespace Destructible2D
{
    public class Level_progresss : MonoBehaviour
    {
        // Start is called before the first frame update
        //для сохранения
        private Save_steps sv = new Save_steps();
        private string path;

        public Image[] points;
        public Image[] points_galki;
        public RectTransform MARKER;
        // public Sprite st_block;
        public int marker;//текущие положение
        public float[] position;

        public Animator CHESTS;
        //public Animation CHESTS_move;
        public GameObject BOX;//для  
        private bool is_open_chest;

        public Spavn_chest sc;//спавним разрушаемый сундук
        public D2dClickToExplode new_mex;
        public D2dClickToSpawn st_mex;

        public GameObject btn_normal_continue;
        public GameObject btn_stop_continue;
        public int shans_all_coins;
        private void pos_marker(int marker)
        {
            for (int i = 0; i < 5; i++)
            {
                points_galki[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < marker; i++)
            {
                points_galki[i].gameObject.SetActive(true);
            }
            /////////////////////////////////////////////////*******************************************
            //MARKER.anchoredPosition. = position[marker];
            MARKER.transform.localPosition = new Vector3(position[marker], MARKER.transform.localPosition.y, 0);


        }
        public void MOVE_MARKER()
        {
            load_date();
            marker++;
            MARKER.gameObject.SetActive(true);
            CHESTS.enabled = false;
            CHESTS.gameObject.GetComponent<Image>().sprite = state_close;
            //CHESTS_move.enabled = false;
            if (marker > 4)
            {
                marker = 0;
                //запуск аниации сундука
                MARKER.gameObject.SetActive(false);
                CHESTS.enabled = true;
                CHESTS.gameObject.GetComponent<Image>().sprite = state_pri_open;
                is_open_chest = true;
                btn_normal_continue.SetActive(false);
                btn_stop_continue.SetActive(true);


            }
            else
            {
                btn_normal_continue.SetActive(true);
                btn_stop_continue.SetActive(false);
                is_open_chest = false;
            }
            pos_marker(marker);
           
            Save_date();
        }
        public Sprite state_pri_open;
        public Sprite state_close;
        private bool taping;//служебнная переменная для готовности клика по сундуку
        public UI_Control ui_cont;
        public void CHEST_OPEN_MOVE()
        {
           // Debug.Log("tap");
            if (is_open_chest) {
                //при нажатие на сундук
                //CHESTS.SetBool("is_move", true);
                CHESTS.SetTrigger("move");
                BOX.SetActive(false);
                is_open_chest = false;
                //Debug.Log("++++++++++++++");
                //Debug.Log("++++++++++++++");
            }

           
            


        }

        public void KLIK()
        {
 if (taping)
            {
                sc.kol.SetActive(false);
                CHESTS.SetTrigger("tap");
              //  Debug.Log("gggggg");
              //  new_mex.enabled = true;
                st_mex.enabled = false;
                
               

            }
        }
        public void ADD_coin()
        {
            //метод вызовется когда настанет пора навчислить монеты
            ui_cont.mani += UnityEngine.Random.Range(10,15+ shans_all_coins);
            ui_cont.BTN_PLAY();

        }
        public GameObject box2;//чтобы скрыть 2 частьинтерфейса
        //просто смотрим состояния
        public void ANIM_a1_trigger()
        {
           // Debug.Log("********");
            box2.SetActive(false);
            taping = true; 
            sc.Spavn();
            new_mex.enabled = true;
            new_mex.lepro = this.GetComponent<Level_progresss>();


        }
        /*
        public void ANIM_a3_trigger()
        {
           

        }
        */
        //срабатывает перед тем как все вернуть на свои места
        public void ANIM_a2_trigger()
        {
            Debug.Log("////////");
            taping = false;
            new_mex.enabled = false;
            st_mex.enabled = true;
            sc.kol.SetActive(false);
            box2.SetActive(true);
            BOX.SetActive(true);
            box2.SetActive(true);
            ADD_coin();
           // ui_cont.BTN_PLAY();
        }
        public void CHEST_OPEN()
        {
            //при нажатие на сундук
           // CHESTS_move.enabled = false;
           //изменить позиции и вернуть назад 

            BOX.SetActive(false);

        }

        void Start()
        {

        }

        public void Save_date()
        {
            //  PlayGamesPlatform.Instance.SignOut();
            sv.MARKER = marker;

            File.WriteAllText(path, JsonUtility.ToJson(sv));
        }

        public void load_date()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
                path=Path.Combine(Application.persistentDataPath, "sav_steps.json");
#else
            path = Path.Combine(Application.dataPath, "sav_steps.json");
#endif
            if (File.Exists(path))
            {
                sv = JsonUtility.FromJson<Save_steps>(File.ReadAllText(path));
                marker = sv.MARKER;





            }
            else
            {
                // max_coin = 9999;
            }//ошибка окрытия файла сохранениния
        }

        /*
#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause) Save_date();
    }
#endif
        private void OnApplicationQuit()
        {
            Save_date();
        }

    }
    */
    }
}

[Serializable]
public class Save_steps
{

    public int MARKER;




}