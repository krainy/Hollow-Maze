using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMazes : MonoBehaviour
{
    
    [SerializeField] int mazeIndex = 0;
    [SerializeField] GameObject[] activeMazes;
    

    public int SetActiveMazes(GameObject mazeObject){
        foreach(GameObject maze in activeMazes){
            if(maze.name == mazeObject.name){
                return -1;
            }
        }

        mazeIndex++;
        GameObject[] aux = new GameObject[mazeIndex];

        for(int i = 0; i < mazeIndex; i++){
            aux[i] = activeMazes[i];
        }

        activeMazes = aux;

        return mazeIndex - 1;
    }

}
