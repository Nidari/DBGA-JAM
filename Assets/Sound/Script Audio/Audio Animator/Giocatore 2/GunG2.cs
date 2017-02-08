using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AudioSource))]

public class GunG2 : MonoBehaviour {

    private AudioContainer soundContainer;
    private AudioSource Audio;
    private Animator GunAnimator2;

    // Use this for initialization
    void Start()
    {
        GunAnimator2 = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
        soundContainer = GameManager.Self.GetComponent<AudioContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GunAnimator2.GetCurrentAnimatorStateInfo(0).IsName("Sparo"))
        {
            Audio.PlayOneShot(soundContainer.Sparo);
        }

        if (GunAnimator2.GetCurrentAnimatorStateInfo(0).IsName("Schivata"))
        {
            Audio.PlayOneShot(soundContainer.ProjectileDodged);
        }

        if (GunAnimator2.GetCurrentAnimatorStateInfo(0).IsName("DoppioSparo"))
        {
            Audio.PlayOneShot(soundContainer.DoppioSparo);
        }

        if (GunAnimator2.GetCurrentAnimatorStateInfo(0).IsName("Esplosione"))
        {
            Audio.PlayOneShot(soundContainer.GunExplosion);
        }

        if (GunAnimator2.GetCurrentAnimatorStateInfo(0).IsName("Cilecca"))
        {
            Audio.PlayOneShot(soundContainer.Cilecca);
        }

    }
}
