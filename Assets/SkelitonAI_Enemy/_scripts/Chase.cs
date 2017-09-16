using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour
{
    public Transform target;
    private Animator animator;
    private int Health;
    public static Chase instance;

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("home").transform;
        }
    }


    void FixedUpdate()
    {
        RaycastHit hit;
        // Debug.DrawRay(transform.position, transform.forward*100, Color.white);
        if (Physics.Raycast(transform.position, transform.forward * 1.2f, out hit, 20.0f))
        {
            if (hit.transform.gameObject.tag != "home")
            {
                if (hit.distance < 20)
                {

                    this.transform.Translate(.1f, 0, 0f);
                }
            }
        }
        if (GameObject.FindGameObjectWithTag("road") != null)
        {
            Debug.Log(Vector3.Distance(GameObject.FindGameObjectWithTag("road").transform.position, transform.position));

              if (Vector3.Distance(GameObject.FindGameObjectWithTag("road").transform.position, transform.position) < 100)
            {
                transform.position = GameObject.FindGameObjectWithTag("road").transform.position;
                    Debug.Log("Road Trigerred");
                walk = true;
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", true);
            }

        }
    }
    bool walk=false;
    // Update is called once per frame
    void Update()
    {


        if (walk == false)
        {
            Vector3 direction = target.position - this.transform.position;
            /* if we need Angle view..So that our enemy will only see in his forward
            float angle = Vector3.Angle(direction, this.transform.forward);
              if (Vector3.Distance(target.position, this.transform.position) < 10 && angle<30) //for 30degree angle view
            */
            //Debug.Log("first_pos" + Vector3.Distance(target.position, this.transform.position));
            if (Vector3.Distance(target.position, this.transform.position) > 140)
            {

                direction.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                            Quaternion.LookRotation(direction), 0.1f);
                animator.SetBool("isIdle", false);
                //  Debug.Log(direction.magnitude);
                if (direction.magnitude > 1f)
                {
                    this.transform.Translate(0, 0, .1f);
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isAttacking", false);
                }
                else
                {
                    animator.SetBool("isAttacking", true);
                    animator.SetBool("isWalking", false);
                }
            }
            else
            {
                //animator.SetBool("isIdle", true);
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", true);
                Debug.Log("Trigger with target");
                castle_manager.instance.castle_health = castle_manager.instance.castle_health - .01f;

            }
        }
    }
    public  void m_Die (){
        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isDie", true);
    }        
}
    


