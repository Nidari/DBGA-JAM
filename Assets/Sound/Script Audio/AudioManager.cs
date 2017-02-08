using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AudioSource))]

public class AudioManager : MonoBehaviour {

	private AudioSource AudioClip;

	public AudioClip[] Ricarica;
	public AudioClip[] TamburoRuota;
	public AudioClip[] TamburoFerma;
	public AudioClip[] Sparo;
	public AudioClip[] DoppioSparo;
	public AudioClip[] FintoSparo;
	public AudioClip[] Schivata;
	public AudioClip[] ColpoEsplode;
	public AudioClip[] GiocatoreColpito;
	public AudioClip[] GiocatoreUcciso;
	public AudioClip[] GiocatoreCurato;

	// Use this for initialization
	void Start () {
		AudioClip = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
