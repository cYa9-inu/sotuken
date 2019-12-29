using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodybehaviour : MonoBehaviour {
    protected Animator animator;
    private List<int>[] attacks = new List<int>[2];//0: Aボタン, 1:Bボタン
    private bool didGiveDamage = false;//単発攻撃用、ヒットフラグ
    //private int hissatsuNum = 0;//攻撃モーションNo
    private bool isHissatsu, isA;//連鎖攻撃中か, Aモーションか
    private GameM gameM;

    //当たり判定の処理
    private void OnCollisionStay(Collision collision)
    {
        //攻撃モーション中か
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsTag("Attack"))
        {
            string collisionName = collision.gameObject.name;
            //当たったのはプレイヤーか
            bool isPlayer = collisionName.Contains("Doggy") ||
                collisionName.Contains("Parrot") ||
                collisionName.Contains("beetle");
            if (isPlayer)
            {
                switch (animator.GetInteger("Assetnum"))
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
            gameM.setValueHPSlider(tag != "P1", 0.1f);

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
            gameM.setValueHPSlider(tag != "P1", 0.2f);

            didGiveDamage = true;
        }
    }

    //A,Bボタンが押下された時の処理
    public void AttackTrigger(bool isA)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!isHissatsu)
        {
            isHissatsu = true;
            this.isA = isA;
            StartCoroutine("AttackCoroutine");
        }
    }

    private IEnumerator AttackCoroutine()
    {
        int index = isA ? 0 : 1;
        for (int i = 0; i < attacks[index].Count; i++) {
            didGiveDamage = false;
            animator.SetInteger("Assetnum", attacks[index][i]);
            animator.SetBool("isAttack", true);
            yield return null;

            animator.SetBool("isAttack", false);
            yield return new WaitForSeconds(1.1f);
        }
        isHissatsu = false;
    }

    // Use this for initialization
    void Start () {
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        //GameMの読み込み
        gameM = GameObject.Find("Canvas").GetComponent<GameM>();

        //A,Bボタンの設定
        attacks[0] = new List<int>(); attacks[1] = new List<int>();

        attacks[0].Add(0);
        attacks[0].Add(1);
        attacks[0].Add(0);

        attacks[1].Add(0);
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if ("P1".Equals(this.gameObject.tag)) { Debug.Log(this.gameObject.tag + stateInfo.IsTag("Attack")); }
    }
}

