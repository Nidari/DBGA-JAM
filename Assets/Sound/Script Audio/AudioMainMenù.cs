using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AudioSource))]

public class AudioMainMenù : MonoBehaviour {

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
    void Update()
    {
        //if (Input.GetButtonDown("Fire1") && tag == "Button")
        //{
        //    Debug.Log("Audio");
        //    Audio.clip = ButtonPressed;
        //    Audio.PlayOneShot(Audio.clip);
        //}
    }

   public void ButtonPlay()
    {
        Audio.PlayOneShot(soundContainer.ButtonPressed);
    }

}
