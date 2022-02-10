using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BrickBreakerGame{
    public class PaddleMovement : MonoBehaviour
    {
        PrefabsLevelLoader levelLoader;
        Rigidbody _rigidbody;
        void Start()
        {
            levelLoader=FindObjectOfType<PrefabsLevelLoader>();
            _rigidbody=GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if(!levelLoader.ObjectivePanel.activeSelf)
            {
                float _horizontal=Input.GetAxis("Horizontal");
                transform.Translate(new Vector3(_horizontal,0,0));
            }

        }

    }
}
