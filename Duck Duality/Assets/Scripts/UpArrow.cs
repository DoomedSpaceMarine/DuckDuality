using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpArrow : MonoBehaviour
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
        if (Input.GetKey(KeyCode.UpArrow) && mm.gameActive == true)
        {
            mm.arrowKeys[0].sprite = mm.highlightArrowKeys[0];
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) && mm.gameActive == true)
        {
            mm.arrowKeys[0].sprite = mm.normalArrowKeys[0];
            thisKeyNumber = 0;
            mm.ArrowKeyPressed(thisKeyNumber);

        }
    }
}
