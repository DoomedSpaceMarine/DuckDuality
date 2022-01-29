using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public Image[] arrowKeys;
    public Sprite[] highlightArrowKeys;
    public Sprite[] normalArrowKeys;

    public GameObject question;

    public AudioSource correctKeyPress;

    public float stayHighlighted;
    private float stayHighlightedCounter;

    public float waitBetweenHighlights;
    private float waitBetweenCounter;

    private bool shouldBeHighlighted;
    private bool shouldBeNormal;

    public int keySelect;

    public int minigameLevel = 2;

    public List<int> activeSequence;
    private int positionInSequence;

    public bool gameActive;
    private int inputInsequence;

    CheckGameState cgs;
    EndingManager em;
    QuestionSystem qs;


    // Start is called before the first frame update
    void Start()
    {
        cgs = FindObjectOfType<CheckGameState>();
        em = FindObjectOfType<EndingManager>();
        qs = FindObjectOfType<QuestionSystem>();

    }

    // Update is called once per frame
    void Update()
    {
       if(shouldBeHighlighted)
        {
            stayHighlightedCounter -= 1 * Time.deltaTime;

            if (stayHighlightedCounter < 0)
            {
                arrowKeys[activeSequence[positionInSequence]].sprite = normalArrowKeys[activeSequence[positionInSequence]];
                shouldBeHighlighted = false;

                shouldBeNormal = true;
                waitBetweenCounter = waitBetweenHighlights;

                positionInSequence++;
            }
        
        }

        if (shouldBeNormal)
        {
            waitBetweenCounter -= 1 * Time.deltaTime;

            if(positionInSequence >= activeSequence.Count)
            {
                shouldBeNormal = false;
                gameActive = true;
            }
            else
            {
                if(waitBetweenCounter < 0)
                {

                    arrowKeys[activeSequence[positionInSequence]].sprite = highlightArrowKeys[activeSequence[positionInSequence]];

                    stayHighlightedCounter = stayHighlighted;
                    shouldBeHighlighted = true;
                    shouldBeNormal = false;
                }
            }
        }
    }

    public void MinigameStart()
    {
        question.SetActive(false);
        activeSequence.Clear();
        positionInSequence = 0;
        inputInsequence = 0;

        for (int i = 0; i < minigameLevel; i++) 
        {
            keySelect = Random.Range(0, arrowKeys.Length);

            activeSequence.Add(keySelect);
        }
        arrowKeys[activeSequence[positionInSequence]].sprite = highlightArrowKeys[activeSequence[positionInSequence]];

        stayHighlightedCounter = stayHighlighted;
        shouldBeHighlighted = true;
    }

    public void ArrowKeyPressed(int whichArrowKey)
    {
        if (gameActive)
        {
            if (activeSequence[inputInsequence] == whichArrowKey)
            {
                Debug.Log("Correct");

                inputInsequence++;
                correctKeyPress.Play();

                if (inputInsequence >= activeSequence.Count)
                {
                    Debug.Log("Win");
                    if(qs.goodBadChoice == 1)
                    {
                        em.alignmentCounter++;
                    }
                    else if(qs.goodBadChoice == 2)
                    {
                        em.alignmentCounter--;
                    }
                    cgs.gameState++;
                    minigameLevel++;
                    gameActive = false;
                    
                    cgs.CheckState();
                }

            }

            else
            {
                Debug.Log("Incorrect");
                gameActive = false;
                minigameLevel++;
                cgs.gameState++;
                em.confusionCounter++;
                cgs.CheckState();
            }
            
            
        }
    }
}
