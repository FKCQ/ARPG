using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorAnimationEventReceiver : MonoBehaviour {
	public CharactorCombat combat;
	public void AttackHitEvent() {
		combat.AttackHit_AnimationEvent();
	}
}
