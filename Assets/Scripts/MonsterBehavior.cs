using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBehavior : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    public GameObject target;
    private LineRenderer lr;

    public int count = 10;
    private GameObject currentEnemy;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject GunInHand1;
    public GameObject GunTarget;
    public GameObject MuzzleEnd1;
    public GameObject Canvan;
    public ParticleSystem MuzzleFlash1;
    private AudioSource sound1;
    private RaycastHit hit;
    public GameObject eyes;

    private AudioSource[] allAudioSources;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("NPCState", 1);
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        lr = GetComponent<LineRenderer>();
        sound1 = GunInHand1.GetComponent<AudioSource>();
        currentEnemy = target;

    }
    // Update is called once per frame
    void Update()
    {
        if (anim.GetInteger("NPCState") == 2)
            GunInHand1.SetActive(false);
        if (agent.enabled)
        {
            bool dist1 = Vector3.Distance(transform.position, enemy1.transform.position) < 80;
            bool dist2 = Vector3.Distance(transform.position, enemy2.transform.position) < 80;

            bool isEnter = true;
            if (dist1)
            {
                if(enemy1.gameObject.tag != "Player")
                {
                    NavMeshAgent nma1 = enemy1.GetComponent<NavMeshAgent>();
                    if (nma1.enabled)
                    {
                        currentEnemy = enemy1;
                        isEnter = false;
                    }

                }
                else
                {
                    currentEnemy = enemy1;
                    isEnter = false;
                }

            }

            if (dist2&&isEnter==true)
            {
                if (enemy2.gameObject.tag != "Player")
                {
                    NavMeshAgent nma2 = enemy2.GetComponent<NavMeshAgent>();
                    if (nma2.enabled)
                        currentEnemy = enemy2;
                    else
                        currentEnemy = target;
                }
                else
                    currentEnemy = enemy2;
            }
            else if(isEnter==true)
                currentEnemy = target;

            agent.SetDestination(currentEnemy.transform.position);

            if (GunInHand1.activeInHierarchy)
            {
                bool onRange2 = Vector3.Distance(transform.position, currentEnemy.transform.position) < 40;
                if (currentEnemy != target && onRange2 && Physics.Raycast(eyes.transform.position, eyes.transform.forward, out hit))
                {
                   StartCoroutine(ShowShot());
                }
            }

        }

    }

    public IEnumerator ShowShot()
    {
        yield return new WaitForSeconds(2f);
        ParticleSystem currentMuzzleFlash;
        GameObject currentMuzzleEnd;
        AudioSource currentSound;
        GunTarget.transform.position = hit.point;

        currentMuzzleFlash = MuzzleFlash1;
        currentSound = sound1;
        currentMuzzleEnd = MuzzleEnd1;
        lr.SetPosition(0, currentMuzzleEnd.transform.position);
        lr.SetPosition(1, GunTarget.transform.position);
        lr.enabled = true;
        GunTarget.SetActive(true);
        currentMuzzleFlash.Play();
        currentSound.Play();
        yield return new WaitForSeconds(0.1f);
        lr.enabled = false;
        GunTarget.SetActive(false);
        if (hit.point!=null&&hit.transform.gameObject.name == currentEnemy.gameObject.name)
        {
            Animator a = currentEnemy.GetComponent<Animator>();
            int dying = a.GetInteger("Dying") + 1;
            if (dying == 30)
            {

                if (currentEnemy.gameObject.tag == "Player")
                {
                     Canvan.SetActive(true);
                     AudioListener.pause = true;

                    Time.timeScale = 0f;
                }
                else
                {
                    a.SetInteger("NPCState", 2);
                    NavMeshAgent nma = currentEnemy.GetComponent<NavMeshAgent>();
                    nma.enabled = false;
                    LineRenderer lr1 = currentEnemy.GetComponent<LineRenderer>();
                    lr1.enabled = false;
                }

            }
            else
            {
                a.SetInteger("Dying", dying);
            }

        }
    }

}
