using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
//using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


//using AppodealAds.Unity.Api;
//using AppodealAds.Unity.Common;



namespace Destructible2D
{


    public class UI_Control : MonoBehaviour//, IRewardedVideoAdListener
    {
        public static PlayGamesPlatform platform;
        // Start is called before the first frame update
        //для сохранения
        private Save sv = new Save();
         private string path;

        public Sprite[] bg;//сами фоны 
        

        public SpriteRenderer sr1;//для фона
        public SpriteRenderer sr2;//для фона 


        public GameObject game;
        public GameObject menu;
        public GameObject pause;
        public GameObject game_over;
        public GameObject SHOP;//панель магазина
        public GameObject SHOPmani;//панель магазина
        public GameObject HELPED;
        public GameObject OOPS;

        public D2dThrower GEN;//обьект генератор
        public D2dClickToSpawn Mau; //обьект мышь чтобы активировать клики



        private int P_mani;//сами звездочки
        private int P_max_coin;

        private int P_max_coin_hard;
        private int P_lv;
        private int P_coin_N;
        private int P_coin_H;


        public Text MANI;
        public Text MANI2;
        public Text LV;
        public Text Max_COIN;
        public Text Max_COIN2;//чтобы показать максимальный рекорд при смерти
        public Text COIN;



        public Text LV_START;//Отображение на уровне
        public Text LV_END;

        public Slider lv_controller;


        /// <summary>
        /// ////
        /// </summary>
        ///для левел ап
        public GameObject Level_up;
        public ParticleSystem ef1;
        public ParticleSystem ef2;
        public Text Level_up_text;

        //для воскрещения за рекламу 
        public GameObject btn_restart;

        public Sprite bacground_MENU;//фон в меню
        public Sprite bacground_LV;//фон в игре
        public SpriteRenderer bascground;//сам обьект


        //для анимации всплывающего уровня
        public GameObject Level_pokaz;

        //для бонуса замедление времени
        public GameObject SFX_ZAMEDLENIE;
        //ссылка на скрипт который выбирает 15 обьектов на уравень
        public Pref_obj Gen_obj;

        public Level_progresss lv_step;//здесь содержится ссылка на скрипт который двигает маркер

        public GameObject KONKURS_play;

        ///public AHSave hhh;
        public int mani
        {
            get
            {
                return P_mani;
            }

            set
            {
               // hhh.sv.MANI=
                // sv.MANI = mani;
                P_mani = value;
                MANI.text = value+"";
                MANI2.text = value + "";
                if (P_mani>=10000)
                {
                    Get_Achivments(GPGSIds.achievement_6);
                }
               // Debug.Log("//");
            }
        }
        public int coin_normal
        {
            get
            {
                return P_coin_N;
            }

            set
            {
                P_coin_N = value;
                COIN.text = value + "";
                // Debug.Log("//");
            }
        }
        /*
        public int coin_hard
        {
            get
            {
                return P_coin_H;
            }

            set
            {
                P_coin_H = value;
                COIN.text = value + "";
                // Debug.Log("//");
            }
        }
        */
        public int max_coin
        {
            get
            {
                return P_max_coin;
            }

            set
            {
               
            
               // sv.MAX_COIN = max_coin;
                P_max_coin = value;
                Max_COIN.text = "BEST "+value;
                Max_COIN2.text = "BEST " + value;
                if (P_max_coin>=1000000)
                {
                    Get_Achivments(GPGSIds.achievement_7);
                }
            }
        }
        public int max_coin_hard
        {
            get
            {
                return P_max_coin_hard;
            }

            set
            {


                // sv.MAX_COIN = max_coin;
                P_max_coin_hard = value;
                Max_COIN.text = "BEST " + value;
                Max_COIN2.text = "BEST " + value;
                if (P_max_coin >= 1000000)
                {
                    Get_Achivments(GPGSIds.achievement_7);
                }
            }
        }
        //
        public int lv
        {
            get
            {
                return P_lv;
            }

            set
            {
               
               // sv.LV = lv;
                P_lv = value;
                LV.text = value + "";
            }
        }

        public bool ISPLAY;

        private int LEVEL_COIN;

        //для настройки
        public GameObject Setting;


        public Image btn_musik;//музыка
        public Image btn_zvik;//звук


        public Sprite im_m1;//музыка норм состояния
        public Sprite im_m2;//музыка офф состояния

        public Sprite im_z1;//звук норм состояния
        public Sprite im_z2;//звук офф состояния

        public AudioSource Saund_Klisk;//звук клика
        public AudioSource Saund_musik;//фоновая музыка
        public AudioSource Saund_gameover;//звук при смерти
        public AudioSource Saund_levelup;//звук при прохождение уровня

       // public Animation coien_t;//

        // public void 
        public bool is_musik;
        public bool is_zvik;
        public void BTN_Misik(int id)
        {
            if (id > 0)
            {
                is_musik = !is_musik;
            }
            if (is_musik)
            {
                btn_musik.sprite = im_m1;              
                Saund_musik.enabled = true;
               // sv.is_musik = true;
            }
            else 
            {
                btn_musik.sprite = im_m2;           
                Saund_musik.enabled = false;
               // sv.is_zvyk = true;
            }
        }
        public void BTN_Zvik(int id)
        {
            if (id > 0)
                {
                    is_zvik=!is_zvik;
                }
            if (is_zvik)
            {
                btn_zvik.sprite = im_z1;               
                Saund_Klisk.enabled =true;
                Saund_gameover.enabled = true;
                Saund_levelup.enabled = true;
            }
            else 
            {
                btn_zvik.sprite = im_z2;                           
               Saund_Klisk.enabled = false;
                Saund_gameover.enabled = false;
                Saund_levelup.enabled = false;
               // Debug.Log("----");
            }
        }

        private const string achiv1 = "CgkIhdfM5YASEAIQAg";
        private const string achiv2 = "CgkIhdfM5YASEAIQAw";
        private const string achiv3 = "CgkIhdfM5YASEAIQBA";
        private const string achiv4 = "CgkIhdfM5YASEAIQBQ";
        private const string achiv5 = "CgkIhdfM5YASEAIQBg";
        private const string achiv6 = "CgkIhdfM5YASEAIQBw";
        private const string achiv7 = "CgkIhdfM5YASEAIQCA";

        private const string leaderboard= "CgkIhdfM5YASEAIQAQ";


        private int level_coin_podret;

        private bool is_normal;//true-rejim normal //false-rejim hard 
        private int CHETCHIK_type_game;
        public Dropdown dw;//выпадающий список
        public Text tt;//лабейл
        public Image play_img;
        public Sprite play1;//картинки для кнопки
        public Sprite play2;
        public Text ttt1;
        public Text ttt2;//тексты
        
        public void BTN_KONKURS_PLAY()
        {
            KONKURS_play.SetActive(true);
        }

        public void BTN_HELPED()
        {
            HELPED.SetActive(true);
        }
        public void BTN_ADD_MANI()
        {
            OOPS.SetActive(true);
        }
        public void BTN_ADD_video()
        {
           
        }
        public void ALL_FRUKTIS()
        {
            Get_Achivments(GPGSIds.achievement_5);
        }
        public void BTN_KLOSE_MAN_VIDEO()
        {
            OOPS.SetActive(false);
        }

        private void BTN_PEREKLICHATEL_REJIM(int id)
        {
            Debug.Log(id);
            if (id == 0)
            { 
               
                Debug.Log("Normal");
                tt.color = new Color32(146,255,166,255);
                play_img.sprite = play1;
                ttt1.gameObject.SetActive(true);
                ttt2.gameObject.SetActive(false);
                is_normal = true;
                max_coin=max_coin;
              //  dw.value = 0;
            }
            else if (id == 1)
            {
               
                Debug.Log("HARD");
                tt.color = new Color32(255, 200, 191, 255);
                play_img.sprite = play2;
                ttt1.gameObject.SetActive(false);
                ttt2.gameObject.SetActive(true);
                is_normal = false;
                max_coin_hard = max_coin_hard;
                // dw.value = 1;
            }
          
            NACH_LEVEL();
        }
       

        public void SPISOK()
        {
            BTN_PEREKLICHATEL_REJIM(dw.value);
            CHETCHIK_type_game = dw.value;
        }

        public void GEN_BASGROUND()
        {
            int i = UnityEngine.Random.Range(0,5);
            sr1.sprite = bg[i];
            sr2.sprite = bg[i];
        }
        //public static PlayGamesPlatform platform;
       // public Text test;
        public void Method(string param)
        {
            play_podscazka.GetComponent<Text>().text = param;
        }
        void Start()
        {
            GEN.issladost = new bool[] { true,true,true};
           //is_normal = true;  //в начале обычный режим
           CHETCHIK_type_game = 0;
          
            //   sv= new Save();
            is_musik =true;
            is_zvik = true;
            lv = 1;
            load_date(); 
           
            GEN.ismenu = true;
            menu.SetActive(true);
            game.SetActive(false);
            pause.SetActive(false);
            
            BTN_PEREKLICHATEL_REJIM(CHETCHIK_type_game);

           // NACH_LEVEL();
            GEN.isactiv = true;
            BTN_Misik(0);
            BTN_Zvik(0);
            GEN_BASGROUND();

            
            if (platform == null)
            {
               // test.text = test.text + "777";
                PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
                PlayGamesPlatform.InitializeInstance(config);
                PlayGamesPlatform.DebugLogEnabled = true;

                platform = PlayGamesPlatform.Activate();
            }
            Social.Active.localUser.Authenticate(success =>
            {
                if (success)
                {
                   // test.text = test.text + "+";
                }
                else
                {
                  //  test.text = test.text + "-";
                }
            });
            
            ///////////////////////////////
            ///
            /*
            Appodeal.initialize("1e10cce216e7390fa8fa0bf6de8434e54a28924c228f172e", Appodeal.BANNER | Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO, true);
            if (Appodeal.isLoaded(Appodeal.BANNER))
            {
                Appodeal.show(Appodeal.BANNER_BOTTOM);
            }
            */
            // test.text = "999";
            /*
            if (platform == null) {
                PlayGamesClientConfiguration config =new PlayGamesClientConfiguration.Builder().Build();
                PlayGamesPlatform.InitializeInstance(config);
                PlayGamesPlatform.DebugLogEnabled = true;
                platform = PlayGamesPlatform.Activate();
            }
            */
            // Рекомендовано для откладки:
            //   PlayGamesPlatform.DebugLogEnabled = true;
            // Активировать Google Play Games Platform
            // PlayGamesPlatform.Activate();

            /*
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;

            PlayGamesPlatform.Activate();

            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
            */
            // handle results

            //   });
            //  Max_COIN.text = "vvv";
            /*
              Social.localUser.Authenticate((bool success) => {
                  // Удачно или нет?
                  if (success)
                  {
                      //удачно
                      test.text = "5";
                  }
                  else
                  {
                      //не удачно 
                      test.text = "2";
                  }
              });
              */

        }
        
        #region Achivments
        private void Get_Achivments(String id)
        {
            //регулярное
            Social.ReportProgress(id, 100.0f, (bool success) => {
                // handle success or failure
            });
        }
        private void Get_Inkremebt_Achivments(string id,int step)
        {

            PlayGamesPlatform.Instance.IncrementAchievement( id, step, (bool success) => {
            // handle success or failure
        });
        

        }
        #endregion

        #region LiderBords

        private void Get_score(String id,int score)
        {
            Social.ReportScore(score, id, (bool success) => {
                // handle success or failure
            });
        }
        #endregion 

            //вКЛЮЧНИЕ ВЫКЛЮЧЕНИЕ НАСТРОЕК
        public void BTN_SETTING_UP()
        {
            Setting.SetActive(true);
            dw.value = CHETCHIK_type_game ;
        }
        public void BTN_SETTING_DOWN()
        {
            Setting.SetActive(false);
            HELPED.SetActive(false);
            OOPS.SetActive(false);
        }
        //вКЛЮЧНИЕ ВЫКЛЮЧЕНИЕ магаза
        public void BTN_SHOP_UP()
        {
           
            SHOP.SetActive(true);
        }
        public void BTN_SHOP_DOWN()
        {
            SHOP.SetActive(false);
            SHOPmani.SetActive(false);
        }


        public void Vozrajdenie()
        {
            //запуск ролика
            //Appodeal.show(Appodeal.NON_SKIPPABLE_VIDEO);
            /*
            if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
            {
                Appodeal.setRewardedVideoCallbacks(this);
                Appodeal.show(Appodeal.REWARDED_VIDEO);
            }
            */
            /*
             BTN_PLAY();
            // GEN.ismenu = false;
            ISPLAY = false;
            //  GEN.isactiv = false;
           // GEN.ismenu = true;
            // Invoke("GEN_TIME", 3.5f);
            game_over.SetActive(false);
            //призрачная удача
            afekt_life.Play();
            */

        }
        //метод вызывается при старте игры и при прохождение уровня 
        //генерирует начальные параметры уровня
        
            //отвечает за параметры сложности
        public void NACH_LEVEL()
        {
            if (is_normal)
            {
                LEVEL_COIN = OBj_LEN();//возврощает длину уровня
                Gen_obj.GEN_obj();//возвращает массив сладостей


                float dmin = UnityEngine.Random.Range(50, 100);
                dmin /= 100;



                float dmax = UnityEngine.Random.Range(100, 200);
                dmax /= 100;
                GEN.DelayMin = dmin;
                GEN.DelayMax = dmax;
            }
            else
            {
                LEVEL_COIN = OBj_LEN();
                Gen_obj.GEN_obj();


                float dmin = UnityEngine.Random.Range(15, 40);
                dmin /= 100;



                float dmax = UnityEngine.Random.Range(40, 70);
                dmax /= 100;
                GEN.DelayMin = dmin;
                GEN.DelayMax = dmax;
            }
            
        }
        #region HARD_REJIM
        public void BTN_VIBOR_REJIMA(int id)
        {
            if (id==1)
            {
                //нормальный режим
                is_normal = true;

            }else if (id == 2)
            {
                //хард режим
                is_normal = false;
            }
        }

        #endregion

        public ParticleSystem afekt_life;

        public int shans_fozrojdenie;
        public void VOZMOJNO_GAME_over()
        {
            if (ISPLAY)
            {
                ///реально конец игры 
                //проверяем шанс на возраждения купленный бонусы
               if (UnityEngine.Random.Range(0,102-shans_fozrojdenie)==1)
                {
                    //призрачная удача
                    afekt_life.Play();
                  //  Debug.Log("/////");
                }
                else {
                    GAME_OVER();
                }
                
            }
        }
        //Метод вызывается при прохождение уровня
        public void Pobeda()
        {
            /*
            if (Appodeal.isLoaded(Appodeal.BANNER))
            {
                Appodeal.show(Appodeal.BANNER_BOTTOM);
            }
            */
            GEN_BASGROUND();
            Saund_musik.volume = 0.25f;
            ISPLAY = false;
            Level_up_text.text = "LEVEL " + lv;
            lv++;
            Mau.enabled = false;
            NACH_LEVEL();
           
           // Debug.Log("Level up!");
            Level_up.SetActive(true);
            Invoke("EFECT", 1f);
          
            GEN.isactiv = false;
            level_coin_podret++;
            if (level_coin_podret==1)
            {
                //первопроходец
               Get_Achivments(GPGSIds.achievement);
            }
            else if (level_coin_podret == 5)
            {
                //профи
               Get_Achivments(GPGSIds.achievement_2);
            }
            else if (level_coin_podret == 10)
            {
                //мастер
               Get_Achivments(GPGSIds.achievement_3);
            }
            else if (level_coin_podret == 15)
            {
                //гранд мастер
                Get_Achivments(GPGSIds.achievement_4);
            }
            lv_step.MOVE_MARKER();

        }
        public void EFECT()
        {
           ef1.Play();
            ef2.Play();
        }
        //метод вызывается при смерти
        private int chetchik_smerti;
        private int constpr=4;
        public GameObject img_tap_podskazka;//гейм обжект с 
        public GameObject play_podscazka;//текст который виден при отображение подсказки
        public Sprite[] help_img;//спрайт картинки отображаемой при подсказки
        public SpriteRenderer helping_img;//картинка отображаемая при помощи
      //  public Text HELP_TEXT;//
        public void PLAY_PODSKAZKA() {
            img_tap_podskazka.SetActive(false);
            play_podscazka.SetActive(false);
            //Time.timeScale = 1f;
            //Time.timeScale = 1;
        }
        
        public void GAME_OVER()
        {

           
            chetchik_smerti++;
            if (chetchik_smerti == constpr)
            {
                constpr += 4;
                /*
                if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
                {
                    Appodeal.show(Appodeal.INTERSTITIAL);
                }
                */
            }
            level_coin_podret = 0;
            /*
            if (GEN.isactiv == true) {
                
             //   COIN.GetComponent<Animation>().enabled = true;
                COIN.GetComponent<Animation>().Play();
            }
            */
            // Debug.Log("////");
            // Saund_musik.enabled = false; 

            Saund_musik.volume = 0.25f;
            game_over.SetActive(true);
            GEN.isactiv = false;
            //Time.timeScale = 0;
            Mau.enabled = false;
            if (coin_normal > max_coin)
            {
               
                //Get_score(GPGSIds.ReferenceEquals,);
                if (is_normal)
                { 
                    max_coin = coin_normal;
                   Get_score(GPGSIds.leaderboard_king_of_the_sweets_crush_normal,max_coin);
                }else if (is_normal==false)
                {
                    max_coin_hard = coin_normal;
                    Get_score(GPGSIds.leaderboard_king_of_the_sweets_crush_hard, max_coin_hard);
                }
               
            }
            /*
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                //Change the Text //нет сети
               // "Not Reachable.";

            }
            //Check if the device can reach the internet via a carrier data network
            else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
            {
                // "Reachable via carrier data network."; глобальная интернет
                btn_restart.SetActive(true);
                btn_restart.GetComponent<Animation>().Play();
            }
            //Check if the device can reach the internet via a LAN
            else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                // "Reachable via Local Area Network."; локальная
                btn_restart.SetActive(true);
                btn_restart.GetComponent<Animation>().Play();
            }
            */


          //  btn_restart.SetActive(true);
           // btn_restart.GetComponent<Animation>().Play();
           /*
            if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
            {
                btn_restart.SetActive(true);
                btn_restart.GetComponent<Animation>().Play();

            }
            else
            {
               
            }
            if (Appodeal.isLoaded(Appodeal.BANNER))
            {
                Appodeal.show(Appodeal.BANNER_BOTTOM);
            }
           */

        }
        private void GEN_TIME()
        {
            ISPLAY = true;
            GEN.isactiv = true;
            Mau.enabled = true;
            //Debug.Log("gggg");
            
        }
        private int OBj_LEN()
        {
            int a = 5;//31
            if (lv <= 30)
            {
                a += lv;
            }
            else
            {
                a = 30;

                for (int i = 0; i < lv; i++)
                {
                    if (UnityEngine.Random.Range(0, 3) == 1)
                    {
                        a++;
                    }
                }
            }
            return a;
        }
         //метод вызывается при старте уровня 
        private void LEVEL_START()
          {
           lv_controller.value = 0;
            GEN.T_obj = 0;
          
            GEN.Max_obj = LEVEL_COIN;
            lv_controller.maxValue = LEVEL_COIN;
            LV_START.text = lv+"";
            LV_END.text = (lv+1) + "";

        }

        //при нажатие нопки начать
        public void BTN_PLAY()
        {
            // bascground.sprite = bacground_LV;
            bascground.gameObject.SetActive(false);
            GEN.ismenu = false;
            GEN.isactiv = false;
            Invoke("GEN_TIME", 3.5f);
            menu.SetActive(false);
            game.SetActive(true);
            Level_up.SetActive(false);
            LEVEL_START();
            Level_pokaz.GetComponent<Text>().text = "Level " + lv;
            Level_pokaz.GetComponent<Animation>().Play();
            //GEN.GetComponent<D2dThrower>().Max_obj = 5;
            Saund_musik.volume = 1f;
            // COIN.GetComponent<Animation>().enabled = false;
            //  RectTransform ggg;
            // COIN.GetComponent<RectTransform>().rect = ggg;
         //   Appodeal.hide(Appodeal.BANNER);
           
        }


        //при запуске паузы 
        public void BTN_PAUSE_UP()
        {
            pause.SetActive(true);
            Time.timeScale = 0;
            // Debug.Log("///");
            /*
            if (Appodeal.isLoaded(Appodeal.BANNER))
            {
                Appodeal.show(Appodeal.BANNER_BOTTOM);
            }
            */

        }
        //при возвращение с паузы
        public void BTN_PAUSE_DOWN()
        {
            pause.SetActive(false);
            Time.timeScale = 1;
          //  Appodeal.hide(Appodeal.BANNER);

        }
        
        //кнопка из паузы в меню 
        public void BTN_MENU_PLAY()
        {
            // Saund_musik.enabled = true;
            Saund_musik.volume = 1;
            //bascground.sprite = bacground_MENU;
            bascground.gameObject.SetActive(false);
            GEN.ismenu = true;
            game_over.SetActive(false);
            game.SetActive(false);
            menu.SetActive(true);
            Time.timeScale = 1;
            pause.SetActive(false);
            Mau.enabled = false;
            ISPLAY = false;
            coin_normal = 0;
            GEN.isactiv = true;

            KONKURS_play.SetActive(false);
            /*
            if (Appodeal.isLoaded(Appodeal.BANNER))
            {
                Appodeal.show(Appodeal.BANNER_BOTTOM);
            }
            */



            //SceneManager.LoadScene("Game");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        }

        // Update is called once per frame
        /*
        void Update()
        {

        }
        */
        public void Method_Bonus_TIME()
        {
         //   Debug.Log("fff");
            SFX_ZAMEDLENIE.SetActive(true);
            Time.timeScale = 0.5f;
            //время действия бонуса
            Invoke("B_TIME", 5f);


        } 
        /// <summary>
        /// 
        /// </summary>
        /// решение проблемы с одновременным бонусом
        public void B_TIME()
        {
            SFX_ZAMEDLENIE.SetActive(false);
            Time.timeScale = 1f;
        } 
       
        public void BTN_LIDER_UI_ACTIV()
        {
            
            // Показать список достижений.
            Social.ShowAchievementsUI();
        }
        public void BTN_DOST_UI_ACTIV()
        {
           Social.ShowLeaderboardUI();
            
        }


        public void Save_date()
        {
            //  PlayGamesPlatform.Instance.SignOut();
            ushort secretKey = 0x0088; // Секретный ключ (длина - 16 bit).


            string str = "Hello World"; //это строка которую мы зашифруем

            str = EncodeDecrypt(str, secretKey); //производим шифрование
            Console.WriteLine(str);  //выводим в консоль зашифрованную строку

            str = EncodeDecrypt(str, secretKey); //производим рассшифровку 
            Console.WriteLine(str);             //выводим в консоль расшифрованную строкуё
            sv.MANI = mani;
            sv.LV = lv;
            sv.MAX_COIN = max_coin;
            sv.MAX_COIN_HARD = max_coin_hard;
            sv.is_musik=is_musik ;
            sv.is_zvyk =is_zvik ;
            sv.type_game = CHETCHIK_type_game;
            sv.HELPED_ID=GEN.issladost;
            File.WriteAllText(path, JsonUtility.ToJson(sv));
        }


        
           


        public static string EncodeDecrypt(string str, ushort secretKey)
        {
            var ch = str.ToCharArray();  //преобразуем строку в символы
            string newStr = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)  //выбираем каждый элемент из массива символов нашей строки
                newStr += TopSecret(c, secretKey);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            return newStr;
        }

        public static char TopSecret(char character, ushort secretKey)
        {
            character = (char)(character ^ secretKey); //Производим XOR операцию
            return character;
        }

        public void load_date()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
                path=Path.Combine(Application.persistentDataPath, "save.json");
#else
            path = Path.Combine(Application.dataPath, "save.json");
#endif
            if (File.Exists(path))
            {
                sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
                lv= sv.LV;
                mani = sv.MANI;
                max_coin = sv.MAX_COIN;
                max_coin_hard = sv.MAX_COIN_HARD;

                is_musik =sv.is_musik;
                is_zvik=sv.is_zvyk;
                CHETCHIK_type_game = sv.type_game;
                GEN.issladost=sv.HELPED_ID;



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
            //throw new NotImplementedException();
            BTN_PLAY();
            // GEN.ismenu = false;
            ISPLAY = false;
            //  GEN.isactiv = false;
            // GEN.ismenu = true;
            // Invoke("GEN_TIME", 3.5f);
            game_over.SetActive(false);
            //призрачная удача
            afekt_life.Play();
        }

        public void onRewardedVideoFinished(double amount, string name)
        {
            //
            /*
            BTN_PLAY();
            // GEN.ismenu = false;
            ISPLAY = false;
            //  GEN.isactiv = false;
            // GEN.ismenu = true;
            // Invoke("GEN_TIME", 3.5f);
            game_over.SetActive(false);
            //призрачная удача
            afekt_life.Play();
            */
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
        public class Save
        {

            public int MANI;
            public int MAX_COIN;
    public int MAX_COIN_HARD;

    public int LV;

            public bool is_musik;
            public bool is_zvyk;

            public int type_game;
    public bool[] HELPED_ID;
        // public 



        }
        
