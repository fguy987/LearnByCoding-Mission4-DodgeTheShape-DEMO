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
    [SerializeField] //set in editor
    private GameObject menu_Obj;

    private HpContainerUIHandler hpUIHandler;
    private GameMenuUIHandler gameMenuUIHandler;
    
    private int maxHp = 5;
    private int hp;
    
    // Start is called before the first frame update
    private void Start()
    {
        hp = maxHp;
        hpUIHandler       = hpUIHandler_Obj.GetComponent<HpContainerUIHandler>();
        gameMenuUIHandler = menu_Obj.GetComponent<GameMenuUIHandler>();
    }

    public void TakeDamage(int dmgTaken)
    {
        //Debug.Log($"curr hp {hp} dmg to take: {dmgTaken}");

        for (int i = 0; i < dmgTaken; i++)
        {
            hpUIHandler.DeactivateHeart();
        }

        if (hp- dmgTaken <=0)//lethal hit
        {
            Dead();
        }
        else
        {
            hp -= dmgTaken;
        }
    }

    private void Dead()
    {
        menu_Obj.SetActive(true);
        gameMenuUIHandler.GameOver();
    }

}
