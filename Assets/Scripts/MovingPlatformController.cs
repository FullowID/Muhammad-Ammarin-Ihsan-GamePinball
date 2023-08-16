using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    [SerializeField] private float minXBoundary;
    [SerializeField] private float maxXBoundary;

    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(new Vector3(minXBoundary, gameObject.transform.position.y, gameObject.transform.position.z),
                                             new Vector3(maxXBoundary, gameObject.transform.position.y, gameObject.transform.position.z),
                                             Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
