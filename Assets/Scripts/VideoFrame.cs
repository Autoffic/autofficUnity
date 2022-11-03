using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFrame : MonoBehaviour
{
    public VideoPlayer clip;
    // Start is called before the first frame update
    void Start()
    {
        clip.frame = 1;
        clip.Pause();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
