using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private Animator anim;
    private ScoreObject scoreObject;

    private bool canIncreaseScore = true;
    private float scoreIncreaseInterval = 0.7f;
    private ParticleSystem particleSys;
    private void Start()
    {
        particleSys = GetComponentInChildren<ParticleSystem>();
        scoreObject = FindObjectOfType<ScoreObject>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && canIncreaseScore)
        {
            AudioManager.Instance.PlaySFX("Bumper");
            particleSys.Play();
            anim.SetTrigger("Hit");
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
