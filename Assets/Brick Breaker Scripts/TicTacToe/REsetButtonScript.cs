using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REsetButtonScript : MonoBehaviour
{
    public GameObject[] Os;
    public GameObject[] Xs;
    TicTacToeScript script;

    void Start()
    {
        script=FindObjectOfType<TicTacToeScript>();
    }
    public void ResetButton()
    {
        for(int i=0;i<=8;i++)
        {
            Os[i].SetActive(false);
            Xs[i].SetActive(false);
            script.arr[i]=2;
        }
        script.activePlayer=0;
        
    }
}
