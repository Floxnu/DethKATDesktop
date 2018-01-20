using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoModeMask : MonoBehaviour {

    private Image imgMask;

    private bool isInMax;

    private Color maskColor;

    private bool justEntered = true;

	// Use this for initialization
	void Start () {
        imgMask = GetComponent<Image>();
        maskColor = imgMask.color;

	}
	
	// Update is called once per frame
	void Update () {
        imgMask.color = maskColor;
        if(ScoreManager.instance.barEnergy >= 100 && justEntered)
        {
            isInMax = true;
            StartCoroutine(EnterTempo());
            justEntered = false;
        }
        else if(ScoreManager.instance.barEnergy < 100)
        {
            maskColor.a = 0;
            justEntered = true;
        }
	}

    IEnumerator EnterTempo()
    {
        if (isInMax)
        {
            float flash = 0;
            while(flash <= .3f)
            {

                flash = Mathf.Lerp(0, .4f, 1);
                maskColor.a = flash;
                yield return null;
            }
        }
        yield return null;
    }

}
