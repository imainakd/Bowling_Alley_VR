using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame      
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider enter){
        if(enter.gameObject.name=="Ball"){
            AudioSource src2 =GetComponent<AudioSource>();
            src2.Play();
        }
    }
}
