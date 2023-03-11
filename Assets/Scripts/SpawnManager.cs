using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy_Prefab;
    private float horLimit,vertLimit;
    private Vector3 spawnPos;
    
    // Start is called before the first frame update
    void Start()
    {
        horLimit = 9.5f;
        vertLimit = 5.5f;

        StartCoroutine(SpawnCont());
    }

    private IEnumerator SpawnCont()
    {
        while(true)
        {
            
            int randInt = UnityEngine.Random.Range(0, 4);   //generate number from 0-3
            float randFloat;
            switch (randInt)
            {
                case 0:
                    randFloat = UnityEngine.Random.Range(-(horLimit-1), horLimit-1);
                    spawnPos =new Vector3(randFloat, vertLimit,0f);
                    break;
                case 1:
                    randFloat = UnityEngine.Random.Range(-(horLimit - 1), horLimit - 1);
                    spawnPos = new Vector3(randFloat, -vertLimit, 0f);
                    break;
                case 2:
                    randFloat = UnityEngine.Random.Range(-(vertLimit-1), vertLimit-1);
                    spawnPos = new Vector3(-horLimit, randFloat, 0f);
                    break;
                case 3: 
                    randFloat = UnityEngine.Random.Range(-(vertLimit-1), vertLimit-1);
                    spawnPos = new Vector3(horLimit, randFloat, 0f);
                    break;
                default:
                    break;
            }
            Instantiate(enemy_Prefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
