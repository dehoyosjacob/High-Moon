using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string SceneName;
    
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.H))
        {
            LoadScene(SceneName);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
