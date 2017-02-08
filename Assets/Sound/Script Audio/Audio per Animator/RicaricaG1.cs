using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AudioSource))]

public class Ricarica : MonoBehaviour {

    private AudioContainer soundContainer;
    private AudioSource Audio;
    private Animator GunAnimator2;

    public AudioClip AudioSparo;

    // Use this for initialization
    void Start()
    {
        GunAnimator2 = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
        soundContainer = GameManager.Self.GetComponent<AudioContainer>();
        AudioSparo = soundContainer.StopRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (GunAnimator2.GetCurrentAnimatorStateInfo(0).IsName("Sparo"))
        {
            Audio.clip = AudioSparo;
            Audio.PlayOneShot(soundContainer.Sparo);
        }
    }
}
