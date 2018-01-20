using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    internal bool isFighting = false;

    public static ScoreManager instance;
    public TriggerDetector successes;

    //internal vars for the singleton
    internal bool canJump;
    internal bool goingDown;

    internal bool isOver;

    internal KeyCode requiredInput;
    internal KeyCode optionalInput;

    internal float barEnergy = 50;
    internal float Score = 0;

    internal int thingsToScore = 0;

    internal int ScoreMult = 1;

    internal bool levelSuccess = false;

    internal float shakeDuration;
    internal Vector3 originalCameraPosition;

    [SerializeField]
    internal AudioSource HitSound;

    [SerializeField]
    internal AudioSource HurtSound;

    [SerializeField]
    internal float shakeAmount;

    //Ensure only one
    void Awake () {
		if(instance != null)
        {
            Destroy(this);
        }
        instance = this;
       
	}

    //initializes some variables
    private void Start()
    {
        canJump = false;
        goingDown = false;

        Time.timeScale = 1;

        requiredInput = KeyCode.D;
        optionalInput = KeyCode.D;

        originalCameraPosition = Camera.main.transform.position;
    }

    //Checks for game end States
    private void Update()
    {
        CameraShake();
        if (barEnergy <= 0)
        {
            StartCoroutine(GameOver());
        }

        if (levelSuccess)
        {
            StartCoroutine(WellDone());
        }

        if (successes.succeded && thingsToScore <= 3 && ScoreMult <= 3)
        {
           if(thingsToScore == 3)
            {
                ++ScoreMult;
                thingsToScore = 0;
                return;
            }
            ++thingsToScore;
        }
        else if (successes.failed)
        {
            ScoreMult = 1;
            thingsToScore = 0;
        }
    }
    //Corutine for game over.
    IEnumerator GameOver()
    {
        isOver = true;
        Time.timeScale = .4f;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
    //corutine for when level is complete
    IEnumerator WellDone()
    {
        Time.timeScale = .4f;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    //Camera shake code by ftvs from https://gist.github.com/ftvs/5822103
    //modified for more appropriatte shake
    public void CameraShake()
    {
        {
            //During shake duration, set the camera position to a new on inside a spere of radius of 1 * shake amount.
            if (shakeDuration > 0)
            {
                Camera.main.transform.position = originalCameraPosition + Random.insideUnitSphere * shakeAmount;

                shakeDuration -= Time.deltaTime;
            }
            else
            {
                //when shaking is done, reset the camera to its original position
                shakeDuration = 0f;
                Camera.main.transform.position = originalCameraPosition;
            }
        }
    }


}
