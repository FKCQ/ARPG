using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable {
	PlayerManager playerManager;
	CharactorStats charactorStats;

	private void Start() {
		playerManager = PlayerManager.instance;
		charactorStats = GetComponent<CharactorStats>();
	}
	public override void Interact() {
		base.Interact();

		CharactorCombat playerCombat = playerManager.player.GetComponent<CharactorCombat>();
		if(playerCombat != null) {
			playerCombat.Attack(charactorStats);
		}
	}
}
