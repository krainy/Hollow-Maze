using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDoor : MonoBehaviour
{

    [SerializeField] GameObject GameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController == null){
            GameController = GameObject.Find("GameController");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            GameController.GetComponent<ScenesManager>().sceneLoadAsync("LevelWin");
        }
    }
}
