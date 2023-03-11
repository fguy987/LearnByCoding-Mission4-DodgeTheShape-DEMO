using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartUIController : MonoBehaviour
{
    private GameObject heartFill;

    private void Start()
    {
        heartFill = transform.GetChild(0).gameObject;
    }

    public void ActivateHeart()
    {
        heartFill.SetActive(true);
    }

    public void DeactivateHeart()
    {
        heartFill.SetActive(false);
    }
}
