using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject TutPanel;
    public GameObject BG;

    public GameObject page1Tut;
    public GameObject page2Tut;
    
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

   public void TutButtonPressed()
    {
        TutPanel.SetActive(true);
        MainPanel.SetActive(false);
        BG.SetActive(true);

    }
   public void backPressed()
    {
        TutPanel.SetActive(false);
        MainPanel.SetActive(true);
        BG.SetActive(false);

        if (page2Tut == true)
        {
            page2Tut.SetActive(false);
            page1Tut.SetActive(true);
        }
    }


    
}
