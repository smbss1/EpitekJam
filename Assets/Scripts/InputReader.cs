using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


[CreateAssetMenu(menuName = "Fox")]
public class InputReader : ScriptableObject
{
    Inputs m_oInputs;
    
    public event UnityAction<bool> AimEvent_Begin = delegate { };
    public event UnityAction<Vector2> AimEvent_Hold = delegate { };
    public event UnityAction AimEvent_End = delegate { };
    public event UnityAction InteractEvent = delegate { };
    public event UnityAction PauseEvent = delegate { };

    private void OnEnable()
    {
        if (m_oInputs == null)
        {
            m_oInputs = new Inputs();
            
            m_oInputs.Player.Pause.performed += Pause;
            m_oInputs.Player.Interact.performed += Interact;

            m_oInputs.Player.Aim.performed += (InputAction.CallbackContext ctx) => {
                AimEvent_Begin.Invoke(ctx.ReadValueAsButton());
            };
            m_oInputs.Player.Aim.canceled += (InputAction.CallbackContext ctx) => {
                AimEvent_End.Invoke();
            };
            m_oInputs.Player.Aim_Hold.performed += (InputAction.CallbackContext ctx) => {
                AimEvent_Hold.Invoke(ctx.ReadValue<Vector2>());
            };
        }
        m_oInputs.Enable();
    }
    
    private void OnDisable()
    {
        m_oInputs.Disable();
    }
    
    void Interact(InputAction.CallbackContext ctx)
    {
        InteractEvent.Invoke();
    }
    
    void Pause(InputAction.CallbackContext ctx)
    {
        PauseEvent.Invoke();
    }
}