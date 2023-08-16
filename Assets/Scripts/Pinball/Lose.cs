using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    [SerializeField] private GameObject loseUi;
    [SerializeField] private GameObject otherUi;

    private void Start()
    {
        loseUi.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            AudioManager.Instance.PlaySFX("Fail");
            loseUi.SetActive(true);
            otherUi.SetActive(false);
        }
    }
}
