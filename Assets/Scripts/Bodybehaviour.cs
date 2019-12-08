using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodybehaviour : MonoBehaviour {
    protected Animator animator;
    private int isAttackHash;

    public void AttackTrigger()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.nameHash != isAttackHash)
        {
            animator.SetBool("isAttack", true);
        }
    }

    // Use this for initialization
    void Start () {
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        isAttackHash = Animator.StringToHash("Base Layer.Attack");
	}
	
	// Update is called once per frame
	void Update () {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.nameHash == isAttackHash)
        {
            animator.SetBool("isAttack",false);
        }
    }

   
}

