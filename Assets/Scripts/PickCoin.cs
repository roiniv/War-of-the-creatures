using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickCoin : MonoBehaviour
{
    public AudioSource pickSound;
    public static int goldCount;
    public Text textGold;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            goldCount++;
            pickSound.Play();
            this.gameObject.SetActive(false);
            textGold.GetComponent<Text>().text = "Gold: " + goldCount;
        }
            
    }
    // Start is called before the first frame update
    void Start()
    {
        //pickSound = GetComponent<AudioSource>();
        goldCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
