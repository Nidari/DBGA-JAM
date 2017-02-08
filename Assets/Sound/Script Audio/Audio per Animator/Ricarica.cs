using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AudioSource))]

public class RicaricaG1 : MonoBehaviour {

    private AudioContainer soundContainer;
    private AudioSource Audio;
    private Animator GunAnimator1;

    public AudioClip AudioSparo;

    // Use this for initialization
    void Start()
    {
        GunAnimator1 = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
        soundContainer = GameManager.Self.GetComponent<AudioContainer>();
        AudioSparo = soundContainer.StopRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (GunAnimator1.GetCurrentAnimatorStateInfo(0).IsName("Ricarica"))
        {
            Audio.clip = AudioSparo;
            Audio.PlayOneShot(soundContainer.Ricarica);
        }
    }
}
