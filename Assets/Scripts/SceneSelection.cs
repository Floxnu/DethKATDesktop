using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour {


    //Two menu buttons, one for each of the two stages.
	public void On50ButtonDown()
    {
        SceneManager.LoadScene(1);
    }
    public void On100ButtonsDown()
    {
        SceneManager.LoadScene(2);
    }

}
