using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class AHSave : MonoBehaviour
{
    /*
    public GameObject namePan;

    public Save sv = new Save();
    private string path;

    private void Start()
    {

    }
    public void LOAD()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
        if (File.Exists(path))
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
           // Debug.Log("Добро пожаловать: " + sv.name + "\nВаш возраст: " + sv.age);
        }
        else
        {
          //  namePan.SetActive(true);
        }
    }

  
#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause) File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
#endif
    private void OnApplicationQuit()
    {
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
    */
}
/*
[Serializable]
public class Save
{
    public int MANI;
    public int MAX_COIN;
    public int LV;
}
*/