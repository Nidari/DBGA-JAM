using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

    public GameObject page1Tut;
    public GameObject page2Tut;
   //public GameObject arrowNext;
   //public GameObject arrowBack;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void nextPage()
    {
       
        page1Tut.SetActive(false);
        page2Tut.SetActive(true);
        //arrowNext.SetActive(false);
        //arrowBack.SetActive(true);

    }
    public void backPage()
    {

        page1Tut.SetActive(true);
        page2Tut.SetActive(false);
       //arrowBack.SetActive(false);
       //arrowNext.SetActive(true);

    }
}
