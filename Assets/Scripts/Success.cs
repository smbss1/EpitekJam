using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Success : MonoBehaviour
{
    public Text description;
    public GameObject successMenu;
    public static Success instance;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        successMenu.SetActive(false);
    }

    public void OpenSuccess(string description)
    {
        this.description.text = description;
        StartCoroutine(WaitForDelete());
    }

    IEnumerator WaitForDelete()
    {
        successMenu.SetActive(true);
        yield return new WaitForSeconds(3f);
        successMenu.SetActive(false);
    }
}
