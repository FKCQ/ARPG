using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float zoomSpeed = 5f;
	public float currentZoom = 15;
	public float pitch = 2f;
	public float minZoom = 10;
	public float maxZoom = 20;
	private float currentYaw = 0;
	private float yawSpeed = 100f;

	private void Update() {
		currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
		currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
		currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
	}

	private void LateUpdate() {
		transform.position = target.position - offset * currentZoom;
		transform.LookAt(target.position + Vector3.up * pitch);
		transform.RotateAround(target.position,Vector3.up, currentYaw);
	}
























	//public Transform target;
	//public Vector3 offset;
	//public float zoomSpeed = 3f;
	//public float yawSpeed = 100f;

	//private float minZoom = 10f;
	//private float maxZoom = 15f;
	//private float currentYaw = 0;
	//private float currentZoom = 10f;
	//public float pitch = 2f;
	//// Use this for initialization
	//void Start () {

	//}

	//// Update is called once per frame
	//void Update() {
	//	currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
	//	currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

	//	currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
	//}

	//private void LateUpdate() {
	//	transform.position = target.position - offset * currentZoom;
	//	transform.LookAt(target.position + Vector3.up * pitch);

	//	transform.RotateAround(target.position, Vector3.up, currentYaw);
	//}
}
