using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class Destroyer : MonoBehaviour
{
    [SerializeField, LabelText("Start Timer")] bool m_bStartTimer = false;
    [SerializeField] float lifeTime = 2;
    [SerializeField] UnityEvent onDestroy;

    private float m_fTimer;
    
    public bool StartTimer
    {
        get { return m_bStartTimer; }
        set { m_bStartTimer = value; }
    }

    private void Start()
    {
        m_fTimer = lifeTime;
    }

    private void Update()
    {
        if (m_bStartTimer)
        {
            if (m_fTimer <= 0)
            {
                DestroyGO();
            }
            else
            {
                m_fTimer -= Time.deltaTime;
            }
        }
    }

    public void DestroyGO()
    {
        m_bStartTimer = false;
        onDestroy?.Invoke();

        Destroy(gameObject);
    }

    public void ResetTimer()
    {
        ResetTimer(lifeTime);
    }
    
    public void ResetTimer(float fLifeTime)
    {
        m_fTimer = fLifeTime;
    }
}
