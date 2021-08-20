using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GunShooting : MonoBehaviour
{
    public GameObject GunInHand1;
    public GameObject GunInHand2;
    public GameObject aCamera;
    public GameObject target;
    private LineRenderer lr;
    public GameObject MuzzleEnd1;
    public GameObject MuzzleEnd2;
    private AudioSource sound1;
    private AudioSource sound2;
    public ParticleSystem MuzzleFlash1;
    public ParticleSystem MuzzleFlash2;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Canvan;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent <LineRenderer>();
        sound1 = GunInHand1.GetComponent<AudioSource>();
        sound2 = GunInHand2.GetComponent<AudioSource>();
       
    }



    // Update is called once per frame
    void Update()
    {
        Animator anim1=Enemy1.GetComponent<Animator>();
        Animator anim2 = Enemy2.GetComponent<Animator>();
        if (anim1.GetInteger("NPCState") == 2&& anim2.GetInteger("NPCState") == 2)
        {
             Canvan.SetActive(true);
             AudioListener.pause = true;
             Time.timeScale = 0f;
        }

        if (Input.GetButtonDown("TouchBtn")&&(GunInHand1.activeInHierarchy|| GunInHand2.activeInHierarchy))
        {
            RaycastHit hit;
            if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
            {
                target.transform.position = hit.point;
                StartCoroutine(ShowShot());
                if (hit.transform.gameObject.name == Enemy1.gameObject.name|| hit.transform.gameObject.name == Enemy2.gameObject.name)
                {
                    GameObject Enemy;
                    if (hit.transform.gameObject.name == Enemy1.gameObject.name)
                        Enemy = Enemy1;
                    else
                        Enemy = Enemy2;
                    Animator a = Enemy.GetComponent<Animator>();
                    int dying = a.GetInteger("Dying") + 1;
                    if (dying==5)
                    {
                        
                        a.SetInteger("NPCState", 2);
                        NavMeshAgent nma = Enemy.GetComponent<NavMeshAgent>();
                        nma.enabled = false;
                        LineRenderer lr1 = Enemy.GetComponent<LineRenderer>();
                        lr1.enabled = false;

                    }
                    else 
                    {
                        a.SetInteger("Dying", dying);
                    }

                }

            }
        }
    }

    public IEnumerator ShowShot()
    {
        ParticleSystem currentMuzzleFlash;
        GameObject currentMuzzleEnd;
        AudioSource currentSound;
        if (GunInHand1.activeInHierarchy == true)
        {
            currentMuzzleFlash = MuzzleFlash1;
            currentSound = sound1;
            currentMuzzleEnd = MuzzleEnd1;
        }
        else
        {
            currentMuzzleFlash = MuzzleFlash2;
            currentSound = sound2;
            currentMuzzleEnd = MuzzleEnd2;
        }
            
           lr.SetPosition(0, currentMuzzleEnd.transform.position);
        lr.SetPosition(1, target.transform.position);
        lr.enabled = true;
        target.SetActive(true);
        currentMuzzleFlash.Play();
        currentSound.Play();
        yield return new WaitForSeconds(0.1f);
        lr.enabled = false;
        target.SetActive(false);
    }
}
