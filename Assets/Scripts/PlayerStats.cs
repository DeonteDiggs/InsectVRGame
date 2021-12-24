using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Collider ringbound;
    void OnEnable()
    {
        print("Enabled");
    }
    // Start is called before the first frame update
    void Start()
    {
        print("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        /*if(other.CompareTag("Respawn"))
            print("inbound");
        else
            print("outbound");*/
    }

   
    
}
