using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouchingGround : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="lava")
        {
            Destroy(this.gameObject);
        }
    }
}
