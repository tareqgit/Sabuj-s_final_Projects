using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttom : MonoBehaviour {
    GroundClick Gclick;
    public GameObject GO;
    public Text t;
	void Start()
    {
        Gclick = GO.GetComponent<GroundClick>();
    }
    public void create_T()
    {
        Gclick.createRoad();
        t.text = "Node: "+GroundClick.i;
    }
	
}
