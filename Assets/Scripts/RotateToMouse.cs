using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

public class RotateToMouse : MonoBehaviour
{
    [SerializeField] private InputReader m_oInputReader;
    [SerializeField]
    Transform shotPoint;
    [SerializeField, MinMaxSlider(0, 50, true)]
    Vector2 launchForceRange;

    [SerializeField]
    GameObject point;
    [SerializeField]
    int numberOfPoints;
    [SerializeField]
    float spaceBetweenPoints;

    float launchForce = 10;
    GameObject[] points;
    Vector2 direction;
    
    bool bIsAim;
    string currentControlScheme = "Keyboard";

    private Rigidbody2D rb2d;

    void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; ++i)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
            points[i].SetActive(false);
        }

        if (!TryGetComponent(out rb2d))
        {
            Debug.LogError("Cannot get Rigidbody2D");
        }
    }
    
    void OnEnable()
    {
        m_oInputReader.AimEvent_Begin += AimBegin;
        m_oInputReader.AimEvent_End += AimEnd;
        m_oInputReader.AimEvent_Hold += Look;
    }
    
    void OnDisable()
    {
        m_oInputReader.AimEvent_Begin -= AimBegin;
        m_oInputReader.AimEvent_End -= AimEnd;
        m_oInputReader.AimEvent_Hold -= Look;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bIsAim)
            return;

        for (int i = 0; i < numberOfPoints; ++i)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }

    void Propulse()
    {
        rb2d.velocity = transform.right * launchForce;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }
    
    public void AimBegin(bool value)
    {
        bIsAim = value;

        for (int i = 0; i < numberOfPoints; ++i)
        {
            points[i].SetActive(bIsAim);
        }
    }
    
    public void AimEnd()
    {
        for (int i = 0; i < numberOfPoints; ++i)
        {
            points[i].SetActive(false);
        }

        Propulse();
    }

    public void Look(Vector2 value)
    {
        if (value != Vector2.zero)
        {
            if (currentControlScheme == "Keyboard")
            {
                Vector2 bowPosition = transform.position;
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(value);
                direction = mousePos - bowPosition;
                transform.right = direction;
                launchForce = Mathf.Clamp(Vector2.Distance(bowPosition, mousePos), launchForceRange.x, launchForceRange.y);
            }
            else
            {
                direction = value;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
                launchForce = Mathf.Clamp(Vector2.Distance(Vector2.zero, value * launchForceRange.y), launchForceRange.x, launchForceRange.y);
            }
        }
    }

    public void OnDeviceChange(UnityEngine.InputSystem.PlayerInput input)
    {
        currentControlScheme = input.currentControlScheme;
    }
}
