using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonL_R : MonoBehaviour {
    [SerializeField]
    public GameObject player;
    private Bodybehaviour pBodybehaviour;

    //押しっぱなし判定の間隔
    public float intervalAction = 0.02f;

    //次の押下判定時間
    float nextTimeL = 0f;
    float nextTimeR = 0f;
    float nextTimeF = 0f;
    float nextTimeBk = 0f;

    float nextTimeRR = 0f;
    float nextTimeRL = 0f;

    //押下状態
    public bool pressedL;
    public bool pressedR;
    public bool pressedF;
    public bool pressedBk;

    public bool pressedRR;
    public bool pressedRL;

    //ボタンのアタッチ
    public void setPlayer(GameObject player)
    {
        this.player = player;
        pBodybehaviour = player.GetComponent<Bodybehaviour>();
    }

    //前進ボタン
    public void OnFbuttonClick()
    {
        //Debug.Log("Fbutton Click");

        Transform tf = player.transform;
        tf.Translate(Vector3.forward * 0.1f);

    }

    public void OnFbuttonDown()
    {
        pressedF = true;
        nextTimeF = Time.realtimeSinceStartup + intervalAction;
    }

    public void OnFbuttonUp()
    {
        pressedF = false;
    }



    //Lボタン
    public void OnLbuttonClick()
	{
        //Debug.Log("Lbutton Click");

        Transform tf = player.transform;
        tf.Translate(Vector3.left*0.1f);
        
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


    //Rボタン
    public void OnRbuttonClick()
    {
        //Debug.Log("RbuttonClick");
        Transform tf = player.transform;
        tf.Translate(Vector3.right * 0.1f);
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

    //後進ボタン
    public void OnBkbuttonClick()
    {
        //Debug.Log("BkbuttonClick");
        Transform tf = player.transform;
        tf.Translate(Vector3.back * 0.1f);
    }

    public void OnBkbuttonDown()
    {
        pressedBk = true;
        nextTimeBk = Time.realtimeSinceStartup + intervalAction;
    }
    public void OnBkbuttonUp()
    {
        pressedBk = false;
    }

    public void OnRRbuttonClick()
    {
       //Debug.Log("RRbuttonClick");
        Transform tf = player.transform;
        tf.Rotate(new Vector3 (0,1,0));

    }

    public void OnRRbuttonDown()
    {
        pressedRR = true;
        nextTimeRR = Time.realtimeSinceStartup + intervalAction;
    }

    public void OnRRbuttonUp()
    {
        pressedRR = false;
    }


    public void OnRLbuttonClick()
    {
        //Debug.Log("RLbuttonClick");
        Transform tf = player.transform;
        tf.Rotate(new Vector3(0, -1, 0));

    }

    public void OnRLbuttonDown()
    {
        pressedRL = true;
        nextTimeRL = Time.realtimeSinceStartup + intervalAction;
    }

    public void OnRLbuttonUp()
    {
        pressedRL = false;
    }

    public void OnAbuttonDown()
    {
        pBodybehaviour.AttackTrigger(true);
        
    }

    public void OnBbuttonDown()
    {
        pBodybehaviour.AttackTrigger(false);

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (pressedF && Time.realtimeSinceStartup < nextTimeF)
        {
            nextTimeF = Time.realtimeSinceStartup + intervalAction;
            OnFbuttonClick();
        }

        if (pressedL && Time.realtimeSinceStartup < nextTimeL)
        {
            nextTimeL = Time.realtimeSinceStartup + intervalAction;
            OnLbuttonClick();
        }
		
        if (pressedR && Time.realtimeSinceStartup < nextTimeR)
        {
            nextTimeR = Time.realtimeSinceStartup + intervalAction;
            OnRbuttonClick();
        }

        if (pressedBk && Time.realtimeSinceStartup < nextTimeBk)
        {
            nextTimeBk = Time.realtimeSinceStartup + intervalAction;
            OnBkbuttonClick();
        }
        if (pressedRR && Time.realtimeSinceStartup < nextTimeRR)
        {
            nextTimeRR = Time.realtimeSinceStartup + intervalAction;
            OnRRbuttonClick();
        }
        if (pressedRL && Time.realtimeSinceStartup < nextTimeRL)
        {
            nextTimeRL = Time.realtimeSinceStartup + intervalAction;
            OnRLbuttonClick();
        }


    }
}
