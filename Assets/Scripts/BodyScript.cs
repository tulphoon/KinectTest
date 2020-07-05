using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BodyScript : MonoBehaviour
{
    public new Camera camera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GroundBlock"))
        {
            VideoPlayer videoPlayer = other.gameObject.GetComponent<VideoPlayer>();
            if (videoPlayer == null)
                return;
            var foundVideoPlayers = FindObjectsOfType<VideoPlayer>();
            foreach (var foundVidPlayer in foundVideoPlayers)
            {
                if (foundVidPlayer != videoPlayer && foundVidPlayer.targetCamera != null)
                {
                    videoPlayer.Play();
                    videoPlayer.targetCamera = camera;
                    foundVidPlayer.targetCamera = null;
                    foundVidPlayer.Stop();
                }
            }
        }
    }
}
