using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WinningScript : MonoBehaviour
{

    TicTacToeScript myScript;
    tictactoeManager winner;

   [HideInInspector]    
   public int[,] winPositions = {{0,1,2}, {3,4,5}, {6,7,8},
                                 {0,3,6}, {1,4,7}, {2,5,8},
                                 {0,4,8}, {2,4,6}};
    public GameObject OWinningUi;
    public GameObject XWinningUi;
    int [] winPosition;
    int [] BoxTag={0,1,2,3,4,5,6,7,8};
    void Start()
    {
        myScript=FindObjectOfType<TicTacToeScript>();
        winner = FindObjectOfType<tictactoeManager>();
    }

    public void WhoisWinner()
    {
        // for(int i=0;i<=8;i++)
        // {
        //     BoxTag[i]=winner.isWinner();
        // }
        // if(BoxTag[])
    }

    // public void WhoisWinner()
    // {
        // for(int i=0;i<=winPositions[2,7];i++)
        // {
        //     winPosition[i]=winPositions;
        //     if(myScript.arr[winPosition[0]] == myScript.arr[winPosition[1]] &&
        //             myScript.arr[winPosition[1]] == myScript.arr[winPosition[2]] &&
        //             myScript.arr[winPosition[0]]!=2){
        //         // Somebody has won! - Find out who!
                
                
        //         if(myScript.arr[winPosition[0]] == 0){
        //             XWinningUi.SetActive(true);
        //         }
        //         else{
        //             OWinningUi.SetActive(true);
        //         }
        //     }
        // }
    // }
}
