using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AudioSource))]

public class Ricarica : MonoBehaviour {

    private AudioContainer soundContainer;
    private AudioSource Audio;
    private Animation AnimRicarica;

    // Use this for initialization
    void Start ()
    {
        AnimRicarica = GetComponent<Animation>();
        Audio = GetComponent<AudioSource>();
        soundContainer = GameManager.Self.GetComponent<AudioContainer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (AnimRicarica.IsPlaying("Ricarica"))
           {
            Audio.PlayOneShot(soundContainer.Ricarica);
           }
    }
}
