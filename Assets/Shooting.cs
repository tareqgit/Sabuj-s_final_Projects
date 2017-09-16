using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Shooting : MonoBehaviour {


	public ParticleSystem _muzzleFlash;
	public AudioSource _gunAudio;
    public AudioSource _shootingAudio;
    public GameObject _impactPrefabs;
	public Transform cameraTransform;

    public Text score_text;
    public int score;


	ParticleSystem _impactEffect;
	// Use this for initialization
	void Start () {
		_impactEffect = Instantiate (_impactPrefabs).GetComponent<ParticleSystem> ();

	}
    RaycastHit hit;

    // Update is called once per frame
    public void shoot_Update () {

        //	if (Input.GetKeyDown(KeyCode.Mouse1))
        //	CmdHitPlayer (gameObject);
        //	Debug.DrawRay (raypos, cameraTransform.forward, Color.red);
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            _muzzleFlash.Stop();
            _muzzleFlash.Play();
            _gunAudio.Stop();
            _gunAudio.Play();

        
			Vector3 raypos = cameraTransform.position + (1f * cameraTransform.forward);

			if (Physics.Raycast (raypos, cameraTransform.TransformDirection(Vector3.forward), out hit, 1000f)) {
		//	if (Physics.Raycast(transform.position, -Vector3.forward, out hit, 100.0f)){
				//Debug.Log ("hit");

                



                _impactEffect.transform.position = hit.point;
				_impactEffect.Stop ();
				_impactEffect.Play ();
				Invoke ("stopParticle", .5f);


				if (hit.transform.tag == "skeleton") {

                    StartCoroutine(Die());

                    score++;
                    score_text.text = score + "";

                    _shootingAudio.Stop();
                    _shootingAudio.Play();
				}
			}
		}
	}
	void stopParticle(){
		_impactEffect.Stop ();
	}

    IEnumerator Die()
    {
        hit.transform.gameObject.GetComponent<Chase>().m_Die();
        yield return new WaitForSeconds(5); //this will wait 5 seconds
        Destroy(hit.transform.gameObject);
    }
}