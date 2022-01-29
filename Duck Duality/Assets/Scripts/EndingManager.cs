using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public int alignmentCounter = 0;
    public int confusionCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndManager()
    {
        if (alignmentCounter == 0 && confusionCounter < 5)
        {
            SceneManager.LoadScene("BalanceEnding");
        }

        if (alignmentCounter >= 1 && confusionCounter < 5)
        {
            SceneManager.LoadScene("GoodEnding");
        }

        if(alignmentCounter <= -1 && confusionCounter < 5)
        {
            SceneManager.LoadScene("BadEnding");
        }

        if(confusionCounter >= 5)
        {
            SceneManager.LoadScene("ConfusionEnding");
        }
    }
}
