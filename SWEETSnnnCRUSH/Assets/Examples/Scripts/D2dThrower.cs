using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;


namespace Destructible2D
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(D2dThrower))]
	public class D2dThrower_Editor : D2dEditor<D2dThrower>
	{
		protected override void OnInspector()
		{
			BeginError(Any(t => t.DelayMin < 0.0f || (t.DelayMin > t.DelayMax)));
				DrawDefault("DelayMin");
			EndError();
			BeginError(Any(t => t.DelayMax < 0.0f || (t.DelayMin > t.DelayMax)));
				DrawDefault("DelayMax");
			EndError();
			BeginError(Any(t => t.SpeedMin < 0.0f || (t.SpeedMin > t.SpeedMax)));
				DrawDefault("SpeedMin");
			EndError();
			BeginError(Any(t => t.SpeedMax < 0.0f || (t.SpeedMin > t.SpeedMax)));
				DrawDefault("SpeedMax");
			EndError();
			BeginError(Any(t => t.Spread < 0.0f));
				DrawDefault("Spread");
			EndError();
			
			
			BeginError(Any(t => t.ThrowPrefabs == null || t.ThrowPrefabs.Length > 0));
				DrawDefault("ThrowPrefabs");
			EndError();


			BeginError(Any(t => t.Bonus == null || t.Bonus.Length > 0));
			DrawDefault("Bonus");
			EndError();

			 BeginError(Any(t => t.Bomba == null || t.Bomba.Length > 0));
			DrawDefault("Bomba");
			EndError();

			BeginError(Any(t => t.help_text == null || t.help_text.Length > 0));
			DrawDefault("help_text");
			EndError();

			BeginError(Any(t => t.Alphavit == null || t.Alphavit.Length > 0));
			DrawDefault("Alphavit");
			EndError();
		}
	}
}
#endif

namespace Destructible2D
{
	// This component throws random prefabs upwards
	[AddComponentMenu(D2dHelper.ComponentMenuPrefix + "Thrower")]
	public class D2dThrower : MonoBehaviour
	{
		[Tooltip("The minimum delay between throws in seconds")]
		public float DelayMin = 0.5f;

		[Tooltip("The maximum delay between throws in seconds")]
		public float DelayMax = 2.0f;

		[Tooltip("The minimum speed of the thrown object")]
		public float SpeedMin = 10.0f;

		[Tooltip("The maximum speed of the thrown object")]
		public float SpeedMax = 20.0f;

		[Tooltip("Maximum degrees spread when throwing")]
		public float Spread = 10.0f;
       
		[Tooltip("The prefabs that can be thrown")]
		public GameObject[] ThrowPrefabs;

		[Tooltip("The prefabs that can Bonus")]
		public GameObject[] Bonus;
		[Tooltip("The prefabs that can Bomba")]
		public GameObject[] Bomba;
		[Tooltip("The prefabs that can Alphavit")]
		public GameObject[] Alphavit;

		// Seconds until next spawn
		[SerializeField]
		private float cooldown;

		public bool isactiv;
		public bool ismenu;//тру если мы находимся в меню фалсе если началась игра

		[Tooltip("coin prefabs spawn")]
		public int Max_obj;
		public int T_obj;

		private UI_Control ui_con;

		public int shans_spavn_bonus;
		public int shans_spavn_bomba;
		/// <summary>
		/// 
		private void Start()
		{
			ui_con = GameObject.Find("Canvas").GetComponent<UI_Control>();
			//issladost = new bool[3];
			//issladost[0] = true;
			//issladost[1] = true;
			//	issladost[2] = true;
			//Debug.Log(issladost[0]);

		}
		[Tooltip("Text helped")]
		public string[] help_text;//массив текста для отображения в помощи
		int id_help;//ид подсказки
		//метод для спавна изображения в нужной позиции используя соостветсвующий тайм-аут
		public void SPAVN_GIF()
		{
			if (id_help==1)
			{
				ui_con.helping_img.sprite = ui_con.help_img[1];
			}
			else
			{
				ui_con.helping_img.sprite = ui_con.help_img[0];
			}
			ui_con.Method(help_text[id_help]);
			//ggg = Camera.main.ScreenToWorldPoint(mmm.transform.position);

			//ui_con.img_tap_podskazka.transform.localPosition= ui_con.fffff.transform.TransformPoint(mmm.transform.position);
			// new Vector3(mmm.transform.position.x, mmm.transform.position.y, 0);
			// mmm.transform.position;
			//Debug.Log(""+ ui_con.fffff.transform.TransformPoint(mmm.transform.position));
			ui_con.img_tap_podskazka.transform.position = mmm.transform.position;
			ui_con.img_tap_podskazka.gameObject.SetActive(true);
			ui_con.play_podscazka.gameObject.SetActive(true);
			Time.timeScale = 0f;
			
		}
		GameObject mmm;
		Vector3 ggg;
		//= ui_con.img_tap_podskazka
		
		public bool[] issladost;

		public ulong bomba_coin;
		

		protected virtual void Update()
		{
			if (isactiv)
			{
				cooldown -= Time.deltaTime;

				if (cooldown <= 0.0f)
				{
					cooldown = Random.Range(DelayMin, DelayMax);
					//Debug.Log(ismenu);
					if (Max_obj>0|| ismenu) {
						if (ismenu == false)
						{
							Max_obj--;
							T_obj++;
							ui_con.lv_controller.value = T_obj;
						}
						if (ThrowPrefabs != null && ThrowPrefabs.Length > 0)
						{
							var prefab = ThrowPrefabs[0]; ;
							GameObject instance;
							
							
						//	Debug.Log(UnityEngine.Random.Range(0, 10 - UnityEngine.Mathf.Round(shans_spavn_bonus / 5)));
							if (UnityEngine.Random.Range(0,20- UnityEngine.Mathf.Round(shans_spavn_bonus / 10)) <= 1)
							{
								//генерируем бонус
								var index = Random.Range(0, Bonus.Length);
								prefab = Bonus[index];
								instance = Instantiate(prefab);
								instance.name = "a";
								if (ismenu)
								{

								}
								else
								{
									if (issladost[2])
									{
										id_help = 2;
										mmm = instance;
										Invoke("SPAVN_GIF", 0.3f);
										issladost[2] = false;


									}
								}
								//Debug.Log("//// "+ UnityEngine.Mathf.Round(shans_spavn_bonus / 5));
							}else
							if (UnityEngine.Random.Range(0, 15 + UnityEngine.Mathf.Round(shans_spavn_bomba / 10)) <= 1)
							{
								//генерируем бomba
								var index = Random.Range(0, Bomba.Length);
								prefab = Bomba[index];
								instance = Instantiate(prefab);
								instance.name = "a";
								if (ismenu)

								{
									
								}
								else {
									if (issladost[1])
									{
										id_help = 1;
										mmm = instance;
										Invoke("SPAVN_GIF", 0.3f);
										issladost[1] = false;


									}
								}
								//Debug.Log("//// " + UnityEngine.Mathf.Round(shans_spavn_bonus / 5));
							}else if (UnityEngine.Random.Range(0, bomba_coin)==7)
							{
								//генерируем бонус
								var index = Random.Range(0, Alphavit.Length);
								prefab = Bonus[index];
								instance = Instantiate(prefab);
								instance.name = "a";
								if (ismenu)
								{

								}
								else
								{
									if (issladost[2])
									{
										id_help = 2;
										mmm = instance;
										Invoke("SPAVN_GIF", 0.3f);
										issladost[2] = false;


									}
								}
							}
							else
							{
								var index = Random.Range(0, ThrowPrefabs.Length);
								prefab = ThrowPrefabs[index];
								instance = Instantiate(prefab);
								if (ismenu)
								{
									instance.name = "a";
									
								}
								else
								{
									Debug.Log(issladost[0]);
									if (issladost[0])
									{
										id_help = 0;
										mmm = instance;
										Invoke("SPAVN_GIF", 0.3f);
										issladost[0] = false;


									}
								}
								if (UnityEngine.Random.Range(0,15000)==777)
								{
									ui_con.ALL_FRUKTIS();
								}
							}

							/*
							if (UnityEngine.Random.Range(0,30- UnityEngine.Mathf.Round(shans_spavn_bonus/5)) ==1)
							{
								//генерируем бонус
                                var index = Random.Range(0, Bonus.Length);
								prefab = Bonus[index];
								instance = Instantiate(prefab);

							 	instance.name = "a";
							}
							else
							{
								
						     	var index = Random.Range(0, ThrowPrefabs.Length);
						     	prefab = ThrowPrefabs[index];
								instance = Instantiate(prefab);
								if (ismenu)
								{
									instance.name = "a";
								}
							}
							*/

							//var instance = Instantiate(prefab);
							instance.transform.localScale = new Vector3(0.75f, 0.75f, 1);

							var rigidbody = instance.GetComponent<Rigidbody2D>();

							instance.transform.position = transform.position;
							//instance.AddComponent<CircleCollider2D>();
							if (rigidbody != null)
							{
								var angle = Random.Range(-0.5f, 0.5f) * Spread * Mathf.Deg2Rad;
								var speed = Random.Range(SpeedMin, SpeedMax);

								rigidbody.velocity = new Vector2(Mathf.Sin(angle) * speed, Mathf.Cos(angle) * speed);
								rigidbody.angularVelocity = Random.Range(-180.0f, 180.0f);
							}
						}
					}
					else
					{
						
							//Debug.Log(Max_obj);
							//Это победа левел пройден
							ui_con.Pobeda();
							Max_obj = 0;
					    	isactiv = false;


					}
				}
			}
		}
	}
}