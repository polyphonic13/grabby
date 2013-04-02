using UnityEngine;
using System.Collections;

public class Hands : MonoBehaviour
{

	public float grabDistance = 1f;
	public LayerMask grabLayers;
	
	Vector3 originOffset;
	
	void Start ()
	{
		Camera c = GetComponentInChildren<Camera>();
		originOffset = c.transform.position - transform.position;
	}
	
	void Update ()
	{
		Debug.DrawRay(transform.position + originOffset, transform.forward * grabDistance, Color.red, 1f, false);
		if (Input.GetKeyUp(KeyCode.F)) {
			Interact();
		}
	}
		
	void Interact()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position + originOffset, transform.forward, out hit, grabDistance, grabLayers)) {
			Debug.Log ("Grabbed "+hit.transform.name);
		}
	}
}
