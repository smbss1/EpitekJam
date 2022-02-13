using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public string NameLevel;

    public void OpenLevel()
    {
        SceneManager.LoadScene(NameLevel);
    }
}
