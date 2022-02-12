using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
//using AppodealAds.Unity.Api;
//using AppodealAds.Unity.Common;
namespace Destructible2D
{
    public class SHOP : MonoBehaviour
    {
        // Start is called before the first frame update
        //для сохранения
        private Save_shop sv = new Save_shop();
        private string path;

        public int[] lv;//здесь хроняться уровни улучшений в том порядке в котором они сейчас 

        public int shans_bonus_time;
        public int shans_bomba;
        public int shans_life_up;
        public int shans_all_coins;

        public UI_Control ui_con;

        public D2dThrower gen;
        //для недостающего меню
        public Text add_mani;

        /// <summary>
        /// ////////2 вкладка магаза
        /// </summary>

        public Text title_vkladka;
        public GameObject[] vkladki;


    void Start()
        { 
            nach_price = 9;
            lv = new int[4] { 1, 1, 1, 1 }; //4 така их пока всего 4 улучшения
            load_date();

           

            shans_bonus_time = lv[0];
            shans_bomba = lv[1];
            shans_life_up = lv[2];
            shans_all_coins = lv[3];

            for(int i = 0; i < lv.Length; i++)
            {
                if (lv[i] >= 99)
                {
                    //zamok_sostoanie
                    lv[i] = 99;
                    btn_shop[i].sprite = zamok_sostoanie;
                }
                t_level[i].text = "LV " + lv[i]; ;
                t_price[i].text = (lv[i] + nach_price) + "";
            }
            gen.shans_spavn_bonus = shans_bonus_time;
            ui_con.shans_fozrojdenie = shans_life_up;
            LP.shans_all_coins = shans_all_coins;

      //      Appodeal.initialize("1e10cce216e7390fa8fa0bf6de8434e54a28924c228f172e", Appodeal.REWARDED_VIDEO, true);
            //////////////////////////
            /// 
            for(int i = 0; i < btn_image.Length; i++)
            {
                //Debug.Log("fff "+ i);
                if (bay_vzriv[i] == true)
                {
                     
                     // btn_image[i].sprite = btn;
                      btn_image_vnutr[i].sprite = galka_iko;
                    price_shoping[i].text = "-";
                    Debug.Log("//////////////" + btn_image[i].GetComponentInChildren<Image>().gameObject.name);
                }
                  
                // btn[i].GetComponentInChildren<Image>().sprite = shop_iko;
            }
            BTN_vzriv_ok(t_index);


            //btn[id].GetComponent<Image>().sprite = butn_vibrona;
            //  btn[id].GetComponentInChildren<Image>().sprite = galka_iko;
        }
        public Image video;
        public Sprite vn1;
        public Sprite vn2;
        public void Nexvatka_mani(int param)
        {
            ui_con.BTN_ADD_MANI();
            add_mani.text = "+" + param;
            skoka_nexvataet = param;
            /*
            if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
            {
                video.sprite = vn1;
            }
            else
            {
                video.sprite = vn2;
            }
            */

            }
        public void nechvatka()
        {
            /*
            if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
            {
               // video.sprite = vn1;
                Appodeal.setRewardedVideoCallbacks(this);
                Appodeal.show(Appodeal.REWARDED_VIDEO);
                ui_con.mani += skoka_nexvataet;
            }
            */
            
        }
        public Sprite zamok_sostoanie;//чтобы сменилось иконка

        // Update is called once per frame
        //вызывается при нажатии кнопки купить
        public Text[] t_level;
        public Text[] t_price;
        public Image[] btn_shop;
        public ParticleSystem[] efect_lv_up;//эфект который страбатывает когда пройден уровень
        private int nach_price;
        public int skoka_nexvataet;
        public Level_progresss LP;
        public void OBNOVA(int id)
        {
            Debug.Log("/////");
            if (lv[id] >= 99)
            {
                //zamok_sostoanie
                btn_shop[id].sprite = zamok_sostoanie;
                return;
            }

            if (id == 0)
            {
               
                if (ui_con.mani >= (lv[id] + nach_price))
                {
                    //если хватает бабок
                    ui_con.mani -= (lv[id] + nach_price);
                    lv[id]++;
                    // tlevel.text 
                    t_level[id].text= "LV " + lv[id];;
                    t_price[id].text= (lv[id]+ nach_price) +"";
                    efect_lv_up[id].Play();
                    if (lv[id] >= 99)
                    {
                        //zamok_sostoanie
                        btn_shop[id].sprite = zamok_sostoanie;
                        return;
                    }
                }
                else
                {
                    //если нет бабок
                    Nexvatka_mani((lv[id] + nach_price)- ui_con.mani);
                }
        } else if (id == 1)
            {
                if (ui_con.mani >= (lv[id] + nach_price))
                {
                    //если хватает бабок
                    ui_con.mani -= (lv[id] + nach_price);
                    lv[id]++;
                    //tlevel.text = "LV " + lv[id];
                    t_level[id].text = "LV " + lv[id]; ;
                    t_price[id].text = (lv[id]+ nach_price) + "";
                    efect_lv_up[id].Play();
                    if (lv[id] >= 99)
                    {
                        //zamok_sostoanie
                        btn_shop[id].sprite = zamok_sostoanie;
                        return;
                    }
                }
                else
                {
                    //если нет бабок
                    Nexvatka_mani((lv[id] + nach_price) - ui_con.mani);
                }
            }
            else if (id == 2)
            {
                if (ui_con.mani >= (lv[id] + nach_price))
                {
                    //если хватает бабок
                    ui_con.mani -= (lv[id] + nach_price);
                    lv[id]++;
                    // tlevel.text = "LV " + lv[id];
                    t_level[id].text = "LV " + lv[id]; ;
                    t_price[id].text = (lv[id]+ nach_price) + "";
                    efect_lv_up[id].Play();
                    if (lv[id] >= 99)
                    {
                        //zamok_sostoanie
                        btn_shop[id].sprite = zamok_sostoanie;
                        return;
                    }
                }
                else
                {
                    //если нет бабок
                    Nexvatka_mani((lv[id] + nach_price) - ui_con.mani);
                }
            }
            else if (id == 3)
            {
                if (ui_con.mani >= (lv[id] + nach_price))
                {
                    //если хватает бабок
                    ui_con.mani -= (lv[id] + nach_price);
                    lv[id]++;
                    //tlevel.text = "LV " + lv[id];
                    t_level[id].text = "LV " + lv[id]; ;
                    t_price[id].text = (lv[id]+ nach_price) + "";
                    efect_lv_up[id].Play();
                    if (lv[id] >= 99)
                    {
                        //zamok_sostoanie
                        btn_shop[id].sprite = zamok_sostoanie;
                        return;
                    }
                }
                else
                {
                    //если нет бабок
                    Nexvatka_mani((lv[id] + nach_price) - ui_con.mani);
                }
            }
           

        }



        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// 
        private int id_vkladka;
        public Sprite butn_vibrona;
        public Sprite butn_no_vibrona;
        public Sprite shop_iko;
        public Sprite galka_iko;
        public bool[] bay_vzriv=new bool[9];//что купленна а что нет
        public Image[] btn_image;///иконки самих кнопок
        public Image[] btn_image_vnutr;//иконки значков над кнопками
        public Text[] price_shoping;//текст стоимости
        public Image[] btn_galochka;//галочки для дебилов

        public D2dClickToSpawn clictospawn;
        public GameObject[] efects;
        public int t_index;
        public void BTN_vkladka_up()
        {
            id_vkladka++;
            if (id_vkladka % 2 == 1)
            {
                 title_vkladka.text = "Взрывы";
                vkladki[1].SetActive(true);
                vkladki[0].SetActive(false);
            }
            else
            {
                title_vkladka.text = "Улучшения";
                vkladki[0].SetActive(true);
                vkladki[1].SetActive(false);
               
            }
            
        }
       
        public void Prenenit_vzriv(int id)
        {
            clictospawn.Prefab = efects[id];
        }
        public void BTN_vzriv_ok(int id)
        {
            if (bay_vzriv[id] == true)
            {
                for (int i = 0; i < btn_image.Length; i++)
                {
                    btn_galochka[i].sprite = null;
                    btn_galochka[i].color=new Color32(1,1,1,0);
                    btn_image[i].sprite = butn_no_vibrona;
                    // btn_image_vnutr[i].sprite =galka_iko;
                    //  btn[i].GetComponentInChildren<Image>().sprite = shop_iko;
                }
                t_index = id;
                btn_image[id].sprite = butn_vibrona;
                btn_galochka[id].sprite = galka_iko;
                btn_galochka[id].color = new Color32(180, 251, 193, 255);
                btn_image_vnutr[id].sprite = galka_iko;
                //btn[id].GetComponentInChildren<Image>().sprite = galka_iko;
                Prenenit_vzriv(id);
            }
        }
            public void BTN_vzriv_buy(int id)
        {
            if (bay_vzriv[id]==true)
            {
                t_index = id;
                for (int i = 0; i < btn_image.Length; i++)
                {
                    btn_galochka[i].sprite=null;
                    btn_image[i].sprite = butn_no_vibrona;
                    //btn_image[i].sprite = butn_no_vibrona;
                    btn_galochka[i].color = new Color32(1, 1, 1, 0);
                    // btn_image_vnutr[i].sprite =galka_iko;
                    //  btn[i].GetComponentInChildren<Image>().sprite = shop_iko;
                }
                btn_galochka[id].color = new Color32(180, 251, 193, 255);
                btn_image[id].sprite = butn_vibrona;
                btn_galochka[id].sprite = galka_iko;
                btn_image_vnutr[id].sprite = galka_iko;
                //btn[id].GetComponentInChildren<Image>().sprite = galka_iko;
                Prenenit_vzriv(id);
            }
            else
            {

              
                if (ui_con.mani >= 250)
                {
                    bay_vzriv[id]=true;
                    ui_con.mani -= 250;
                    for (int i = 0; i < btn_image.Length; i++)
                    {
                        // btn_image[i].sprite = butn_no_vibrona;

                        btn_galochka[i].sprite = null;
                        btn_image[i].sprite = butn_no_vibrona;
                        //btn_image[i].sprite = butn_no_vibrona;
                        btn_galochka[i].color = new Color32(1, 1, 1, 0);
                    }
                    price_shoping[id].text = "-";
                   // btn_image[id].sprite = butn_vibrona;

                    btn_galochka[id].color = new Color32(180, 251, 193, 255);
                    btn_image[id].sprite = butn_vibrona;
                    btn_galochka[id].sprite = galka_iko;
                    btn_image_vnutr[id].sprite = galka_iko;
                    t_index = id;
                    Prenenit_vzriv(id);
                }
                else
                {
                    //если нет бабок
                    Nexvatka_mani(250 - ui_con.mani);
                }
            }
        }
        
        public void Save_date()
        {
            //  PlayGamesPlatform.Instance.SignOut();
            sv.LV_save = lv;
             sv.VZRIV_BUY=bay_vzriv;
            sv.T_INDEX = t_index;
            File.WriteAllText(path, JsonUtility.ToJson(sv));
        }


        public void load_date()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
                path=Path.Combine(Application.persistentDataPath, "sav_shop.json");
#else
            path = Path.Combine(Application.dataPath, "sav_shop.json");
#endif
            if (File.Exists(path))
            {
                sv = JsonUtility.FromJson<Save_shop>(File.ReadAllText(path));
                lv = sv.LV_save;
                bay_vzriv = sv.VZRIV_BUY;
                t_index =sv.T_INDEX;




            }
            else
            {
                // max_coin = 9999;
            }//ошибка окрытия файла сохранениния
        }

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

        public void onRewardedVideoLoaded(bool precache)
        {
            throw new NotImplementedException();
        }

        public void onRewardedVideoFailedToLoad()
        {
            throw new NotImplementedException();
        }

        public void onRewardedVideoShowFailed()
        {
            throw new NotImplementedException();
        }

        public void onRewardedVideoShown()
        {
            throw new NotImplementedException();
        }

        public void onRewardedVideoFinished(double amount, string name)
        {
            // throw new NotImplementedException();
            //ui_con.mani += skoka_nexvataet;
        }

        public void onRewardedVideoClosed(bool finished)
        {
            throw new NotImplementedException();
        }

        public void onRewardedVideoExpired()
        {
            throw new NotImplementedException();
        }

        public void onRewardedVideoClicked()
        {
            throw new NotImplementedException();
        }
    }
}

[Serializable]
public class Save_shop
{

    public int[] LV_save;
    public bool[] VZRIV_BUY;
    public int T_INDEX;




}
