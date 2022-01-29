using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameState : MonoBehaviour
{
    public int gameState = 0;

    public GameObject minigame;

    QuestionSystem qs;
    EndingManager em;
    MinigameManager mm;

    // Start is called before the first frame update
    void Start()
    {
        qs = FindObjectOfType<QuestionSystem>();
        em = FindObjectOfType<EndingManager>();
        mm = FindObjectOfType<MinigameManager>();

        minigame.SetActive(false);
        CheckState();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckState()
    {

        if (gameState < 3)
        {
            minigame.SetActive(false);
            mm.question.SetActive(true);
            qs.SetQuestion();
        }
        else
        {
            em.EndManager();
        }
    }
}
