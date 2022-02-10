using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform myTransform;
    public Rigidbody rigid;
    public float speed=4f;

    void Start()
    {
        rigid=GetComponent<Rigidbody>();
        if(myTransform==null)
        {
            myTransform=FindObjectOfType<PlayerController>().transform;
        }
    }
    void Update()
    {
        rigid.velocity += (myTransform.position - transform.position).normalized *speed*Time.deltaTime;
    }
}
