using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BrickBreakerGame{
    public class PaddleMovement : MonoBehaviour
    {
        PrefabsLevelLoader levelLoader;
        Rigidbody _rigidbody;
        private Touch touch;
        private float speedModifier;

        public float minClampPosX, maxClampPosX;
        void Start()
        {
            levelLoader=FindObjectOfType<PrefabsLevelLoader>(); 
            _rigidbody=GetComponent<Rigidbody>();
            speedModifier = 0.04f;
        }

        void FixedUpdate()
        {
            if(!levelLoader.ObjectivePanel.activeSelf)
            {
                float _horizontal=Input.GetAxis("Horizontal");
                transform.Translate(new Vector3(_horizontal,0,0));

                transform.position = new Vector3(
                        Mathf.Clamp(transform.position.x,minClampPosX,maxClampPosX)
                        ,transform.position.y,
                         transform.position.z);


            }
#if UNITY_ANDROID
            AndroidTouchControl();
#endif

        }

        private void AndroidTouchControl()
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved && !levelLoader.ObjectivePanel.activeSelf)
                {
                    transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.x * speedModifier,
                        transform.position.y,
                        transform.position.z //+ touch.deltaPosition.y * speedModifier
                        );

                    transform.position = new Vector3(
                        Mathf.Clamp(transform.position.x, -25.9f, 25.93f)
                        , transform.position.y,
                         transform.position.z);
                }
            }
        }

    }
}
