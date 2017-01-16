using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    public GameObject destructionPoint;

	// Use this for initialization
	void Start ()
    {
        destructionPoint = GameObject.Find("PlatformDestructionPoint");	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < destructionPoint.transform.position.x)
        {
            if(gameObject.tag == "StarterPlat")
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
            
        }	
	}
}
