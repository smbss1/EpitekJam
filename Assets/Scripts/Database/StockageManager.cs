using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockageManager : MonoBehaviour
{
    public List<int> SuccessList = new List<int>();
    public int DeblockedLevel = 1;

    [System.NonSerialized]
    public Text countSuccess;

    public static StockageManager instance;

    private Database database;

    private void Awake()
    {
        if (instance != null)
            Debug.Log("pas bon là");
        instance = this;
    }

    void Start()
    {
        database = new Database("Stockage.json", this);
        AddSuccess(0);
    }

    public void AddSuccess(int id)
    {
        if (!SuccessList.Contains(id))
            SuccessList.Add(id);
        database.SaveData();
    }

    public void AddDeblockedLevel(int level)
    {
        if (DeblockedLevel == level)
        {
            DeblockedLevel++;
            database.SaveData();
        }
    }
}
