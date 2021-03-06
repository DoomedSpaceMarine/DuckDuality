using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArrow : MonoBehaviour
{
    MinigameManager mm;

    public int thisKeyNumber;
    // Start is called before the first frame update
    void Start()
    {
        mm = FindObjectOfType<MinigameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && mm.gameActive == true)
        {
            mm.arrowKeys[2].sprite = mm.highlightArrowKeys[2];
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && mm.gameActive == true)
        {
            mm.arrowKeys[2].sprite = mm.normalArrowKeys[2];
            thisKeyNumber = 2;
            mm.ArrowKeyPressed(thisKeyNumber);

        }
    }
}
