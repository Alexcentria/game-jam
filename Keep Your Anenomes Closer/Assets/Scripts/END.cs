using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class END : MonoBehaviour
{
    [SerializeField]
    public float time;
    

    // Update is called once per frame
    void Update()
    {
        if (time == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
