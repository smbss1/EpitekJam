using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessCount : MonoBehaviour
{
    public Text count;

    private void Start()
    {
        count.text = StockageManager.instance.SuccessList.Count.ToString();
    }
}
