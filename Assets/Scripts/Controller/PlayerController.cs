using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
	public Interactable focus;
	public LayerMask layerMask;
	Camera camera;
	PlayerMotor playerMotor;
	// Use this for initialization
	void Start () {
		camera = Camera.main;
		playerMotor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		//if (Input.GetMouseButtonDown(0)) {
		//	Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		//	RaycastHit hit;
		//	if (Physics.Raycast(ray, out hit, layerMask)) {
		//		playerMotor.MoveToPoint(hit.point);

		//		RemoveFocus();
		//	}
		//}

		if(Input.touchCount==1) {
            if(Input.touches[0].phase == TouchPhase.Ended)
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			    RaycastHit hit;
			    if(Physics.Raycast(ray, out hit, 100)) {
				    Interactable item = hit.transform.GetComponent<Interactable>();
				    if(item)
					    SetFocus(item);
			    }
            }
			
		}
	}

	void SetFocus(Interactable newFocus) {
		if(focus != newFocus) {
			focus = newFocus;
		}
		
		focus.OnFocused(transform);
		playerMotor.FollowTarget(newFocus);
	}

	public void RemoveFocus() {
		if (focus != null)
			focus.OnDefocused();
		focus = null;

		playerMotor.StopFollowTarget();
	}
}
