using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

	public GameObject ab;
	public 	GameObject ba;
	public bool trigger = false;
	public	AudioSource aud;
	// Update is called once per frame
	void Update () {

		for (var i = 0; i < Input.touchCount; ++i) {


			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {

				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
				RaycastHit hit;

					if (Input.GetTouch (i).tapCount == 2|| Input.GetTouch (i).phase == TouchPhase.Moved) {
					if (Physics.Raycast (ray, out hit) && hit.transform.gameObject.tag ==
					    "Target") {
									
						if (!trigger) {
							aud.Play ();
							hit.transform.gameObject.GetComponent<SimpleMove> ().enabled = true;
							hit.transform.gameObject.GetComponent<SimpleRotateScale> ().enabled = true;
							trigger = true;
						} else {
							
							aud.Play ();
							hit.transform.gameObject.GetComponent<SimpleMove> ().enabled = false;
							hit.transform.gameObject.GetComponent<SimpleRotateScale> ().enabled = false;
							trigger = false;
				
						}
					} else {
						GameObject[] go=GameObject.FindGameObjectsWithTag ("Target");
						foreach (GameObject ga in go) {
							aud.Play ();
							ga.gameObject.GetComponent<SimpleMove> ().enabled = false;
							ga.gameObject.GetComponent<SimpleRotateScale> ().enabled = false;
							trigger = false;
							}
						}
				
				}	

			}	
		}

	}
}
