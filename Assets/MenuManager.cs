using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GamePaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;
    }

    public void LoadMenu()
    {

    }

    public void QuitGame()
    {

    }
}
