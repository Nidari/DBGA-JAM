using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AudioSource))]

public class Campana : MonoBehaviour {

    private AudioContainer soundContainer;
    private AudioSource Audio;
    private Animation AnimBell;

    // Use this for initialization
    void Start () {
        AnimBell = GetComponent<Animation>();
        Audio = GetComponent<AudioSource>();
        soundContainer = GameManager.Self.GetComponent<AudioContainer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (AnimBell.IsPlaying("Campana"))
        {
            //Audio.PlayOneShot(soundContainer.Campana);
        }
    }
}
