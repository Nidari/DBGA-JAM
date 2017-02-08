using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AudioSource))]

public class Sparo : MonoBehaviour {

    private AudioContainer soundContainer;
    private AudioSource Audio;
    private Animator GunAnimator; 

    public AudioClip AudioSparo;

    // Use this for initialization
    void Start () {
        GunAnimator = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
        soundContainer = GameManager.Self.GetComponent<AudioContainer>();
        AudioSparo = soundContainer.StopRotation;
    }
	
	// Update is called once per frame
	void Update () {
	if (GunAnimator.GetCurrentAnimatorStateInfo(0).IsName("Sparo"))
        {
            Audio.clip = AudioSparo;
            Audio.PlayOneShot(soundContainer.Sparo);
        }
    }
}
