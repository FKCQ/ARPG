using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharactorStats))]
public class HealthUI : MonoBehaviour {
	public GameObject uiPrefab;
	public Transform target;
	public float visibleTime = 3f;

	private Transform ui;
	private Image healthSlider;
	private Transform cam;
	private float lastDamageTime;
	private void Start() {
		cam = Camera.main.transform;
		foreach (Canvas c in FindObjectsOfType<Canvas>()) {
			if (c.renderMode == RenderMode.WorldSpace) {
				ui = Instantiate(uiPrefab, c.transform).transform;
				healthSlider = ui.GetChild(0).GetComponent<Image>();
				break;
			}
		}
		GetComponent<CharactorStats>().onHealthChange += OnhealthChanged;
	}
	public void OnhealthChanged(int maxHealth, int currentHealth) {
		if(ui != null) {
			float healthPercent = (float)currentHealth / maxHealth;
			healthSlider.fillAmount = healthPercent;
			ui.gameObject.SetActive(true);
			lastDamageTime = Time.time;

			if (currentHealth <= 0)
				Destroy(ui.gameObject);
		}
	}
	// Update is called once per frame
	void LateUpdate () {
		if(ui != null) {
			ui.position = target.position;
			ui.forward = -cam.forward;
			if (Time.time - lastDamageTime > visibleTime) {
				ui.gameObject.SetActive(false);
			}
		}
	}
}
