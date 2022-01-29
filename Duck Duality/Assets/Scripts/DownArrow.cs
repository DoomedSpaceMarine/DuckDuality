using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownArrow : MonoBehaviour
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
        if (Input.GetKey(KeyCode.DownArrow) && mm.gameActive == true)
        {
            mm.arrowKeys[3].sprite = mm.highlightArrowKeys[3];
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && mm.gameActive == true)
        {
            mm.arrowKeys[3].sprite = mm.normalArrowKeys[3];
            thisKeyNumber = 3;
            mm.ArrowKeyPressed(thisKeyNumber);

        }
    }
}
