using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public GameObject npc;
    private float y;
    
    // Start is called before the first frame update
    void Start()
    {
        y = 1.25f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == npc.name)
        {
            float x, z;
            x = Random.Range(-45, -115);
            z = Random.Range(80, 300);
            if (y == 1.25f)
                y = 17.18f;
            else
                y = 1.25f;
            
            this.transform.position = new Vector3(x,y,z);
        }
    }
}
