using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AudioSource))]

public class GunG1 : MonoBehaviour {

    private AudioContainer soundContainer;
    private AudioSource Audio;
    private Animator GunAnimator1;

    // Use this for initialization
    void Start()
    {
        GunAnimator1 = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
        soundContainer = GameManager.Self.GetComponent<AudioContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GunAnimator1.GetCurrentAnimatorStateInfo(0).IsName("Fire"))
        {
            Audio.PlayOneShot(soundContainer.Sparo);
        }

        if (GunAnimator1.GetCurrentAnimatorStateInfo(0).IsName("Dodge"))
        {
            Audio.PlayOneShot(soundContainer.ProjectileDodged);
        }

        if (GunAnimator1.GetCurrentAnimatorStateInfo(0).IsName("DoubleFire"))
        {
            Audio.PlayOneShot(soundContainer.DoppioSparo);
        }

        if (GunAnimator1.GetCurrentAnimatorStateInfo(0).IsName("Explosion"))
        {
            Audio.PlayOneShot(soundContainer.GunExplosion);
        }

        //if (GunAnimator1.GetCurrentAnimatorStateInfo(0).IsName("Cilecca"))
        //{
        //    Audio.PlayOneShot(soundContainer.Cilecca);
        //}

    }
}
