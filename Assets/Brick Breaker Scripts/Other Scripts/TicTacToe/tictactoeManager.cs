using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class tictactoeManager : MonoBehaviour
{
    TicTacToeScript max;
    // Start is called before the first frame update
    void Start()
    {
        max=FindObjectOfType<TicTacToeScript>();
    }
    private void OnMouseDown()
    {
        string a=this.tag;
        int tag=Int32.Parse(a);
        max.MyFunc(tag);
    }
    public int isWinner()
    {
        string a=this.tag;
        int tag=Int32.Parse(a);
        return tag;
    }
}
