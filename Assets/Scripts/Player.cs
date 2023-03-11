using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for the player's main stats
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField] //set in editor
    private GameObject hpUIHandler_Obj;
    private HpContainerUIHandler hpUIHandler;
    
    private int maxHp = 5;
    private int hp;
    
    // Start is called before the first frame update
    private void Start()
    {
        hp = maxHp;
        hpUIHandler = hpUIHandler_Obj.GetComponent<HpContainerUIHandler>();
    }

    public void TakeDamage(int dmgTaken)
    {
        hpUIHandler.DeactivateHeart();
        if (hp- dmgTaken <=0)//lethal hit
        {
            Debug.Log($"Player Dead");
        }
        else
        {
            hp -= dmgTaken;
        }
        Debug.Log($"hp after hit {hp}");
    }

}
