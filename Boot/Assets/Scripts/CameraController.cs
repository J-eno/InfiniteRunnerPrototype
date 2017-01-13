using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerController player;


    float targetRatio = 16f / 9f;
    float windowRatio = (float)Screen.width / (float)Screen.height;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;
    // Use this for initialization
    void Start()
    {
        float scaleHeight = windowRatio / targetRatio;
        Camera myCam = GetComponent<Camera>();
        if (scaleHeight < 1.0f)
        {
            Rect rect = myCam.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            myCam.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = myCam.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            myCam.rect = rect;
        }

        player = FindObjectOfType<PlayerController>();
        lastPlayerPosition = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = player.transform.position.x - lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        lastPlayerPosition = player.transform.position;
    }
}
