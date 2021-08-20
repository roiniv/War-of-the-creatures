using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGrenade : MonoBehaviour
{
    public GameObject grenadeOut;
    public GameObject playerGrenade;



    private void OnMouseDown()
    {


        grenadeOut.SetActive(false);
        playerGrenade.SetActive(true);
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
