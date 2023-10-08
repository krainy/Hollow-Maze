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

        if (Input.GetKeyDown(this.GetComponent<KeyConfigController>().KeysList[3]) && gameIsPaused)
        {
            ReleaseGame();
        }
        else if (Input.GetKeyDown(this.GetComponent<KeyConfigController>().KeysList[3]) && !gameIsPaused)
        {
            PausedGame();
        }
    }

    public void PausedGame()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Game" && SceneManager.sceneCount < 2)
        {
            gameIsPaused = !gameIsPaused;
            Time.timeScale = 0;
            SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
        }

    }

    public void ReleaseGame()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Game" && SceneManager.sceneCount == 2)
        {
            SceneManager.UnloadSceneAsync("Pause");
            gameIsPaused = !gameIsPaused;
            Time.timeScale = 1;
        }

    }

    public void ReleaseGameByChangeScene()
    {
        SceneManager.UnloadSceneAsync("Pause");
        gameIsPaused = !gameIsPaused;
        Time.timeScale = 1;
    }
}
