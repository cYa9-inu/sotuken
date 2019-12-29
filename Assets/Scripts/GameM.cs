using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameM : MonoBehaviour {

    Slider p1Slider, p2Slider;

	// Use this for initialization
	void Start () {
        p1Slider = GameObject.Find("P1HP").GetComponent<Slider>();
        p2Slider = GameObject.Find("P2HP").GetComponent<Slider>();
    }
	public void setValueHPSlider(bool isP1,float value)
    {
        (isP1 ? p1Slider : p2Slider).value -= value;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
