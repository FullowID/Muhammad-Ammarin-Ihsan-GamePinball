using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    [SerializeField] private float maxLaunchForce = 1600.0f;
    [SerializeField] private float launchForceIncrement = 550.0f;
    [SerializeField] private KeyCode launchKey = KeyCode.Space;

    [SerializeField] private Rigidbody ballRigidbody;
    private bool canLaunch;
    private float currentLaunchForce;

    [SerializeField] private Slider powerSlider;

    private void Start()
    {
        currentLaunchForce = 0.0f;
        powerSlider.value = 0.0f;
    }

    private void Update()
    {
        if (canLaunch)
        {
            if (Input.GetKeyDown(launchKey))
            {
                AudioManager.Instance.PlaySFX("LauncherInit");
            }
            if (Input.GetKey(launchKey))
            {
                IncreaseLaunchForce();
            }

            if (Input.GetKeyUp(launchKey))
            {
                AudioManager.Instance.PlaySFX("LauncherRelease");
                LaunchBall();
            }
        }
        UpdatePowerSlider();
    }

    private void IncreaseLaunchForce()
    {
        currentLaunchForce += launchForceIncrement * Time.deltaTime;
        currentLaunchForce = Mathf.Clamp(currentLaunchForce, 0.0f, maxLaunchForce);
    }

    private void LaunchBall()
    {
        Vector3 launchDirection = transform.forward; // Use the forward direction of the launcher
        ballRigidbody.AddForce(launchDirection * currentLaunchForce);
        currentLaunchForce = 0.0f; // Reset the launch force
    }

    private void UpdatePowerSlider()
    {
        powerSlider.value = currentLaunchForce; // Update the slider value to reflect the launch force
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            canLaunch = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            canLaunch = false;
            currentLaunchForce = 0.0f; // Reset the launch force
        }
    }
}
