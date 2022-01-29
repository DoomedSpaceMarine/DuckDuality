using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public SpriteRenderer[] arrowKeys;
    public Sprite[] highlightArrowKeys;
    public Sprite[] normalArrowKeys;

    public float stayHighlighted;
    private float stayHighlightedCounter;

    public float waitBetweenHighlights;
    private float waitBetweenCounter;

    private bool shouldBeHighlighted;
    private bool shouldBeNormal;

    public int keySelect;

    public List<int> activeSequence;
    private int positionInSequence;

    private bool gameActive;
    private int inputInsequence;


    // Start is called before the first frame update
    void Start()
    {
        MinigameStart();
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
        activeSequence.Clear();
        positionInSequence = 0;
        inputInsequence = 0;

        for (int i = 0; i < 3; i++) 
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

                if (inputInsequence >= activeSequence.Count)
                {
                    Debug.Log("Win");
                }

            }

            else
            {
                Debug.Log("Incorrect");
                gameActive = false;
            }
            
            
        }
    }
}
