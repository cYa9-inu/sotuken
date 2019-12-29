using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBotton : MonoBehaviour {

	// Use this for initialization
	public void StartGameButtonClicked () {
        SceneManager.LoadScene("SampleScene");
	}

    // Update is called once per frame
    public void CustomizeClicked() {
        SceneManager.LoadScene("SampleScene");
    }
}
