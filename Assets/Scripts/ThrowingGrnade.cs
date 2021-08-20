using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingGrnade : MonoBehaviour
{
    private bool isThrown = false;
    public GameObject player;
    public GameObject explosin;
    public GameObject part1;
    public GameObject part2;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("q"))
        {
            initialPosition = transform.position;
            initialRotation = transform.rotation;
            if (!isThrown)
            {
                isThrown = true;
                ThrowGrenade();
            }
            
        }
    }
    void ThrowGrenade()
    {


        Vector3 direction = player.transform.forward * 14;
        direction.y = 4;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(direction,ForceMode.Impulse);
        StartCoroutine(Explode());
        transform.rotation = initialRotation;
        transform.position = initialPosition;

    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(1.5f);
        explosin.SetActive(true);
        part1.SetActive(false);
        part2.SetActive(false);
        Collider[] objectsCollider = Physics.OverlapSphere(transform.position, 10);
        for(int i = 0; i < objectsCollider.Length; i++)
        {
            if (objectsCollider[i] != null)
            {
                Rigidbody rbo = objectsCollider[i].GetComponent<Rigidbody>();
                if (rbo != null)
                {
                    rbo.AddExplosionForce(500f, transform.position, 25);
                }
                
            }
        }
    }
}
