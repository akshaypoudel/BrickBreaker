using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void _loadscene(string _name)
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(_name);
    }
}
