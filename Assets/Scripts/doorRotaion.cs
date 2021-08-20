using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorRotaion : MonoBehaviour
{
    private Animator anim;
    private AudioSource doorSound;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("opening", true);
        doorSound.PlayDelayed(1.5f);
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("opening", false);
        doorSound.PlayDelayed(1.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
