using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodybehaviour : MonoBehaviour {
    protected Animator animator;
    //private int isAttackHash;
    private ScreenManager scManager;
    private List<int>[] attacks = new List<int>[2];//0: Aボタン, 1:Bボタン
    private bool didGiveDamage = false;//単発攻撃用、ヒットフラグ
    private int hissatsuNum = 0;//攻撃モーションNo
    private bool isHissatsu, isA;//連鎖攻撃中か, Aモーションか

    private void OnCollisionStay(Collision collision)
    {
        //攻撃モーション中か
        if (animator.GetBool("isAttack"))
        {
            string collisionName = collision.gameObject.name;
            //当たったのはプレイヤーか
            bool isPlayer = collisionName.Contains("Doggy") ||
                collisionName.Contains("Parrot") ||
                collisionName.Contains("beetle");
            if (isPlayer)
            {
                switch (animator.GetInteger("assetNum"))
                {
                    case 0://頭突き攻撃
                        No0_Headbutt(collision);
                        break;
                    case 1://回転攻撃
                        No1_Rolling(collision);
                        break;
                }
                
            }
        }
    }

    //No0.頭突き攻撃
    private void No0_Headbutt(Collision collision)
    {
        if (!didGiveDamage)
        {
            Debug.Log("Hit Attack");
            //加力
            Vector3 vec = (collision.transform.position - transform.position);
            vec.y = 0;
            vec = vec.normalized * 100f;
            vec.y = 100f;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(vec);

            //HPバーを削る
            scManager.setValueHPSlier(tag != "P1", 0.1f);

            didGiveDamage = true;
        }
    }

    //No1.回転攻撃
    private void No1_Rolling(Collision collision)
    {
        if (!didGiveDamage)
        {
            Debug.Log("Hit Attack");
            //加力
            Vector3 vec = (collision.transform.position - transform.position);
            vec.y = 0;
            vec = vec.normalized * 300f;
            vec.y = 100f;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(vec);

            //HPバーを削る
            scManager.setValueHPSlier(tag != "P1", 1.0f);

            didGiveDamage = true;
        }
    }

    public void AttackTrigger(bool isA)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(!isHissatsu)
        {
            isHissatsu = true;
            this.isA = isA;
            hissatsuNum = 0;
            animator.SetInteger("assetNum", attacks[isA ? 0 : 1][hissatsuNum]);
            animator.SetBool("isAttack", true);
        }
    }

    // Use this for initialization
    void Start () {
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        //isAttackHash = Animator.StringToHash("Base Layer.Attack");

        //ScreenManagerの読み込み
        scManager = GameObject.Find("Canvas").GetComponent<ScreenManager>();

        //A,Bボタンの設定
        attacks[0] = new List<int>(); attacks[1] = new List<int>();
        attacks[0].Add(0);
        attacks[0].Add(1);
        attacks[0].Add(0);
    }
	
	// Update is called once per frame
	void Update () {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        //Debug.Log("called:" + stateInfo.tagHash);

        if (isHissatsu)
        {
  
            if (stateInfo.IsTag("Attack"))
            {
                didGiveDamage = false;
                animator.SetBool("isAttack", false);
            }
            else
            {
                hissatsuNum++;
                Debug.Log("num:" + hissatsuNum);
                if (hissatsuNum < attacks[isA ? 0 : 1].Count)//攻撃モーションが余っている。
                {
                    animator.SetInteger("assetNum", attacks[isA ? 0 : 1][hissatsuNum]);
                    animator.SetBool("isAttack", true);
                }
                else
                {
                    isHissatsu = false;
                }
            }
        }
    }

   
}

