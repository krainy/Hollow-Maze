using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    [SerializeField] bool gameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused)
        {
            ReleaseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused)
        {
            PausedGame();
        }
    }

    public void PausedGame()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Game")
        {
            gameIsPaused = !gameIsPaused;
            Time.timeScale = 0;
            SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
        }

    }

    public void ReleaseGame()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Game")
        {
            SceneManager.UnloadSceneAsync("Pause");
            gameIsPaused = !gameIsPaused;
            Time.timeScale = 1;
        }

    }
}
