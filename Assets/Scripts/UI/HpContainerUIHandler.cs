using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpContainerUIHandler : MonoBehaviour
{
    private HeartUIController[] heartControllers;

    private int heartIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        heartControllers=GetComponentsInChildren<HeartUIController>();
        heartIndex = heartControllers.Length-1;
    }

    public void DeactivateHeart()
    {
        if(heartIndex >= 0)
        {
            heartControllers[heartIndex].DeactivateHeart();
            heartIndex--;
        }
    }
}
