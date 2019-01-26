using UnityEngine;
using UnityEngine.Events;


public class InteractOnButton2D : InteractOnTrigger2D
{
    public UnityEvent OnButtonPress;

    bool m_CanExecuteButtons;

    protected override void ExecuteOnEnter(Collider2D other)
    {
        m_CanExecuteButtons = true;
        Debug.Log("Dialogue collision detected");
        OnEnter.Invoke ();
    }

    protected override void ExecuteOnExit(Collider2D other)
    {
        m_CanExecuteButtons = false;
        Debug.Log("End collision, removing dialogue");
        OnExit.Invoke ();
    }

    void Update()
    {
        // if (m_CanExecuteButtons)
        // {
        //     if (OnButtonPress.GetPersistentEventCount() > 0 && PlayerInput.Instance.Interact.Down)
        //         OnButtonPress.Invoke();
        // }
    }
}
