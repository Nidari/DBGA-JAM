using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    AudioSource audioSourceLinker;
    public  AudioClip audioClipLinker;
    bool loading = false;

    void Awake()
    {
        audioSourceLinker = GameObject.Find("MixerSecondario").GetComponent<AudioSource>();
       
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

public void StartG()
    {
        if (!loading)
        {
            StartCoroutine(DeleyedLoad());
            loading = true;
        }
     
      
         
    }

    IEnumerator DeleyedLoad()
    {
        audioSourceLinker.PlayOneShot(audioClipLinker);

        yield return new WaitForSeconds(audioClipLinker.length);

        SceneManager.LoadScene(1);

    }
		

}
