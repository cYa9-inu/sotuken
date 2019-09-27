using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonA_B : MonoBehaviour {
    [SerializeField]
    public GameObject doggy;

    //Aボタン
    //押しっぱなし判定の間隔
    public float intervalAction = 0.02f;

    //次の押下判定時間
    float nextTimeA = 0f;
    float nextTimeB = 0f;

    //押下状態
    public bool pressedA;
    public bool pressedB;

	public void OnAbuttonClick()
	{
        Debug.Log("Abutton Click");

        Vector3 pos = doggy.transform.position;
        pos.x += 0.1f;
        doggy.transform.position = pos;
	}

    public void OnAbuttonDown()
    {
        pressedA = true;
        nextTimeA = Time.realtimeSinceStartup + intervalAction;
    }

    public void OnAbuttonUp()
    {
        pressedA = false;
    }


    //Bボタン
    public void OnBbuttonClick()
    {
        Debug.Log("BbuttonClick");
        Vector3 pos = doggy.transform.position;
        pos.x -= 0.1f;
        doggy.transform.position = pos;
    }

    public void OnBbuttonDown()
    {
        pressedB = true;
        nextTimeB = Time.realtimeSinceStartup + intervalAction;
    }
    public void OnBbuttonUp()
    {
        pressedB = false;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(pressedA && Time.realtimeSinceStartup < nextTimeA)
        {
            nextTimeA = Time.realtimeSinceStartup + intervalAction;
            OnAbuttonClick();
        }
		
        if (pressedB && Time.realtimeSinceStartup < nextTimeB)
        {
            nextTimeB = Time.realtimeSinceStartup + intervalAction;
            OnBbuttonClick();
        }
	}
}
