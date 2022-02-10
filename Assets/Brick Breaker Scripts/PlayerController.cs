using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{    
    public float Speed=5f;
    public float Jump = 2f;
    public Rigidbody rigidBody;
    public GameObject player;
    public float maxDownPos=1f;
    public string scene;
    bool isGrounded=true;
    void Start()
    {
        rigidBody=GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float horiz= Input.GetAxis("Vertical")*Speed;
        float vert= Input.GetAxis("Horizontal")*Speed;

        rigidBody.velocity += new Vector3(-horiz,0,vert)*Time.deltaTime;  
        if(Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            rigidBody.AddForce(new Vector3(0,Jump,0),ForceMode.Impulse);
            isGrounded=false;
        }    
        if(player.transform.position.y <= maxDownPos)
        {
            SceneManager.LoadScene(scene);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Ground")
        {
            isGrounded=true;
        }
    }
}
