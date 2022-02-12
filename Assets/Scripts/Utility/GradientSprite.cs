using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class GradientSprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] FloatReference duration;
    [SerializeField] Gradient gradient;

    private float timer;
    
    public void UpdateUI()
    {
        timer += Time.deltaTime / duration.Value;
        renderer.color = gradient.Evaluate(Mathf.Min(timer, 1));
    }

    public void Restart()
    {
        timer = 0;
    }
    
    public void SetDuration(float dur)
    {
        duration.Value = dur;
    }
}
