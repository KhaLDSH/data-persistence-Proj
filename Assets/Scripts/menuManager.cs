using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    string playerName;

    [SerializeField] Text playerInput;
    

    public void StartGame()
    {
        
        SetPlayerName();
        SceneManager.LoadScene(1);
    }

    public void SetPlayerName()
    {
        MainMgr.Instance.playerName = playerInput.text;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    
}
