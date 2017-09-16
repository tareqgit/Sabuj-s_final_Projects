using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class castle_manager : MonoBehaviour {
    public static castle_manager instance;
    public float castle_health=100;
    public Text life;
     void Awake()
    {
        instance = this;   
    }


   
	
	// Update is called once per frame
	void Update () {
        life.text =(int) castle_health + "";

        if (castle_health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
