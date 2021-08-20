using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanBehavior : MonoBehaviour
{

    private Animator anim;
    private NavMeshAgent agent;
    public GameObject target;

    //public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        anim.SetInteger("State", 1);
        //agent.enabled = false;
        //anim.SetBool("isWalk", true);
        //agent.enabled = false;



    }

    // Update is called once per frame
    void Update()
    {
       // if (agent.enabled)
      //  {

            agent.SetDestination(target.transform.position);
            //anim.SetInteger("State", 1);
        //}
            
        //if (Input.GetKey("x"))
           // anim.SetBool("IsWalking", true);
        //else if(Input.GetKey("z") )
            //anim.SetBool("IsWalking", false);
        //anim.SetBool("isWalk", true);
        //     if (agent.enabled)
        //     {
        //         anim.SetBool("isWalk", true);
        //        agent.SetDestination(target.transform.position);


        //    }
    }
}
