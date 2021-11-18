using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.Events;

public class ButtonMap : MonoBehaviour
{

    public UnityEvent contact;
    public UnityEvent prox;
    public UnityEvent defaultState;
    public UnityEvent action;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ButtonController>().InteractableStateChanged.AddListener(InitiateEvent);
    }

    void InitiateEvent(InteractableStateArgs state)
    {
        if(state.NewInteractableState == InteractableState.ContactState)
        {
            contact.Invoke();
        }
        if(state.NewInteractableState == InteractableState.ProximityState)
        {
            prox.Invoke();
        }
        if(state.NewInteractableState == InteractableState.ActionState)
        {
            action.Invoke();
        }
        else
        {
            defaultState.Invoke();
        };
    }
}
