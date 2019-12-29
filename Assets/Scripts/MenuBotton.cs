using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBotton : MonoBehaviour {

	// Startbutton
	public void StartGameButtonClicked () {
        SceneManager.LoadScene("SampleScene");
	}

    //Customize Botton
    public void CustomizeClicked() {
        SceneManager.LoadScene("SampleScene");
    }

    public void GotoMenuClicked()
    {
        SceneManager.LoadScene("Menu");
    }
}
