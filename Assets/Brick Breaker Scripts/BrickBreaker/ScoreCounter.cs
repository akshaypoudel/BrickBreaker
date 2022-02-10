using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    OnTriggerEnter triggerEnter;
    Text text;
    [HideInInspector]
    public int PlayScore;
    // Start is called before the first frame update
    void Start()
    {
        text=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text="Score: "+PlayScore;
    }
}
