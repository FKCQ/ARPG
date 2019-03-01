using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharactorAnimation : MonoBehaviour {
	public AnimationClip replacableClip;
	public AnimationClip[] defaultAnimation;
	public AnimationClip[] currentAnimation;
	public float speed = 5f;
	protected Animator anim;
	public AnimatorOverrideController overrideController;

	private NavMeshAgent agent;
	private CharactorCombat combat;
	private float dampTime = .01f;
	// Use this for initialization
	protected virtual void Start() {
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponentInChildren<Animator>();
		combat = GetComponent<CharactorCombat>();
		if(overrideController == null) {
			overrideController = new AnimatorOverrideController(anim.runtimeAnimatorController);
		}
		anim.runtimeAnimatorController = overrideController;

		currentAnimation = defaultAnimation;

		combat.OnAttack += Attack;
	}

	// Update is called once per frame
	protected virtual void Update() {
		speed = agent.velocity.magnitude / agent.speed;
		anim.SetFloat("Speed", speed, dampTime, Time.deltaTime);
		anim.SetBool("IsCombat", combat.isCombat);


	}

    public void Move(ETCJoystick move)
    {
        PlayerController pc = GetComponent<PlayerController>();
        pc.RemoveFocus();
        speed = Vector2.Distance(move.followOffset, Vector2.zero) * move.tmSpeed;
        anim.SetFloat("Speed", speed, dampTime, Time.deltaTime);
    }
	private void Attack() {
		anim.SetTrigger("Attack");
		int randomAttackClip = Random.Range(0, currentAnimation.Length);
		overrideController[replacableClip.name] = currentAnimation[randomAttackClip];
	}
}
