using UnityEngine;	

public class ItemPickup : Interactable {
	public Item item;
	public override void Interact() {
		base.Interact();
		PickUp();
	}

	public void PickUp() {
		bool wasPickedup = Inventory.instance.Add(item);

		if (wasPickedup) {
			Debug.Log("Picking up " + item.name);
			Destroy(gameObject);
		}
	}
}
