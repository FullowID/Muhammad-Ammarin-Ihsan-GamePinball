using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float gravityForce = 10.0f;
    private Rigidbody ballRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ballRigidbody.AddForce(new Vector3(0, 0, -1) * gravityForce);
    }
}
