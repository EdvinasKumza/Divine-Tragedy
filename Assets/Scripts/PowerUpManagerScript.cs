using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManagerScript : MonoBehaviour
{
    public float speedBoostMultiplier = 2;
    public float jumpBoostMultiplier = 2;
    private PlayerMovement playerMovement;
    private float originalSpeed = 7;
    private float originalJumpSpeed = 5;
    private float powerUpTimeDuration = 15;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void ActivatePowerUp(PowerUpType powerUpType)
    {
        switch (powerUpType)
        {
            case PowerUpType.SpeedBoost:
                StartCoroutine(ApplySpeedBoost());
                break;
            case PowerUpType.JumpBoost:
                StartCoroutine(ApplyJumpSpeedBoost());
                break;
        }
    }
    
    private IEnumerator ApplySpeedBoost()
    {
        playerMovement.ModifySpeed(speedBoostMultiplier);
        yield return new WaitForSeconds(powerUpTimeDuration); // Power-up time duration
        playerMovement.ResetSpeed(originalSpeed);
    }

    private IEnumerator ApplyJumpSpeedBoost()
    {
        playerMovement.ModifyJumpSpeed(jumpBoostMultiplier);
        yield return new WaitForSeconds(powerUpTimeDuration); // Power-up time duration
        playerMovement.ResetJumpSpeed(originalJumpSpeed);
    }
}
