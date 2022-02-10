using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float TimeIntervals;
    public Vector3 SpawnPos;
    float timer=0f;
    // Start is called before the first frame update
    void Start()
    {
        timer=TimeIntervals;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            timer=TimeIntervals;
            Instantiate(enemy,transform.position,Quaternion.identity);
        }
    }
}
