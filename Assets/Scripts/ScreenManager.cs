using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    Slider p1Slider, p2Slider;
    void Start()
    {
        // スライダーを取得する
        p1Slider = GameObject.Find("P1HP").GetComponent<Slider>();
        p2Slider = GameObject.Find("P2HP").GetComponent<Slider>();
    }

    public void setValueHPSlier(bool isP1, float value)
    {
        (isP1 ? p1Slider : p2Slider).value -= value;
    }
}
