using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public string NameLevel;
    public int LevelId;
    public Image image;
    public Button button;

    private Color green = new Color(0.52f, 0.8711f, 0.4755f, 1);

    private void Start()
    {
        if (LevelId <= StockageManager.instance.DeblockedLevel)
        {
            image.color = green;
            button.interactable = true;
        }
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene(NameLevel);
    }
}
