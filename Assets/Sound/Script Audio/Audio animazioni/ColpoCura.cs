using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AudioSource))]

public class ColpoCura : MonoBehaviour
{

    private AudioContainer soundContainer;
    private AudioSource Audio;
    private Animation AnimCura;

    // Use this for initialization
    void Start()
    {
        AnimCura = GetComponent<Animation>();
        Audio = GetComponent<AudioSource>();
        soundContainer = GameManager.Self.GetComponent<AudioContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AnimCura.IsPlaying("Cura"))
        {
            Audio.PlayOneShot(soundContainer.Ricarica);
        }
    }
}
