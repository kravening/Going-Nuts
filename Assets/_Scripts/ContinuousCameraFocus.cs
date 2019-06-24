using UnityEngine;
using Vuforia;

public class ContinuousCameraFocus : MonoBehaviour
{
    void Start()
    {
        VuforiaARController vuforia = VuforiaARController.Instance;
        vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        vuforia.RegisterOnPauseCallback(OnPaused);
    }

    /// <summary>
    /// tell unity to focus the camera
    /// </summary>
    private void OnVuforiaStarted()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    /// <summary>
    /// tell unity to focus the camera
    /// </summary>
    /// <param name="paused"></param>
    private void OnPaused(bool paused)
    {
        if (!paused) // resumed
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }
    }
}
