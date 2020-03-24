
using UnityEngine;

public abstract class ControllerBase : MonoBehaviour
{
    /// <summary>
    /// Used to indicate if corresponding UI display (if available) is currently displayed on the screen.
    /// </summary>
    protected bool UIDisplayOpen = false;

    // Start is called before the first frame update
    protected virtual void Start() 
    {
        enabled = false;
    }

    /// <summary>
    /// Activate provided controller type and return an instance of that controller. A controller cannot activate itself from 
    /// a disabled state.
    /// </summary>
    protected TType ActivateController<TType>() where TType : ControllerBase {
        var controller = GetComponent<TType>();
        controller.enabled = true;
        return controller;
    }

    /// <summary>
    /// Deactivates provided Controller type. Note: Use DeactivateThis() for controllers deactivating themselves
    /// </summary>
    protected void DeactivateController<TType>() where TType : ControllerBase {
        var controller = GetComponent<TType>();
        controller.enabled = false;
    }

    /// <summary>
    /// Deactivates this controller. Note this will disable the update call and must be activated by
    /// another controller.
    /// </summary>
    protected void DeactivateThis() {
        enabled = false;
    }
}
