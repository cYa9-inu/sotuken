﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pop : MonoBehaviour {

    [SerializeField]
    private int p1 = 0, p2 = 1;
    //0:Doggy,1:Parrot,2:beelte
    private GameObject p1body, p2body;
    private GameObject camera;

	// Use this for initialization
	void Start () {
        camera = GameObject.Find("MainCamera");
        p1body = loadPrefabs(p1);
        p2body = loadPrefabs(p2);
        //プレイヤー１生成
        //初期リス位置
        p1body = Instantiate(loadPrefabs(p1), new Vector3(0.0f, 2.0f, -2.0f), Quaternion.identity);
        p1body.tag = "P1";
        camera.transform.parent = p1body.transform;
        camera.transform.localPosition = new Vector3(0.0f, 1.02f, -2.75f);
        camera.transform.localRotation = new Quaternion(0f, 0f, 0f,0f);

        //プレイヤー２生成
        Vector3 axis = new Vector3(0f, 1f, 0f);
        //回転軸
        Quaternion q1 = Quaternion.AngleAxis(180f, axis);
        //初期リス位置
        p2body = Instantiate(loadPrefabs(p2), new Vector3(0.0f, 2.0f, 2.0f), Quaternion.identity*q1);
        p2body.tag = "P2";
        //プレイヤー設定
        ButtonL_R script = GetComponent<ButtonL_R>();
        script.setPlayer(p1body, p2body);


    }

    private GameObject loadPrefabs(int type) {
        string path = "";
        switch (type)
        {
            case 0:
                path = "Prefabs/Doggy";
                break;
            case 1:
                path = "Prefabs/Parrot";
                break;
            case 2:
                path = "Prefabs/beetle";
                break;
        }
        return (GameObject)Resources.Load(path);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
