using UnityEngine;

/// <summary>
/// this class is used to invoke events related to touch inputs.
/// </summary>
public class TouchInputManager : SingletonBase<TouchInputManager>
{
    /// <summary>
    /// check per frame for touch input.
    /// </summary>
    private void Update()
    {
        CheckInput();
    }

    /// <summary>
    /// Function checks if and with how many finger the user is touching the screen, and then invokes corresponding event.
    /// </summary>
    private void CheckInput()
    {
        // we're only checking for a single touch right now, when needed this could easily be extended to support more touches.
        switch (Input.touchCount)
        {
            case 0:
                // no input received, do nothing.
                break;
            case 1:
                EventCatalogue.InvokeSingleTouchEvent();
                break;
        }
    }
}
