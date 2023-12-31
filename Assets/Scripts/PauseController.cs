using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    [SerializeField] bool gameIsPaused = false;
    public bool GameIsPaused
    {
        get { return gameIsPaused; }
    }
    GameObject gameCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        print(SceneManager.sceneCount + " " + SceneManager.GetActiveScene().name);


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

        if (scene.buildIndex >= 5 && scene.buildIndex <= 12)
        {
            gameCanvas = GameObject.Find("GameCanvas");
            gameCanvas.SetActive(false);
            gameIsPaused = !gameIsPaused;
            Time.timeScale = 0;
            SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
        }

    }

    public void ReleaseGame()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (SceneManager.sceneCount <= 2 && scene.buildIndex >= 5 && scene.buildIndex <= 12)
        {
            gameCanvas.SetActive(true);
            SceneManager.UnloadSceneAsync("Pause");
            gameIsPaused = !gameIsPaused;
            Time.timeScale = 1;
        }

    }

    public void ReleaseGameByChangeScene()
    {
        gameCanvas.SetActive(true);
        SceneManager.UnloadSceneAsync("Pause");
        gameIsPaused = !gameIsPaused;
        Time.timeScale = 1;
    }
}
