using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
	public float radius = 5f;
	public Transform interactionTransform;
	bool hasInteraction = false;
	bool isFocus = false;
	Transform player;
	private void OnDrawGizmosSelected() {
		if (interactionTransform == null)
			interactionTransform = transform;
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

	public virtual void Interact() {
		Debug.Log("Interact with " + transform.name);
	}
	// Update is called once per frame
	public void Update () {
		if(isFocus && !hasInteraction) {
			float distance = Vector3.Distance(player.position, interactionTransform.position);
			if (distance <= radius) {
				Interact();

				hasInteraction = true;
			}
		}
	}

	public void OnFocused(Transform playerTransform) {
		isFocus = true;
		hasInteraction = false;
		player = playerTransform; 
	}

	public void OnDefocused() {
		isFocus = false;
		hasInteraction = false;
		player = null;
	}
}
