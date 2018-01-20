using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    //UI fields for different elements.
    public Text highscore;
    public Slider tempoBar;

    public GameObject GameOverScreen;
    public GameObject SuccessScreen;

    private void LateUpdate()
    {
        //Tempo bar and score display
        tempoBar.value = ScoreManager.instance.barEnergy;
        highscore.text = "Score: " + ScoreManager.instance.Score;

        //Game end and Success UI Screens
        if (ScoreManager.instance.isOver)
        {
            GameOverScreen.gameObject.SetActive(true);
        }
        if (ScoreManager.instance.levelSuccess)
        {
            SuccessScreen.gameObject.SetActive(true);
        }
    }

}
