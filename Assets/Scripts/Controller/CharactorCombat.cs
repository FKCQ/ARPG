using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharactorStats))]
public class CharactorCombat : MonoBehaviour {
	private CharactorStats charactorStats;
	public float attackSpeed = 1;
	public float attackDelay = 0.5f;
	private float cooldown = 0;
	private float lastTimeAttackTime;
	private float combatCooldown = 3f;
	public bool isCombat { get; private set; }
	public event System.Action OnAttack;

	CharactorStats oppon;
	// Use this for initialization
	void Start () {
		charactorStats = GetComponent<CharactorStats>();
	}

	private void Update() {
		if(Time.time - lastTimeAttackTime > combatCooldown) {
			isCombat = false;
		}
		cooldown -= Time.deltaTime;
	}

	public void Attack(CharactorStats targetStats) {
		if(cooldown <= 0) {
			oppon = targetStats;
			if (OnAttack != null)
				OnAttack();

			cooldown = 1f / attackSpeed;
			isCombat = true;
			lastTimeAttackTime = Time.time;
		}
	}
	public void AttackHit_AnimationEvent() {
		oppon.TakeDamage(charactorStats.damage.GetValue());

		if (oppon.currentHealth <= 0)
			isCombat = false;
	}
}
