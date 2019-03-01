using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName ="Inventory/Item")]
public class Item : ScriptableObject {
	new public string name = "New Item";
	public Sprite icon = null;
	public bool isDefaultItem = false;

	public virtual void Use() {
		//use the item
		//something will happen

		Debug.Log("Using " + name);
	}

	public void RemovefromInventory() {
		Inventory.instance.Remove(this);
	}
}
