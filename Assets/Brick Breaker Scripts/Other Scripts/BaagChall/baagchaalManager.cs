using System;
using System.Collections.Generic;
using UnityEngine;

public class baagchaalManager : MonoBehaviour
{

    int maxGoats=0;
    int PlayerTurn=1;
    int []arr={0,2,2 ,2,0,2 ,2,2,2 ,2,2,2 ,2,2,2 ,2,2,2 ,2,2,0 ,2,2,2,0};
    public GameObject [] goats;
    public GameObject [] tigers;
    
    public void OnGoatEnable(int tag)
    {
        if(PlayerTurn==1 && arr[tag]==2 && maxGoats<20)
        {
            arr[tag]=PlayerTurn;
            goats[tag].SetActive(true);
            maxGoats++;
            PlayerTurn -= 2;
        }
        else if(PlayerTurn==-1)
        {
            if(arr[tag]!=2)
            {
                tigers[tag].SetActive(false);    
                arr[tag]=2;
                PlayerTurn++;
            }
        }   
        else
        {
            if(arr[tag]==2)
            {
                tigers[tag].SetActive(true);
                arr[tag]=PlayerTurn;
                PlayerTurn++;
            }
        }
    }
    
}
