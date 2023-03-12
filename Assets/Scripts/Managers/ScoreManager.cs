using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]//set in editor
    private GameObject Menu_Obj;
    private GameMenuUIHandler gameMenuUIHandler;
    
    private int score=0;
    
    // Start is called before the first frame update
    void Start()
    {
        gameMenuUIHandler = Menu_Obj.GetComponent<GameMenuUIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int addedScore)
    {
        score+= addedScore;
        gameMenuUIHandler.UpdateScoreUI(score);
    }
}
