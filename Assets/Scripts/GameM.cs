using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameM : MonoBehaviour {

    Slider p1Slider, p2Slider;
    [SerializeField] GameObject gameSet,BackMenu;
    [SerializeField] GameObject[] buttons;


	// Use this for initialization
	void Start () {
        p1Slider = GameObject.Find("P1HP").GetComponent<Slider>();
        p2Slider = GameObject.Find("P2HP").GetComponent<Slider>();
    }
	public void setValueHPSlider(bool isP1,float value)
    {
        Slider slider
        = (isP1 ? p1Slider : p2Slider); 
        slider.value -= value;
        if(slider.value <= 0)
        {
            GameSet(!isP1);
        }

    }

    private void GameSet(bool isWinP1)
    {
        gameSet.GetComponent<Text>().text = (isWinP1 ?
        "P1" : "P2") + "Win";
        gameSet.SetActive(true);
        BackMenu.SetActive(true);

        foreach(GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
