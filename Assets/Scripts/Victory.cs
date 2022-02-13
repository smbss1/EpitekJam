using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Victory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
            StartCoroutine(EventEndLevel());
        }
    }

    IEnumerator EventEndLevel()
    {
        int level = int.Parse(Regex.Match(SceneManager.GetActiveScene().name, @"\d+").Value);
        StockageManager.instance.AddDeblockedLevel(level);
        Success.instance.OpenSuccess("is it epic... You are finish this level !");
        yield return new WaitForSeconds(4f);
        Success.instance.VictoryMenu.SetActive(true);
    }
}
