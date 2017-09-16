using UnityEngine;
using System.Collections;

public class instiate_zombie : MonoBehaviour {

    public GameObject zombie_prefab;
    public GameObject parent;
    public Transform[] poses;
	// Use this for initialization
	void Start () {
        Create();
     }
	
	



    void Create()
    {

        // remember to instantiate later
        InvokeRepeating("CreateNow", Random.Range(.1f, 1f),2f); // randomly between 2 and 3 seconds
    }

    void CreateNow()
    {
        if (GameObject.FindGameObjectsWithTag("skeleton").Length < 30){
            // create the new object
            GameObject go = Instantiate(zombie_prefab);
            // init some properties of the new object
            go.transform.position = poses[Random.Range(0, poses.Length)].transform.position;
            go.name = "foo";
            go.gameObject.transform.parent = parent.transform;
            go.transform.localScale = new Vector3(4, 4, 4);
        }
    }
}
