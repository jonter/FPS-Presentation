using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DeathPanel : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Destroy( FindObjectOfType<PlayerMovement>().gameObject );
        Destroy( FindObjectOfType<Canvas>().gameObject );
        Destroy( FindObjectOfType<EventSystem>().gameObject );

        SceneManager.LoadScene(0);
    }
    
}
