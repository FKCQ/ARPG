using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {
	#region Singleton
	public static EquipmentManager instance;

	private void Awake() {
		if(instance != null) {
			Debug.Log("More than one 'EqupmentManager' script!");
			return;
		}
		instance = this;
	}
	#endregion

	public delegate void OnEquipmentChange(Equipment newItem, Equipment oldItem);
	public OnEquipmentChange onEquipmentChange;
	Inventory inventory;
	public SkinnedMeshRenderer targetMesh;
	public SkinnedMeshRenderer[] currentMesh;
	public Equipment[] currentEquipment;
	public Equipment[] defaultItem;
	// Use this for initialization
	void Start () {
		int numSlots = System.Enum.GetNames(typeof(EquipmentSlots)).Length;
		currentEquipment = new Equipment[numSlots];
		currentMesh = new SkinnedMeshRenderer[numSlots];
		inventory = Inventory.instance;

		EquipDefaultItem();
	}
	
	public void Equip(Equipment newItem) {
		int slotIndex = (int)newItem.equipSlot;
		Equipment oldItem = Unequip(slotIndex);

		if (onEquipmentChange != null) {
			onEquipmentChange.Invoke(newItem, oldItem);
		}

		SetEquipmentBlendShape(newItem, 100);

		currentEquipment[slotIndex] = newItem;

		//生成装备图象，附于角色身上，即穿上装备
		SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
		newMesh.transform.parent = targetMesh.transform;
		newMesh.bones = targetMesh.bones;
		newMesh.rootBone = targetMesh.rootBone;

		currentMesh[slotIndex] = newMesh;

	}

	public Equipment Unequip(int slotIndex) {
		if (currentEquipment[slotIndex] != null) {
			if(currentMesh[slotIndex] != null) {
				Destroy(currentMesh[slotIndex].gameObject);
			}

			Equipment oldItem = currentEquipment[slotIndex];
			inventory.Add(oldItem);

			SetEquipmentBlendShape(oldItem, 0);

			currentEquipment[slotIndex] = null;

			if (onEquipmentChange != null) {
				onEquipmentChange.Invoke(null, oldItem);
			}
			return oldItem;
		}
		return null;
	}

	public void SetEquipmentBlendShape(Equipment item,int wight) {
		//如果item.coverMeshRegion为Arms，Torso
		foreach(EquipmentMeshRegion blendShape in item.coverMeshRegion) {
			//第一次循环blendShape为Arms
			//第二次为Torso
			Debug.Log(blendShape);
			targetMesh.SetBlendShapeWeight((int)blendShape, wight);
		}
	}

	public void EquipDefaultItem (){
		foreach(Equipment item in defaultItem) {
			Equip(item);
		}
	}

	
	public void UnequipAll() {
		for(int i = 0; i < currentEquipment.Length; i++) {
			Unequip(i);
		}
		EquipDefaultItem();
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.U)) {
			UnequipAll();
		}
	}
}
