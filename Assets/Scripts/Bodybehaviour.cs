using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodybehaviour : MonoBehaviour {
    protected Animator animator;
    private GameM gameM;

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
                Debug.Log("Hit Attack");
                //加力
                Vector3 vec = (collision.transform.position - transform.position);
                vec.y = 0;
                vec = vec.normalized * 100f;
                vec.y = 100f;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(vec);

                //HPバーを削る
                gameM.setValueHPSlider(tag != "P1", 0.1f);
            }
        }
    }

    public void AttackTrigger(bool isA)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(!stateInfo.IsTag("Attack"))
        {
            animator.SetBool("isAttack", true);
        }
    }

    // Use this for initialization
    void Start () {
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        //GameMの読み込み
        gameM = GameObject.Find("Canvas").GetComponent<GameM>();
	}
	
	// Update is called once per frame
	void Update () {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.IsTag("Attack"))
        {
            animator.SetBool("isAttack",false);
        }
    }

   
}

