using UnityEngine;

//Jonathan Berkeley's StaticInput class
//N00181859
public static class StaticInput
{
    private static float horizontal = 0.0f;
    private static float vertical = 0.0f;
    private static bool jumping = false;
    private static bool shooting = false;
    private static bool stoppedShooting = false;
    private static bool pause = false;

    /// <summary>
    /// Updates all the player input values
    /// </summary>
    public static void UpdatePlayerValues()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        jumping = Input.GetButton("Jump");
    }

    /// <summary>
    /// Updates the horizontal value only
    /// </summary>
    public static void UpdateHorizontal()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    /// <summary>
    /// Updates the vertical value only
    /// </summary>
    public static void UpdateVertical()
    {
        vertical = Input.GetAxisRaw("Vertical");
    }

    /// <summary>
    /// Updates the jumping value only
    /// </summary>
    public static void UpdateJumping()
    {
        jumping = Input.GetButton("Jump");
    }

    /// <summary>
    /// Updates the shooting value only
    /// </summary>
    public static void UpdateShooting()
    {
        shooting = Input.GetButtonDown("Fire1");
    }

    /// <summary>
    /// For any scripts that need to know if the player has stopped shooting
    /// </summary>
    public static void UpdateStoppedShooting()
    {
        stoppedShooting = Input.GetButtonUp("Fire1");
    }


    public static void UpdatePauseCheck()
    {
        pause = Input.GetButtonDown("Cancel");
    }

    /// <summary>
    /// Gets the last saved horizontal value
    /// </summary>
    /// <returns> Float - Horizontal value </returns>
    public static float GetHorizontal()
    {
        return horizontal;
    }

    /// <summary>
    /// Gets the last saved vertical value
    /// </summary>
    /// <returns> Float - Vertical value </returns>
    public static float GetVertical()
    {
        return vertical;
    }

    /// <summary>
    /// Gets the last saved jumping value
    /// </summary>
    /// <returns> Boolean - Jumping input </returns>
    public static bool GetJumping()
    {
        return jumping;
    }

    /// <summary>
    /// Gets the last saved shooting value
    /// </summary>
    /// <returns> Boolean - Shooting input </returns>
    public static bool GetShooting()
    {
        return shooting;
    }

    /// <summary>
    /// Get's the frame the player stops pressing the fire key
    /// </summary>
    /// <returns> Boolean - Returns true when the player stops shooting</returns>
    public static bool GetStoppedShooting()
    {
        return stoppedShooting;
    }

    /// <summary>
    /// Returns if player paused
    /// </summary>
    /// <returns> Boolean - Pause attempt from player </returns>
    public static bool GetPaused()
    {
        return pause;
    }
}
