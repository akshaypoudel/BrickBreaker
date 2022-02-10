using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{ 
    // #region References
    // ScoreCounter score;
    // public int level;
    // int CurrentLevel;
    // public GameObject ObjectivePanel;
    // public GameObject LevelCompletedPanel;
    // public int MaxPointToWin;
    // BallPhysics ball;
    // [HideInInspector]
    // public bool IsObjectivePanelActive=false;
    // #endregion
    // void Start()
    // {
    //     ball=FindObjectOfType<BallPhysics>();
    //     score=FindObjectOfType<ScoreCounter>();
    //     StartCoroutine(NextLevelLoader());
    //     CurrentLevel=level;
    // }

    // void Update()
    // {
    //     if(score.PlayScore>=MaxPointToWin && CurrentLevel==level)
    //     {
    //         LevelCompletedPanel.SetActive(true);
    //         CurrentLevel++;
    //         Debug.Log("Current Level is: "+CurrentLevel);
    //         Time.timeScale=0f;
    //     }
    // }
    // IEnumerator NextLevelLoader()
    // {
    //     IsObjectivePanelActive=true;
    //     ObjectivePanel.SetActive(true);
    //     yield return new WaitForSeconds(2f);
    //     ObjectivePanel.SetActive(false);
    //     yield return new WaitForSeconds(0.3f);
    //     ball._rigidbody.velocity=Vector3.down*ball.speed;
    // }
    
    // public void _loadScene()
    // {
    //     SceneManager.LoadScene(CurrentLevel);
    // }

}
