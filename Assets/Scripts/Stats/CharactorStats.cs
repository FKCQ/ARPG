using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorStats : MonoBehaviour {
	public event System.Action<int, int> onHealthChange;
	public int maxHealth = 100;
	public int currentHealth { get; private set; }

	public Stat armor;
	public Stat damage;

	private void Awake() {
		currentHealth = maxHealth;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.A))
			TakeDamage(10);
	}

	public void TakeDamage(int damage) {
		damage -= armor.GetValue();
		damage = Mathf.Clamp(damage,0, int.MaxValue);

		Debug.Log(transform.name + " takes " + damage + " damages");
		currentHealth -= damage;

		if(onHealthChange != null) {
			onHealthChange(maxHealth, currentHealth);
		}

		if (currentHealth <= 0) {
			currentHealth = 0;
			Die();
		}
	}


	public virtual void Die() {
		Debug.Log(transform.name + " Die!");
	}
}
