using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddle : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float paddleForce = 10.0f;
    private bool isPaddleActive = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Up");
            isPaddleActive = true;
            AudioManager.Instance.PlaySFX("Flipper");
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetTrigger("Down");
            isPaddleActive = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isPaddleActive && collision.gameObject.CompareTag("Ball"))
        {
            ApplyPaddleForce(collision.rigidbody);
        }
    }

    private void ApplyPaddleForce(Rigidbody ballRigidbody)
    {
        ballRigidbody.AddForce(new Vector3(0, 0, 1) * paddleForce, ForceMode.Impulse);
    }
}
