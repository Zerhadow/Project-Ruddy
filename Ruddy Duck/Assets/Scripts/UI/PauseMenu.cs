using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() {
        SceneManager.LoadScene("TitleScreen2");
    }

    public void GoToArena() {
        SceneManager.LoadScene("Arena");
        Time.timeScale = 1;
    }

    public void GoToTown() {
        SceneManager.LoadScene("Town");
        Time.timeScale = 1;
    }
}
