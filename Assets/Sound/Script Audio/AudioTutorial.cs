using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AudioSource))]

public class AudioTutorial : MonoBehaviour {

    private AudioContainer soundContainer;
    private AudioSource Audio;

    public AudioClip ButtonPressed;

    // Use this for initialization
    void Start () {
        Audio = GetComponent<AudioSource>();
        soundContainer = GameManager.Self.GetComponent<AudioContainer>();
        ButtonPressed = soundContainer.ButtonPressed;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonPlay()
    {
        Audio.PlayOneShot(soundContainer.ButtonPressed);
    }
}
