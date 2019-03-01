using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharactorAnimation {
	public WeaponAnimations[] weaponAnimations;
	private Dictionary<Equipment, AnimationClip[]> attackAnimationDic;
	// Use this for initialization
	protected override void Start() {
		base.Start();
		EquipmentManager.instance.onEquipmentChange += OnEquipmentChanged;
		attackAnimationDic = new Dictionary<Equipment, AnimationClip[]>();
		foreach (WeaponAnimations a in weaponAnimations) {
			attackAnimationDic.Add(a.weapon, a.animation);
		}
	}

	// Update is called once per frame
	protected override void Update() {
		base.Update();
	}

	void OnEquipmentChanged(Equipment newItem, Equipment oldItem) { 
		if(newItem != null && newItem.equipSlot == EquipmentSlots.Weapon) {
			anim.SetLayerWeight(1, 1);
			if (attackAnimationDic.ContainsKey(newItem)) {
				currentAnimation = attackAnimationDic[newItem];
			}
		}else if(newItem == null && oldItem != null && oldItem.equipSlot == EquipmentSlots.Weapon) {
			anim.SetLayerWeight(1, 0);
			currentAnimation = defaultAnimation;
		}

		if (newItem != null && newItem.equipSlot == EquipmentSlots.Shield) {
			anim.SetLayerWeight(2, 1);
			if (attackAnimationDic.ContainsKey(newItem)) {
				currentAnimation = attackAnimationDic[newItem];
			}
		} else if (newItem == null && oldItem != null && oldItem.equipSlot == EquipmentSlots.Shield) {
			anim.SetLayerWeight(2, 0);
			currentAnimation = defaultAnimation;
		}
	}
	[System.Serializable]
	public struct WeaponAnimations
	{
		public Equipment weapon;
		public AnimationClip[] animation;
	}
	
}
