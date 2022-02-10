using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreakerGame{
    public class PaddleTouchControl : MonoBehaviour
    {
    private Touch touch;
    PrefabsLevelLoader levelLoader;
        private float speedModifier;
        // Start is called before the first frame update
        void Start()
        {
            levelLoader=FindObjectOfType<PrefabsLevelLoader>();
            speedModifier = 0.04f;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved &&!levelLoader.ObjectivePanel.activeSelf)
                {
                    transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.x * speedModifier,
                        transform.position.y,
                        transform.position.z //+ touch.deltaPosition.y * speedModifier
                        );
                }
            }
        }
    }
}
