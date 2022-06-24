using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{

    public VideoClip[] videoClips;
    VideoClip videoToPlay;
    VideoPlayer m_VideoPlayer;
    public RawImage videoImage;

    // Start is called before the first frame update
    void Start()
    {
        m_VideoPlayer = FindObjectOfType<VideoPlayer>();
		DebugUtility.HandleErrorIfNullFindObject<VideoPlayer, VideoManager>(m_VideoPlayer, this);

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
        videoToPlay = null;
        for(int i = 0; i < videoClips.Length; i++) {
            if(videoClips[i].name.ToString() == _animalName) {
                videoToPlay = videoClips[i];
                break;
            }
        }
        if(!videoToPlay) {
            Debug.Log("There is no Video to play");
        }
        m_VideoPlayer.clip = videoToPlay;
        //m_VideoPlayer.url = "Assets/Karting/Video/" + _animalName + ".mp4";
        PrepareVideo();
    }

    void IsOver(VideoPlayer vid) {
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
