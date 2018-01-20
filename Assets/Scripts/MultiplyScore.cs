using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplyScore : MonoBehaviour {

    public Text multipDisplay;
    public Image[] images;


    void Update () {
        multipDisplay.text = "x" + ScoreManager.instance.ScoreMult;

        if (ScoreManager.instance.thingsToScore > 0)
        {
            images[ScoreManager.instance.thingsToScore - 1].enabled = true;
        }
        else if (ScoreManager.instance.thingsToScore == 0)
        {
            foreach (var image in images)
            {
                image.enabled = false;
            }
        }

        if (ScoreManager.instance.thingsToScore == 4)
        {
            foreach (var image in images)
            {
                image.enabled = false;
            }
        }
	}

}
