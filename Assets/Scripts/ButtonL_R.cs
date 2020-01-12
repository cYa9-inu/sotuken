using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonL_R : MonoBehaviour {
    [SerializeField]
    public GameObject p1player,p2player;
    private Bodybehaviour p1pBodybehaviour,p2Bodybehaviour;

    //押しっぱなし判定の間隔
    public float intervalAction = 0.02f;

    //次の押下判定時間
    //float nextTimeL = 0f;
    //float nextTimeR = 0f;
    //float nextTimeF = 0f;
    //float nextTimeBk = 0f;

    //float nextTimeRR = 0f;
    //float nextTimeRL = 0f;

    ////押下状態
    //public bool pressedL;
    //public bool pressedR;
    //public bool pressedF;
    //public bool pressedBk;

    //public bool pressedRR;
    //public bool pressedRL;

    //ボタンのアタッチ
    public void setPlayer(GameObject player1,GameObject player2)
    {
        this.p1player = player1;
        p1pBodybehaviour = p1player.GetComponent<Bodybehaviour>();

        this.p2player = player2;
        p2Bodybehaviour = p2player.GetComponent<Bodybehaviour>();

    }

    //前進ボタン
    public void OnFbuttonClick(GameObject player)
    {
        //Debug.Log("Fbutton Click");

        Transform tf = player.transform;
        tf.Translate(Vector3.forward * 0.1f);

    }

    public void OnFbuttonDown()
    {
    //    pressedF = true;
    //    nextTimeF = Time.realtimeSinceStartup + intervalAction;
    }

    public void OnFbuttonUp()
    {
        //pressedF = false;
    }



    //Lボタン
    public void OnLbuttonClick(GameObject player)
	{
        //Debug.Log("Lbutton Click");

        Transform tf = player.transform;
        tf.Translate(Vector3.left*0.1f);
        
	}

    //public void OnLbuttonDown()
    //{
    //    pressedL = true;
    //    nextTimeL = Time.realtimeSinceStartup + intervalAction;
    //}

    //public void OnLbuttonUp()
    //{
    //    pressedL = false;
    //}


    //Rボタン
    public void OnRbuttonClick(GameObject player)
    {
        //Debug.Log("RbuttonClick");
        Transform tf = player.transform;
        tf.Translate(Vector3.right * 0.1f);
    }

    //public void OnRbuttonDown()
    //{
    //    pressedR = true;
    //    nextTimeR = Time.realtimeSinceStartup + intervalAction;
    //}
    //public void OnRbuttonUp()
    //{
    //    pressedR = false;
    //}

    //後進ボタン
    public void OnBkbuttonClick(GameObject player)
    {
        //Debug.Log("BkbuttonClick");
        Transform tf = player.transform;
        tf.Translate(Vector3.back * 0.1f);
    }

    //public void OnBkbuttonDown()
    //{
    //    pressedBk = true;
    //    nextTimeBk = Time.realtimeSinceStartup + intervalAction;
    //}
    //public void OnBkbuttonUp()
    //{
    //    pressedBk = false;
    //}

    public void OnRRbuttonClick(GameObject player)
    {
       //Debug.Log("RRbuttonClick");
        Transform tf = player.transform;
        tf.Rotate(new Vector3 (0,1,0));

    }

    //public void OnRRbuttonDown()
    //{
    //    pressedRR = true;
    //    nextTimeRR = Time.realtimeSinceStartup + intervalAction;
    //}

    //public void OnRRbuttonUp()
    //{
    //    pressedRR = false;
    //}


    public void OnRLbuttonClick(GameObject player)
    {
        //Debug.Log("RLbuttonClick");
        Transform tf = player.transform;
        tf.Rotate(new Vector3(0, -1, 0));

    }

    //public void OnRLbuttonDown()
    //{
    //    pressedRL = true;
    //    nextTimeRL = Time.realtimeSinceStartup + intervalAction;
    //}

    //public void OnRLbuttonUp()
    //{
    //    pressedRL = false;
    //}

    public void OnAbuttonDown(Bodybehaviour pBodybehaviour)
    {
        pBodybehaviour.AttackTrigger(true);
        
    }

    public void OnBbuttonDown(Bodybehaviour pBodybehaviour)
    {
        pBodybehaviour.AttackTrigger(false);

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("w"))
        {
            //nextTimeF = Time.realtimeSinceStartup + intervalAction;
            OnFbuttonClick(p1player);
        }

        if (Input.GetKey("a"))
        {
            //nextTimeL = Time.realtimeSinceStartup + intervalAction;
            OnLbuttonClick(p1player);
        }
		
        if (Input.GetKey("d"))
        {
            //nextTimeR = Time.realtimeSinceStartup + intervalAction;
            OnRbuttonClick(p1player);
        }

        if (Input.GetKey("s"))
        {
            //nextTimeBk = Time.realtimeSinceStartup + intervalAction;
            OnBkbuttonClick(p1player);
        }
        if (Input.GetKey("e"))
        {
            //nextTimeRR = Time.realtimeSinceStartup + intervalAction;
            OnRRbuttonClick(p1player);
        }
        if (Input.GetKey("q"))
        {
            //nextTimeRL = Time.realtimeSinceStartup + intervalAction;
            OnRLbuttonClick(p1player);
        }
        if (Input.GetKey(KeyCode.R)) {
            OnAbuttonDown(p1pBodybehaviour);
            }
        if (Input.GetKey(KeyCode.F))
        {
            OnBbuttonDown(p1pBodybehaviour);
        }

        if (Input.GetKey(KeyCode.I))
        {
            OnFbuttonClick(p2player);
        }
        if (Input.GetKey(KeyCode.J))
        {
            OnLbuttonClick(p2player);
        }
        if (Input.GetKey(KeyCode.L))
        {
            OnRbuttonClick(p2player);
        }
        if (Input.GetKey(KeyCode.K))
        {
            OnBkbuttonClick(p2player);
        }
        if (Input.GetKey(KeyCode.O))
        {
            OnRRbuttonClick(p2player);
        }
        if (Input.GetKey(KeyCode.U))
        {
            OnRLbuttonClick(p2player);
        }
        if (Input.GetKey(KeyCode.P))
        {
            OnAbuttonDown(p2Bodybehaviour);
        }
        if (Input.GetKey(KeyCode.Semicolon))
        {
            OnBbuttonDown(p2Bodybehaviour);
        }
    }
}
