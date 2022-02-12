using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FadeSprite : MonoBehaviour
{
    public enum FadeMode
    {
        FromBlack,
        ToBlack,
        FromCustom,
    }

    public SpriteRenderer FullScreenFadePlane;
    [SerializeField]
    FadeMode mode;
    
    [SerializeField]
    float fadeAlpha;

    private Coroutine m_Coroutine;

    public void Fade(float duration)
    {
        if (m_Coroutine != null)
        {
            StopCoroutine(m_Coroutine);
            m_Coroutine = null;
        }

        if (duration <= 0.0f)
        {
            var color = FullScreenFadePlane.color;
            switch (mode)
            {
                case FadeMode.ToBlack:
                    color.a = 1.0f;
                    break;
                case FadeMode.FromBlack:
                    color.a = 0.0f;
                    break;
                case FadeMode.FromCustom:
                    color.a = 0.0f;
                    break;
                default: throw new NotImplementedException();
            }
            FullScreenFadePlane.gameObject.SetActive(color.a == 1.0f);
            FullScreenFadePlane.color = color;
        }
        else
        {
            switch (mode)
            {
                case FadeMode.ToBlack:
                    m_Coroutine = StartCoroutine(FadeCoroutine(duration, 1.0f, 1.0f));
                    break;
                case FadeMode.FromBlack:
                    m_Coroutine = StartCoroutine(FadeCoroutine(duration, 0.0f, -1.0f));
                    break;
                case FadeMode.FromCustom:
                    m_Coroutine = StartCoroutine(FadeCoroutine(duration, fadeAlpha, -1.0f));
                    break;
                default: throw new NotImplementedException();
            }
        }

    }

    IEnumerator FadeCoroutine(float duration, float target, float sign)
    {
        FullScreenFadePlane.gameObject.SetActive(true);
        Color c = FullScreenFadePlane.color;

        while (sign > 0 ? FullScreenFadePlane.color.a <= target : FullScreenFadePlane.color.a >= target)
        {
            c = FullScreenFadePlane.color;
            c.a += sign * Time.unscaledDeltaTime / duration;
            FullScreenFadePlane.color = c;
            yield return new WaitForEndOfFrame();
        }

        Color finalColor = FullScreenFadePlane.color;
        finalColor.a = target;
        FullScreenFadePlane.color = finalColor;
        FullScreenFadePlane.gameObject.SetActive(target != 0.0f);

        yield return new WaitForEndOfFrame();
        m_Coroutine = null;
    }
}
