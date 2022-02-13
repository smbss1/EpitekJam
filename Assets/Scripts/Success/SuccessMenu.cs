using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessMenu : MonoBehaviour
{
    public GameObject PrefabsSuccessContent;
    public Transform Parent;

    private void OnEnable()
    {
        foreach (int id in StockageManager.instance.SuccessList)
        {
            if (id < 0 || SuccessStocker.instance.successes.Length <= id)
                continue;
            Debug.Log(SuccessStocker.instance.successes.Length + " " + id);
            GameObject SuccessContent = Instantiate(PrefabsSuccessContent, Parent);
            SuccessObject information = SuccessStocker.instance.successes[id];
            SuccessContent.GetComponent<SuccessContent>().MakeDetailSuccess(information.title, information.description);
        }
    }
}
