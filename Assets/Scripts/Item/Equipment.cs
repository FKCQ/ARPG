using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {
	public EquipmentSlots equipSlot;
	public SkinnedMeshRenderer mesh;
	public EquipmentMeshRegion[] coverMeshRegion;
	public int armorModifier;
	public int damageModifier;

	public override void Use() {
		base.Use();

		EquipmentManager.instance.Equip(this);
		RemovefromInventory();
		//remove it from the inventory
	}

	
}
public enum EquipmentSlots { Head, Chest, Legs, Weapon, Shield, Feet }
public enum EquipmentMeshRegion { Legs,Arms,Torso}