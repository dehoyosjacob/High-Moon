using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string characterSelect;
    [SerializeField] string hamVersion;
    [SerializeField] string redVersion;
    [SerializeField] CharacterSelect playersChoice;

    
    void Update()
    {
        if (playersChoice == null)
        {
            if (Input.GetKeyUp(KeyCode.H))
            {
                LoadScene(characterSelect);
            }
        }

        else if (playersChoice.isHam != null)
        {
            if(playersChoice.isHam == true)
            {
                if (Input.GetKeyUp(KeyCode.H))
                {
                    LoadScene(hamVersion);
                }
            }

            else if(playersChoice.isHam != true)
            {
                if (Input.GetKeyUp(KeyCode.H))
                {
                    LoadScene(redVersion);
                }
            }
        }


    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
