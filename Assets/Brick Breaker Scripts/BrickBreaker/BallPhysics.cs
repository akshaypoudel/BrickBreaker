using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BrickBreakerGame{
    public class BallPhysics : MonoBehaviour
    {
        [HideInInspector]
        public float speed = 20f;
        Vector3 _velocity;
        bool isGameOver = false;
        LevelLoader levelLoader;
        public Rigidbody _rigidbody;
        public GameObject GameoverPanel;
        public GameObject PauseButton;
        public Text HighScoreText;
        ScoreCounter score;


        public float GAmeOVerPosition;

        void Start()
        {
            levelLoader = FindObjectOfType<LevelLoader>();
            _rigidbody = GetComponent<Rigidbody>();
            score = FindObjectOfType<ScoreCounter>();
            Time.timeScale = 1f;

        }
        void Update()
        {
            if (this.transform.position.y < GAmeOVerPosition)
            {
                PauseButton.SetActive(false);
            }
        }

        void FixedUpdate()
        {
            if (this.transform.position.y < GAmeOVerPosition && isGameOver == false)
            {
                GameOver();
            }
            if (this.transform.position.y < GAmeOVerPosition)
                isGameOver = false;
            _rigidbody.velocity = _rigidbody.velocity.normalized * speed;
            _velocity = _rigidbody.velocity;
        }

        void OnCollisionEnter(Collision collision)
        {
            _rigidbody.velocity = Vector3.Reflect(_velocity, collision.GetContact(0).normal);
        }
        private void GameOver()
        {
            Time.timeScale = 0f;
            GameoverPanel.SetActive(true);
            isGameOver = true;
            HighScoreText.text = "High Score: " + score.PlayScore;
            // PauseButton.SetActive(false);
        }
    }
}
