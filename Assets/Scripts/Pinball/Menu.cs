using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void RestartGame()
    {
        AudioManager.Instance.PlaySFX("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlaySFX("Click");
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        AudioManager.Instance.PlaySFX("Click");
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        AudioManager.Instance.PlaySFX("Click");
        SceneManager.LoadScene(1);
    }

    public void CreditScene()
    {
        AudioManager.Instance.PlaySFX("Click");
        SceneManager.LoadScene(2);
    }
}
