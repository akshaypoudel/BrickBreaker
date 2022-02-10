using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{
    // TouchRotaion touch=new TouchRotaion();

    public string scene_name;
    private void onCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="goal")
        {
            SceneManager.LoadScene(scene_name);
        }
    }
    // touch.TouchRotation();
}
