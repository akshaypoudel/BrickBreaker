using System;
using System.Collections.Generic;
using UnityEngine;

public class onClick : MonoBehaviour
{
    baagchaalManager manager;
    void Start()
    {
        manager=FindObjectOfType<baagchaalManager>();
    }
    private void OnMouseDown()
    {
        string a=this.tag;
        int tag=Int32.Parse(a);
        manager.OnGoatEnable(tag);
    }
}
