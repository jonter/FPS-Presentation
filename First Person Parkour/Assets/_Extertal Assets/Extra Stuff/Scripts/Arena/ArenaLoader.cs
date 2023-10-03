using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaLoader : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(eventSystem);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            SceneManager.LoadSceneAsync("Arena");
        }
        
    }


}
