using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy_Prefabs;
    private float horLimit  = 9.5f;
    private float vertLimit = 5.5f;
    private float spawnCooldown;
    
    
    private Vector3 spawnPos;
    private GameObject clone;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnCooldown = 3f;
        StartCoroutine(SpawnCont());
    }

    private IEnumerator SpawnCont()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            int randInt = UnityEngine.Random.Range(0, 4);   //generate number from 0-3
            float randFloat;
            SpawnSide spawnSide;
            switch (randInt)
            {
                case 0:
                    spawnSide=SpawnSide.Up;
                    randFloat = UnityEngine.Random.Range(-(horLimit-1), horLimit-1);
                    spawnPos =new Vector3(randFloat, vertLimit,0f);
                    break;
                case 1:
                    spawnSide=SpawnSide.Down;
                    randFloat = UnityEngine.Random.Range(-(horLimit - 1), horLimit - 1);
                    spawnPos = new Vector3(randFloat, -vertLimit, 0f);
                    break;
                case 2:
                    spawnSide=SpawnSide.Left;
                    randFloat = UnityEngine.Random.Range(-(vertLimit-1), vertLimit-1);
                    spawnPos = new Vector3(-horLimit, randFloat, 0f);
                    break;
                case 3: 
                    spawnSide=SpawnSide.Right;
                    randFloat = UnityEngine.Random.Range(-(vertLimit-1), vertLimit-1);
                    spawnPos = new Vector3(horLimit, randFloat, 0f);
                    break;
                default:
                    spawnSide = 0;
                    Debug.Log("Unknown spawn side!");
                    break;
            }
            //Choose EnemyType
            randInt = UnityEngine.Random.Range(0, enemy_Prefabs.Length);   //generate number from 0-3

            //Wrapper for Instantiating and setting enemy 
            clone = Instantiate(enemy_Prefabs[randInt], spawnPos, Quaternion.identity);
            clone.GetComponent<Enemy>().SetDestination(spawnSide, spawnPos);

            yield return new WaitForSeconds(spawnCooldown);
        }
    }
}
