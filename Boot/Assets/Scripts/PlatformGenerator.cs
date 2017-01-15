using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformGenerator : MonoBehaviour {
    public GameObject thePlatform;
    public Transform generationPoint;
    private float platformWidth;
    public PlatformPooler thePlatformPool;

    public float randomObstacleThreshold;
    public ObstaclePooler theObstaclePool;

    float padding = 1f;

	// Use this for initialization
	void Start ()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        randomObstacleThreshold = 75;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth, transform.position.y, transform.position.z);
            //Instantiate(platformsArray[platformToSpawn], transform.position, transform.rotation);
            GameObject newPlatform = thePlatformPool.GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < randomObstacleThreshold)
            {
                GameObject newObstacle = theObstaclePool.GetPooledObject();
                float obstacleXPos = Random.Range((-platformWidth / 2) + padding, (platformWidth / 2) - padding);
                Vector3 obstaclePosition = new Vector3(obstacleXPos, 0f, 0f);
                newObstacle.transform.position = transform.position + obstaclePosition;
                newObstacle.transform.rotation = transform.rotation;
                newObstacle.SetActive(true);
            }
        }	
	}
}
