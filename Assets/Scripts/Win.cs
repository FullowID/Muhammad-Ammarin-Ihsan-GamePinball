using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Win : MonoBehaviour
{
    [SerializeField] private TMP_Text textWin;
    void Start()
    {
        textWin.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textWin.gameObject.SetActive(true);
        }
    }
}
