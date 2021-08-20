using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirstPersonMotion : MonoBehaviour
{
    public GameObject playerCamera;
    private CharacterController controller;
    private float speed = 40f;
    private float rx = 0f, ry;
    private float angularSpeed = 1f;
    private AudioSource stepFootSound;
    public GameObject enemy;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();//gets player controller
        stepFootSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //mouse
        rx -= Input.GetAxis("Mouse Y") * angularSpeed;
        ry = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * angularSpeed;
        playerCamera.transform.localEulerAngles = new Vector3(rx, 0, 0);


        transform.localEulerAngles = new Vector3(0, ry, 0);//sets new orientation of player




        //keyboard
        float dx=0, dz=0;
        if(Input.GetAxis("Horizontal")!=0|| Input.GetAxis("Vertical") != 0)
        {
            dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;//horizontal means "A" "D"        Vector3 motion = new Vector3(dx, 0, dz);
            dz = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            NavMeshAgent nma = enemy.GetComponent<NavMeshAgent>();
            Animator an = enemy.GetComponent<Animator>();
            if (!nma.enabled && an.GetInteger("NPCState") != 2)
            {
                nma.enabled = true;
                an.SetInteger("NPCState", 1);

            }
               
        }
        Vector3 motion = new Vector3(dx, -0.3f, dz);
        motion = transform.TransformDirection(motion);
        controller.Move(motion);
        if(!stepFootSound.isPlaying&&controller.velocity.magnitude>0.1f)
            stepFootSound.Play();

        
    }
}
