using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GroundClickOnAndOff : MonoBehaviour {
    GroundClick gc;
    public Text t;
	// Use this for initialization
	void Start () {
        gc = gameObject.GetComponent<GroundClick>();
	}
	
	// Update is called once per frame
	public void on_off () {
        if (gc.enabled == false)
        {
            t.text = " ON";
            gc.enabled = true;
        }else if (gc.enabled == true)
        {
            t.text = " OFF";
            gc.enabled = false;
        }
	}
}
