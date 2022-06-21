using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{

    UnityEngine.Video.VideoPlayer m_VideoPlayer;
    public RawImage videoImage;

    // Start is called before the first frame update
    void Start()
    {
        m_VideoPlayer = FindObjectOfType<UnityEngine.Video.VideoPlayer>();
		DebugUtility.HandleErrorIfNullFindObject<UnityEngine.Video.VideoPlayer, VideoManager>(m_VideoPlayer, this);

        m_VideoPlayer.loopPointReached += IsOver;
        m_VideoPlayer.playOnAwake = false;
        m_VideoPlayer.isLooping = false;
        //PlayVideo("Assets/Karting/Video/testVideo.mp4");
    }

    void PrepareVideo() {
        m_VideoPlayer.Prepare();
        StartCoroutine("StartVideoWithDelay", .1f);
    }

    // The Video must be named after the animal.
    public void PlayVideo(string _animalName) {
        m_VideoPlayer.url = "Assets/Karting/Video/" + _animalName + ".mp4";
        PrepareVideo();
    }

    void IsOver(UnityEngine.Video.VideoPlayer vid) {
        Debug.Log("Is Over!");
        videoImage.enabled = false;
    }

    IEnumerator StartVideoWithDelay(float delay) {
        while (!m_VideoPlayer.isPrepared) {
            yield return new WaitForSeconds(delay);
        }
        videoImage.enabled = true;
        m_VideoPlayer.Play();
    }
}
