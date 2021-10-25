using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUIHandler : MonoBehaviour
{
    public InputField nameInputField;

    public void SendNameToManager()
    {
        ScoreManager.instance.playerName = nameInputField.text;
        SceneManager.LoadScene(1);
    }
}