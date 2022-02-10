using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using BrickBreakerGame;

namespace BrickBreakerGame{

    public class PauseMenuScript : MonoBehaviour
    {
        public GameObject PauseMenuUI;
        public PrefabsLevelLoader levelLoader;
        void Start()
        {
            levelLoader=FindObjectOfType<PrefabsLevelLoader>();
        }
        void Update()
        {
            if(Input.GetKey(KeyCode.Escape) && !levelLoader.LevelCompletedPanel.activeSelf)
            {
                Pause();
            }
        }
        public void Resume()
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
        public void Pause()
        {
            Time.timeScale = 0f;
            PauseMenuUI.SetActive(true);
        }
        public void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void QuitGame()
        {
            Debug.Log("Quitting GAme: ");
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        } 
        // public void LoadLevel(int _level)
        // {
        //     levelLoader=FindObjectOfType<PrefabsLevelLoader>();
        //     levelLoader.level=_level;
        // // }
        public void LevelsNumberButtons(int _level)
        {
        //    levelLoader.callByButtonFunc(_level);
            GameHandlerScript.level=_level;
            Debug.Log("FunctionCalled = "+GameHandlerScript.level);
            SceneManager.LoadScene("level1");
        }
    }
}
