using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonL_R : MonoBehaviour {
    [SerializeField]
    public GameObject doggy;

    //Aボタン
    //押しっぱなし判定の間隔
    public float intervalAction = 0.02f;

    //次の押下判定時間
    float nextTimeL = 0f;
    float nextTimeR = 0f;

    //押下状態
    public bool pressedL;
    public bool pressedR;

	public void OnLbuttonClick()
	{
        Debug.Log("Lbutton Click");

        Vector3 pos = doggy.transform.position;
        pos.x += 0.1f;
        doggy.transform.position = pos;
	}

    public void OnLbuttonDown()
    {
        pressedL = true;
        nextTimeL = Time.realtimeSinceStartup + intervalAction;
    }

    public void OnLbuttonUp()
    {
        pressedL = false;
    }


    //Bボタン
    public void OnRbuttonClick()
    {
        Debug.Log("RbuttonClick");
        Vector3 pos = doggy.transform.position;
        pos.x -= 0.1f;
        doggy.transform.position = pos;
    }

    public void OnRbuttonDown()
    {
        pressedR = true;
        nextTimeR = Time.realtimeSinceStartup + intervalAction;
    }
    public void OnRbuttonUp()
    {
        pressedR = false;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(pressedL && Time.realtimeSinceStartup < nextTimeL)
        {
            nextTimeL = Time.realtimeSinceStartup + intervalAction;
            OnLbuttonClick();
        }
		
        if (pressedR && Time.realtimeSinceStartup < nextTimeR)
        {
            nextTimeR = Time.realtimeSinceStartup + intervalAction;
            OnRbuttonClick();
        }
	}
}
