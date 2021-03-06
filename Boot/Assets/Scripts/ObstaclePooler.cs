﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : MonoBehaviour
{
    GameObject[] thePooledObject;
    public int poolAmount = 1;
    List<GameObject> pooledObjects;

    int obstacle;

    // Use this for initialization
    void Start()
    {
        pooledObjects = new List<GameObject>();
        thePooledObject = Resources.LoadAll<GameObject>("Prefabs/Obstacles");
        for (int i = 0; i < thePooledObject.Length; i++)
        {
            for (int j = 0; j < poolAmount; j++)
            {
                GameObject obj = (GameObject)Instantiate(thePooledObject[i]);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        obstacle = Random.Range(0, thePooledObject.Length);
        GameObject obj = (GameObject)Instantiate(thePooledObject[obstacle]);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;

    }
}
