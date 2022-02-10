using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeScript : MonoBehaviour
{
        // public GameObject X;
    public GameObject[] Xs;
    // public GameObject O;
    public GameObject[] Os;
    [HideInInspector]
    public int[] arr={2,2,2,2,2,2,2,2,2};
    [HideInInspector]
    public int activePlayer=0;
    WinningScript winningScript;
    // int X=0,O=0;
    void Start()
    {
        winningScript=FindObjectOfType<WinningScript>();
    }
    public void MyFunc(int tag)
    {
        if(arr[tag]==2)
        {
            arr[tag]=activePlayer;
            if(activePlayer==0)
            {
                activePlayer++;
                Os[tag].SetActive(true);
                // O++;
            }else{
                activePlayer--;
                Xs[tag].SetActive(true);
                // X++;
            }
        }
        // winningScript.WhoisWinner();
    }
}
