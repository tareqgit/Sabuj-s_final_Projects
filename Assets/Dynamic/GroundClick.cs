using UnityEngine;
using System.Collections;

public class GroundClick : MonoBehaviour {
    public GameObject parentObjj;
	public GameObject prefabNode;
	public GameObject prefabRoad;
	
	GameObject nodeStart;

    GameObject[] nodes=new GameObject[10];
  public static  int i =0 ;
	void Update() {
		if(Input.GetMouseButtonDown(0)) { //that means left click

            Vector3 roadStart; //for taking start position

            if ( ClickLocation(out roadStart) ) {//if it contain a location where we can create an object
                                                 //nodeStart = (GameObject)Instantiate(prefabNode, roadStart, Quaternion.identity); //so we creating the node as Strat Node


                nodes[i] = (GameObject)Instantiate(prefabNode, roadStart, Quaternion.identity);
                if (parentObjj != null)
                {
                    nodes[i].transform.parent = parentObjj.transform;
                }
                    //  nodeStart.GetComponent<NodeClick>().ground = this; //this is for which ground the node using now.
                nodes[i].GetComponent<NodeClick>().ground = this; //this is for which ground the node using now.

                i++;
            }
		}
	/*	
		if(Input.GetMouseButtonUp(0)) { //that we release the left click
			Vector3 roadEnd; //here we will create second Node
			
			if( nodeStart!=null && ClickLocation(out roadEnd) ) { //if nodeStart is not equal null and and location is clicking now is also not null
				GameObject nodeEnd = (GameObject)Instantiate(prefabNode, roadEnd, Quaternion.identity); //so we will create the second node in here
				nodeEnd.GetComponent<NodeClick>().ground = this;//this is for which ground the node using now
				
				CreateRoad(nodeStart.transform.position, nodeEnd.transform.position); //this is the line what is responsible for creating Road between the nodes
			}
			else if ( nodeStart != null && ClickLocationNode(out roadEnd) ) {
				CreateRoad(nodeStart.transform.position, roadEnd); 
			}
			
			nodeStart = null;
		}
        */
     /*   if(Input.GetMouseButton(1))
        {
            Destroy(GameObject.FindGameObjectWithTag("road"));
           
            for(int j = 0; j < i-1; j++)
            {
                Debug.Log("" + i + ":" + j); 
                CreateRoad(nodes[j].transform.position, nodes[j + 1].transform.position);
            }
        }
        */
        
	}


    public  void createRoad()
    {
        Debug.Log("tareq");
            Destroy(GameObject.FindGameObjectWithTag("road"));

            for (int j = 0; j < i - 1; j++)
            {
                Debug.Log("" + i + ":" + j);
                CreateRoad(nodes[j].transform.position, nodes[j + 1].transform.position);
            }
        
    }
	
	public void SetNodeStart(GameObject n) {
		Debug.Log ("NodeStart: " + n.transform.position);
		nodeStart = n;
	}
	
	public void SetNodeEnd(GameObject n) {
		Debug.Log ("NodeStart: " + nodeStart.transform.position);
		Debug.Log ("NodeEnd: " + n.transform.position);
	//	CreateRoad(nodeStart.transform.position, n.transform.position);
		nodeStart = null;
	}
	
	bool ClickLocation(out Vector3 point) {
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition ); //making a ray at the point where user indicating with the mouse
		
		RaycastHit hitInfo = new RaycastHit(); 
		if( Physics.Raycast( ray, out hitInfo, Mathf.Infinity ) ) {
			if( hitInfo.collider == GetComponent<Collider>() ) { //if the raycast hit a collider
				point = hitInfo.point; //where it hit
				return true;
			}
		}
		point = Vector3.zero;
		return false;
	}
		
	bool ClickLocationNode(out Vector3 point) {
		Debug.Log ("ClickLocationNode");
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		
		RaycastHit hitInfo = new RaycastHit();
		if( Physics.Raycast( ray, out hitInfo, Mathf.Infinity ) ) {
			Debug.Log (hitInfo.collider.gameObject.name);
			if( hitInfo.collider.transform.parent!=null && hitInfo.collider.transform.parent.tag == "Node" ) {
				point = hitInfo.collider.transform.position;
				return true;
			}
		}
		point = Vector3.zero;
		Debug.Log ("false");
		return false;
	}
		
	void CreateRoad( Vector3 roadStart, Vector3 roadEnd ) {
		float width = 1;
		float length = Vector3.Distance(roadStart, roadEnd);
		
		if(length < 1) {
			return;
		}
		
		GameObject road = (GameObject)Instantiate(prefabRoad);
        road.transform.parent = parentObjj.transform;
		road.transform.position = roadStart + new Vector3(0, 0.01f, 0);
		
		road.transform.rotation = Quaternion.FromToRotation( Vector3.right, roadEnd - roadStart );
		Debug.Log (road.transform.rotation.eulerAngles);
	
		Vector3[] vertices = {
				new Vector3(0, 		0, -width/2),
				new Vector3(length, 0, -width/2),
				new Vector3(length, 0,  width/2),
				new Vector3(0, 		0,  width/2)
			};

		int[] triangles = {
				1, 0, 2,	// triangle 1
				2, 0, 3		// triangle 2
			};
		

		Vector2[] uv = {
				new Vector2(0, 0),
				new Vector2(length, 0),
				new Vector2(length, 1),
				new Vector2(0, 1)
			};
		
		Vector3[] normals = {
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up
			};
		
		Mesh mesh = new Mesh();

		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.uv = uv;
		mesh.normals = normals;
		
		MeshFilter mesh_filter = road.GetComponent<MeshFilter>();
     MeshFilter[] mesfilters=road.GetComponentsInChildren<MeshFilter>();
        mesh_filter.mesh = mesh;
        foreach(MeshFilter mFilter in mesfilters)
        {
            mFilter.mesh = mesh;
        }
		
		
	}
	
}
