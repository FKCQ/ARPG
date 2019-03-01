using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	#region Singleton
	public static Inventory instance;

	private void Awake() {
		if(instance != null) {
			Debug.Log("More than one instance of Inventory found!");
			return;
		}
		instance = this;
	}

	#endregion
	public delegate void onItemChanged();
	public onItemChanged onItemChangeCallback;

	public int space = 5;
	public List<Item> items = new List<Item>();

	public bool Add(Item item) {
		if (!item.isDefaultItem) {
			if (items.Count >= space) {
				Debug.Log("I can't carry any more!");
				return false;
			}

			items.Add(item);
			if (onItemChangeCallback != null)
				onItemChangeCallback.Invoke();
		}

		return true;

		
	}

	public void Remove(Item item) {
		items.Remove(item);
		if (onItemChangeCallback != null)
			onItemChangeCallback.Invoke();
	}
}
