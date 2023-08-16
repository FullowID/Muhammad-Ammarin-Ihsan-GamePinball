using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPath : MonoBehaviour
{
    private Animator anim;
    private ScoreObject scoreObject;

    private bool canIncreaseScore = true;
    private float scoreIncreaseInterval = 0.8f;

    private bool isOn = false;
    private ParticleSystem particleSys;

    private void Start()
    {
        particleSys = GetComponentInChildren<ParticleSystem>();
        scoreObject = FindObjectOfType<ScoreObject>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && canIncreaseScore)
        {
            particleSys.Play();
            isOn = !isOn;
            AudioManager.Instance.PlaySFX("Switch");
            if (isOn)
            {
                anim.SetTrigger("On");
            }
            else
            {
                anim.SetTrigger("Off");
            }
            
            scoreObject.ScoreIncrease(5);
            canIncreaseScore = false;
            StartCoroutine(EnableScoreIncrease());
        }
    }

    private IEnumerator EnableScoreIncrease()
    {
        yield return new WaitForSeconds(scoreIncreaseInterval);
        canIncreaseScore = true;
    }
}
