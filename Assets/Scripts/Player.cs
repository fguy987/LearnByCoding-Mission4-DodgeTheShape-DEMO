using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for the player's main stats
/// </summary>
public class Player : MonoBehaviour
{
    private int maxHp = 5;
    private int hp;
    
    // Start is called before the first frame update
    private void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(int dmgTaken)
    {
        if(hp- dmgTaken <=0)//lethal hit
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
