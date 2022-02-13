using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class UnityStringEvent : UnityEvent<string> { }

[CreateAssetMenu(menuName = "Managers/SceneManager")]
public class SceneMaster : ScriptableObject
{
    [SerializeField] FloatReference transitionDuration;
    // [SerializeField]
    // UnityStringEvent onSceneLoaded;
    //
    // [SerializeField]
    // UnityStringEvent onSceneUnloaded;
    //
    // [SerializeField]
    // UnityStringEvent beforeSceneUnloaded;
    //
    // void OnEnable()
    // {
    //     // SceneManager.sceneLoaded += OnSceneLoaded;
    //     // SceneManager.sceneUnloaded += OnSceneUnloaded;
    // }

    // void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     Debug.Log("OnSceneLoaded: " + scene.name + " Mode: " + mode);
    //     onSceneLoaded.Invoke(scene.name);
    // }
    //
    // void OnSceneUnloaded(Scene scene)
    // {
    //     Debug.Log("OnSceneUnloaded: " + scene.name);
    //     onSceneUnloaded.Invoke(scene.name);
    // }

    // void OnDisable()
    // {
    //     // SceneManager.sceneLoaded -= OnSceneLoaded;
    // }

    public void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ReloadSceneWithFade()
    {
        LoadSceneWithFade(SceneManager.GetActiveScene().name);
    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void LoadScene(SceneData data)
    {
        LoadScene(data.SceneName);
    }

    public void LoadSceneWithFade(string sceneName)
    {
        CoroutineManager.Instance.StartCoroutine(IeLoadFade(sceneName));
    }
    
    public void LoadSceneWithFade(SceneData data)
    {
        CoroutineManager.Instance.StartCoroutine(IeLoadFade(data.SceneName));
    }

    IEnumerator IeLoadFade(string sceneName)
    {
        yield return CoroutineManager.Instance.StartCoroutine(FadeLoader.Instance.FadeInF(transitionDuration.Value));
        SceneManager.LoadScene(sceneName);
    }
}
