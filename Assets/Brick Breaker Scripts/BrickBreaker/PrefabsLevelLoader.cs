using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace BrickBreakerGame
{
    public class PrefabsLevelLoader : MonoBehaviour
    {
        #region GameObjectReferences
        public GameObject ObjectivePanel;
        private GameObject Bricks;
        public GameObject LevelCompletedPanel;
        public GameObject PauseButton;
        public GameObject BallObject;
        public GameObject GameoverPanel;
        public GameObject[] levels;
        public GameObject PaddleObject;
        public GameObject NextLevelButton;
        public GameObject RestartButton;
        #endregion
        #region References
        ScoreCounter score;
        int CurrentLevelCount;
        public string [] ObjectiveText;
        public int [] MaxPointToWin;
        public TMP_Text text;
        public int level;
        public TMP_Text LevelNameText;
        private int CurrentLevel;

        public static bool canPause=false;

        public Vector3 PaddlePosition;
        // public int MaxPointToWin;
        BallPhysics ball;
        [HideInInspector]
        public bool IsObjectivePanelActive=false;
        bool islevelcompleted=false;
        // bool isGameOver=false;
        #endregion
     
        void Start()
        {
            ball=FindObjectOfType<BallPhysics>();
            score=FindObjectOfType<ScoreCounter>();
            if(GameHandlerScript.level>0)
            {
                callByButtonFunc(GameHandlerScript.level);
            }
            else
                StartCoroutine(NextLevelLoader());
        }
        void Update()
        {
            Check_Whether_Player_Wins_OR_Not(); //this function is called whenever the player wins
            if(GameHandlerScript.level>0)
                level = GameHandlerScript.level;
            if(score.PlayScore>=MaxPointToWin[level])
                islevelcompleted=false;
        }
        private void Check_Whether_Player_Wins_OR_Not() //this function check if the player wins
        {
            if((score.PlayScore>=MaxPointToWin[level] || score.PlayScore>=MaxPointToWin[GameHandlerScript.level]) && islevelcompleted==false)
            {
                PauseButton.SetActive(false);
                LevelCompletedPanel.SetActive(true);
                // CurrentLevel++;
                CurrentLevel=level;
                Time.timeScale=0f;
                islevelcompleted=false; 
                if(levels.Length==CurrentLevel+1 || GameHandlerScript.level+1==levels.Length)
                {
                    NextLevelButton.SetActive(false);
                    var buttton=RestartButton.transform.GetComponent<RectTransform>();
                    var pos=buttton.anchoredPosition;
                    RestartButton.GetComponent<RectTransform>().anchoredPosition=new Vector3(0,pos.y);
                }
            }
        }

        public IEnumerator NextLevelLoader()//this function gets automatically called via the START function
        {
            canPause = false;
            // PauseButton.SetActive(true);
            int _level;
            _level=level;
            Bricks = Instantiate(levels[_level],new Vector3(0,0,0),Quaternion.identity);
            // PaddleObject.transform.position=new Vector3(Random.Range(-1.4f,1.4f),-3.2f,0);
            PaddleObject.transform.position=new Vector3(Random.Range(-1.8f,1.8f),PaddlePosition.y,0f);

            ObjectivePanel.SetActive(true);
            PauseButton.SetActive(false);
            int levelName;
            levelName=_level;
            LevelNameText.text="Level "+(++levelName);
            text.text=ObjectiveText[_level];
            yield return new WaitForSeconds(2f);
            ObjectivePanel.SetActive(false);
            PauseButton.SetActive(true);
            canPause = true;
            yield return new WaitForSeconds(0.3f);
            ball._rigidbody.velocity=Vector3.down*ball.speed;
        }
        
        public void _loadScene()// this is for loading any scene
        {
            SceneManager.LoadScene(CurrentLevel);
        }
        public void LoadAfterGameOver() //this function loads the same level after game over
        {
            PauseButton.SetActive(true);
            Time.timeScale=1f;
            GameoverPanel.SetActive(false);
            score.PlayScore=0;
            if(GameHandlerScript.level>0)
            {
                StartCoroutine(LoadAfterGameOverByButton(GameHandlerScript.level));
            }
            else
                StartCoroutine(LoadLevelAfterGameOver());
        }
        IEnumerator LoadLevelAfterGameOver()
        {
            canPause = false;
            // PauseButton.SetActive(true);
            int _level;
            _level=level;
            Destroy(Bricks);
            ball._rigidbody.velocity = Vector3.zero;
            BallObject.transform.position=new Vector3(0,0,0);
            PaddleObject.transform.position=new Vector3(Random.Range(-1.8f,1.8f),PaddlePosition.y,0f);
            Bricks = Instantiate(levels[_level],new Vector3(0,0,0),Quaternion.identity);
            ObjectivePanel.SetActive(true);
            PauseButton.SetActive(false);
            int levelName;
            levelName=_level;
            LevelNameText.text="Level "+(++levelName);
            text.text=ObjectiveText[_level];
            yield return new WaitForSeconds(2f);
            ObjectivePanel.SetActive(false);
            PauseButton.SetActive(true);
            canPause = true;
            yield return new WaitForSeconds(0.3f);
            ball._rigidbody.velocity=Vector3.down*ball.speed;
        }

        public void LoadNextLevel() //this function loads the next level
        {
            PauseButton.SetActive(true);
            islevelcompleted=true;
            level++;
            Time.timeScale=1f;
            LevelCompletedPanel.SetActive(false);

            if(GameHandlerScript.level>0)
            {    
                StartCoroutine(CallByButton(++(GameHandlerScript.level)));
            }
            else
                StartCoroutine(NextLevel());
        }
        IEnumerator NextLevel() 
        {
            canPause = false;   
            // PauseButton.SetActive(true);
            score.PlayScore=0;
            Time.timeScale=1f;
            int _level;
            _level = level;
            // Debug.Log("CurrentMYNextLevel: "+level);
            // Debug.Log("_level="+ _level);
            ball._rigidbody.velocity = Vector3.zero;
            BallObject.transform.position=new Vector3(0,0,0);
            PaddleObject.transform.position=new Vector3(Random.Range(-1.8f,1.8f),PaddlePosition.y,0f);
            Destroy(Bricks);
            // Debug.Log("_level: "+ _level);
            Bricks=Instantiate(levels[_level],new Vector3(0,0,0),Quaternion.identity);
            ObjectivePanel.SetActive(true);
            PauseButton.SetActive(false);
            int levelName;
            levelName=_level;
            LevelNameText.text="Level "+(++levelName);
            text.text=ObjectiveText[_level];

            yield return new WaitForSeconds(2f);
            ObjectivePanel.SetActive(false);
            PauseButton.SetActive(true);
            canPause = true;
            ball._rigidbody.velocity=Vector3.down*ball.speed;
        }


    //*********************************************************************************************
    // this function are called when someone press the level button in home scene
        public void callByButtonFunc(int __level)
        {
            StartCoroutine(CallByButton(__level));
        }
        public IEnumerator CallByButton(int __level) 
        {
            canPause = false;
            PauseButton.SetActive(true);
            score.PlayScore=0;
            Time.timeScale=1f;
            int _level;
            _level = __level;
            ball._rigidbody.velocity = Vector3.zero;
            BallObject.transform.position=new Vector3(0,0,0);
            PaddleObject.transform.position=new Vector3(Random.Range(-1.8f,1.8f),PaddlePosition.y,0f);
            Destroy(Bricks);
            Bricks=Instantiate(levels[_level],new Vector3(0,0,0),Quaternion.identity);
            ObjectivePanel.SetActive(true);
            PauseButton.SetActive(false);
            int levelName;
            levelName=_level;
            LevelNameText.text="Level "+(++levelName);
            text.text=ObjectiveText[_level];

            yield return new WaitForSeconds(2f);
            ObjectivePanel.SetActive(false);
            PauseButton.SetActive(true);
            canPause = true;
            ball._rigidbody.velocity=Vector3.down*ball.speed;
        }
        IEnumerator LoadAfterGameOverByButton(int __level)
        {
            canPause = false;
            PauseButton.SetActive(true);
            int _level;
            _level=__level;
            Destroy(Bricks);
            ball._rigidbody.velocity = Vector3.zero;
            BallObject.transform.position=new Vector3(0,0,0);
            PaddleObject.transform.position=new Vector3(Random.Range(-1.8f,1.8f),PaddlePosition.y,0f);
            Bricks = Instantiate(levels[_level],new Vector3(0,0,0),Quaternion.identity);
            ObjectivePanel.SetActive(true);
            PauseButton.SetActive(false);
            int levelName;
            levelName=_level;
            LevelNameText.text="Level "+(++levelName);
            text.text=ObjectiveText[_level];
            yield return new WaitForSeconds(2f);
            ObjectivePanel.SetActive(false);
            PauseButton.SetActive(true);
            canPause=true;
            yield return new WaitForSeconds(0.3f);
            ball._rigidbody.velocity=Vector3.down*ball.speed;
        }
    }
}

