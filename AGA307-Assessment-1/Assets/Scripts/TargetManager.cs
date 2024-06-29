using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetSize
{
    Small,
    Medium,
    Large,
}

public class TargetManager : MonoBehaviour
{
    public Transform[] targetSpawnpoints = new Transform[7];
    public GameObject[] targetTypes = new GameObject[2];

    public List<GameObject> targets = new List<GameObject>();
    int numIterations = 100;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        // SpawnTarget();

        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnTarget();
        }
        // FindClosestTargetToPlayer();
    }

    void SpawnTarget()
    {
        int targetNum = UnityEngine.Random.Range(0, targetTypes.Length);
        int spawnNum = UnityEngine.Random.Range(0, targetSpawnpoints.Length);
        GameObject target = Instantiate(targetTypes[targetNum], targetSpawnpoints[spawnNum].position, targetSpawnpoints[spawnNum].rotation);
        //adds the newly created target to target list
        targets.Add(target);
        
        print("Target Count: " + targets.Count);
    }

    
}


