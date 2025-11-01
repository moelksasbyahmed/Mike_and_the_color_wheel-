using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static float horizontal;   // -1 = left, 1 = right
    public static bool runPressed;
    public static bool jumpPressed;


    public void OnLeftPress() => horizontal = -1f;
    public void OnRightPress() => horizontal = 1f;
    public void OnReleaseHorizontal() => horizontal = 0f;

    public void OnRunPress() => runPressed = true;
    public void OnRunRelease() => runPressed = false;
    public void OnJumpPress() => jumpPressed = true;
    public void OnJumpRelease() => jumpPressed = false;


    public static bool isMobile;
    void Start()
    {
        // Detect mobile platforms
        isMobile = Application.platform == RuntimePlatform.Android ||
                        Application.platform == RuntimePlatform.IPhonePlayer;

        if(!isMobile)
        this.gameObject.SetActive(false);
    }
}
