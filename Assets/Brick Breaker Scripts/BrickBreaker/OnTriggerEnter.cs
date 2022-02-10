using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTriggerEnter : MonoBehaviour
{
    public Vector3 Rotator;
    public int points;
    public float hit;
    [HideInInspector]
    public int Score;
    ScoreCounter score;
    void Start()
    {
        transform.Rotate(Rotator * (transform.position.x + transform.position.y) * 0.1f);
        score=FindObjectOfType<ScoreCounter>();
    }
    void Update()
    {
        transform.Rotate(Rotator * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        hit--;
        if(hit<=0)
        {
            Destroy(this.gameObject);
            score.PlayScore+=points;
            // score.PlayScore+=1500;
        }
    }
}
