using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text highscoreText;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateHighscoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHighscoreText()
    {
        highscoreText.text = "Current high score: " + ScoreManager.instance.highScore + " held by " + ScoreManager.instance.highScoreName;
    }
}
