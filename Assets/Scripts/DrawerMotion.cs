using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerMotion : MonoBehaviour
{
    private Animator anim;
    private bool isDrawerClosed;
    public GameObject CrossHair;
    public GameObject CrossHairTouch;
    public GameObject aCamera;
    bool isTriggerHit;

    // Start is called before the first frame update
    void Start()
    {
        anim =this.gameObject.transform.parent.GetComponent<Animator>();
        isDrawerClosed = true;
        isTriggerHit = false;
    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
        {
           
                if (hit.transform.gameObject.name == this.gameObject.name && hit.distance<8)
                {
                    if (!isTriggerHit)
                    {
                        isTriggerHit = true;
                        CrossHair.SetActive(false);
                        CrossHairTouch.SetActive(true);
                    }
                    if(Input.GetButtonDown("TouchBtn"))
                        {
                        anim.SetBool("isOpen", isDrawerClosed);
                        isDrawerClosed = !isDrawerClosed;
                        }

                }
                else
                {
                    if(isTriggerHit)
                    {
                    isTriggerHit = false;
                    CrossHair.SetActive(true);
                    CrossHairTouch.SetActive(false);
                    }
                   
                }
            
        }
    }
}
