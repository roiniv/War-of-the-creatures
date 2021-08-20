using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{
    public GameObject gunInDrawer;
    public GameObject secondGun;
    public GameObject player;
    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;
    public GameObject playerGun;
    public GameObject npc1Gun;
    public GameObject npc2Gun;
    public GameObject npc3Gun;


     private void OnMouseDown()
      {

           if (secondGun.gameObject.activeInHierarchy == true)
           {
               secondGun.SetActive(false);
           }
           gunInDrawer.SetActive(false);
           playerGun.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {

       if(other.gameObject.name != player.name)
        {
            GameObject gunInHand;
            Animator an;
            if (other.gameObject.name == npc1.name)
            {
                an = npc1.GetComponent<Animator>();
                an.SetInteger("NPCState", 4);
                gunInHand = npc1Gun;
            }
            else if (other.gameObject.name == npc2.name)
            {
                an = npc2.GetComponent<Animator>();
                an.SetInteger("NPCState", 4);
                gunInHand = npc2Gun;
            }
            else
            {
                an = npc3.GetComponent<Animator>();
                an.SetInteger("NPCState", 4);
                gunInHand = npc3Gun;
            }

            gunInDrawer.SetActive(false);
            gunInHand.SetActive(true);

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
