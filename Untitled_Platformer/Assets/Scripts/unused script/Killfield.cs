using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killfield : MonoBehaviour
{
    float timer;
    public float delay = 3;
    public GameObject respawn; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
    if (other.gameObject.tag == "Death")
        {
          
                transform.position = respawn.transform.position; 

        }

    }
}
