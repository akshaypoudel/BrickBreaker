using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickMovementScript : MonoBehaviour
{
    public float max=6f;
    public float min=-16f;
    // Start is called before the first frame update
    void Start()
    {
        min=transform.position.x+(-15f);
        max=transform.position.x+5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =new Vector3(Mathf.PingPong(Time.time*2,max-min)+min, transform.position.y, transform.position.z);
    }
}
