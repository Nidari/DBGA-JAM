using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AudioSource))]

public class Falchi : MonoBehaviour {

    private AudioContainer soundContainer;
    private AudioSource Audio;
    private Animation AnimFalco;

    // Use this for initialization
    void Start () {
        AnimFalco = GetComponent<Animation>();
        Audio = GetComponent<AudioSource>();
        soundContainer = GameManager.Self.GetComponent<AudioContainer>();
    }
	
	// Update is called once per frame
	void Update () {

        if (AnimFalco.IsPlaying("FalcoAtterraggio"))
        {
            Audio.PlayOneShot(soundContainer.Falco1);
        }

        if (AnimFalco.IsPlaying("FalcoVolo"))
        {
            Audio.PlayOneShot(soundContainer.Falco2);
        }

    }
}
