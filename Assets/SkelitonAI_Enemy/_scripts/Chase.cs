using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour
{
    public Transform target;
   private Animator animator;
    private int Health;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - this.transform.position;
        /* if we need Angle view..So that our enemy will only see in his forward
        float angle = Vector3.Angle(direction, this.transform.forward);
          if (Vector3.Distance(target.position, this.transform.position) < 10 && angle<30) //for 30degree angle view
        */

        if (Vector3.Distance(target.position, this.transform.position) < 50)
        {
        
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), 0.1f);
            animator.SetBool("isIdle", false);
            Debug.Log(direction.magnitude);
            if (direction.magnitude > 1f)
            {
                this.transform.Translate(0, 0, 0.001f);
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
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
        }
    }


}

