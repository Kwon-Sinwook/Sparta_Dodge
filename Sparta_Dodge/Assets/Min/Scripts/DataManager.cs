using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private string path;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        path = Application.dataPath + "/save.json";
    }

    public void Save(Data data)
    {
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(path, json);
    }

    public Data Load()
    {
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);

            Data data = JsonUtility.FromJson<Data>(json);

            return data;
        }
        else
        {
            return new Data();
        }
    }
}
