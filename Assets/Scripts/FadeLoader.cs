using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class FadeLoader : MonoBehaviour
{
    private static FadeLoader _instance;
    public static FadeLoader Instance { get { return _instance; } }

    [SerializeField] Image fadeImg;
    Coroutine FadeCoroutine;
    IEnumerator IFadeIn, IFadeOut;

    //public UnityEvent onFadeFinish;
    private float fadeLerp;
    bool onFadeComplete;
    public bool OnFadeComplete { get { return onFadeComplete; } }

    public UnityEvent onStart;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        Color t = fadeImg.color;
        t.a = 1;
        fadeImg.color = t;
    }

    void Start()
    {
        onStart.Invoke();
    }

    public void FadeIn(float dur)
    {
        //FadeCoroutine = StartCoroutine(IeFadeIn(dur));
        StartCoroutine(FadeImage(false, dur));
    }

    public IEnumerator FadeIn(string dur)
    {
        float d = 0;
        float.TryParse(dur, out d);
        //FadeCoroutine = StartCoroutine(IeFadeIn(dur));
        yield return StartCoroutine(FadeImage(false, d));
    }

    public IEnumerator FadeInF(float dur)
    {
        yield return StartCoroutine(FadeImage(false, dur));
    }

    public void FadeOut(float dur)
    {
        //FadeCoroutine = StartCoroutine(IeFadeOut(dur));
        StartCoroutine(FadeImage(true, dur));
    }

    public IEnumerator FadeOut(string dur)
    {
        float d = 0;
        float.TryParse(dur, out d);
        //FadeCoroutine = StartCoroutine(IeFadeOut(dur));
        yield return StartCoroutine(FadeImage(true, d));
    }

    public IEnumerator FadeOutF(float dur)
    {
        yield return StartCoroutine(FadeImage(true, dur));
    }

    public IEnumerator FadeImage(bool fadeOut, float duration)
    {
        fadeImg.gameObject.SetActive(true);
        // fade from opaque to transparent
        if (fadeOut)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.unscaledDeltaTime / duration)
            {
                // set color with i as alpha
                fadeImg.color = new Color(0, 0, 0, i);
                onFadeComplete = false;
                yield return new WaitForEndOfFrame();
            }
            fadeImg.gameObject.SetActive(false);
            onFadeComplete = true;
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.unscaledDeltaTime / duration)
            {
                // set color with i as alpha
                fadeImg.color = new Color(0, 0, 0, i);
                onFadeComplete = false;
                yield return new WaitForEndOfFrame();
            }
            onFadeComplete = true;
        }
    }
}
