using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSystem : MonoBehaviour
{
    public List<string> Questions;
    public List<int> goodBadQuestion;

    public int whatQuestion;

    public Text question;

    int textSelect;

    public int goodBadChoice = 0;

    public AudioSource typeSound;

    MinigameManager mm;
    CheckGameState cgs;

    // Start is called before the first frame update
    void Start()
    {
        mm = FindObjectOfType<MinigameManager>();
        cgs = FindObjectOfType<CheckGameState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuestion()
    {
        textSelect = Random.Range(0, Questions.Count);
        //question.text = Questions[textSelect];
        whatQuestion = goodBadQuestion[textSelect];
        StartCoroutine(TypeEffect(Questions[textSelect]));
        Questions.RemoveAt(textSelect);
    }

    IEnumerator TypeEffect(string sentence)
    {
        question.text = "";
        typeSound.Play();
        foreach (char letter in sentence.ToCharArray())
        {
            question.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        typeSound.Stop();
    }

    public void AnswerYes()
    {
        if(goodBadQuestion[textSelect] == 1)
        {
            goodBadChoice = 1;
        }
        else if (goodBadQuestion[textSelect] == 2)
        {
            goodBadChoice = 2;
        }
        cgs.minigame.SetActive(true);
        mm.MinigameStart();
    }

    public void AnswerNo()
    {
        if(goodBadQuestion[textSelect] == 1)
        {
            goodBadChoice = 2;
        }

        if(goodBadQuestion[textSelect] == 2)
        {
            goodBadChoice = 1;
        }
        cgs.minigame.SetActive(true);
        mm.MinigameStart();
    }
}
