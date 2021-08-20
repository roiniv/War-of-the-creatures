using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject playerCamera;
    private CharacterController controller;
    private float speed = 0.2f;
    private float rx = 0, ry;
    private float angularSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();//gets player controller

    }

    // Update is called once per frame
    void Update()
    {
        //mouse
        rx -= Input.GetAxis("Mouse Y") * angularSpeed;
        //ry += Input.GetAxis("Mouse X") * angularSpeed;
        ry = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * angularSpeed;


        transform.localEulerAngles = new Vector3(rx, ry, 0);//sets new orientation of player




        //keyboard
        float dx, dz;
        dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;//horizontal means "A" "D"        Vector3 motion = new Vector3(dx, 0, dz);
        dz = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 motion = new Vector3(dx, 0, dz);
        motion = transform.TransformDirection(motion);
        controller.Move(motion);

    }
}
