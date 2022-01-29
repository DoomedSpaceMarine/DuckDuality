using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndingVideoPlayer : MonoBehaviour
{
    public VideoPlayer vidPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vidPlayer.isPaused)
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }

}
