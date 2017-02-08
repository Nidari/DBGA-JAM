using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject TutPanel;
    public GameObject BG;
    public GameObject CredPanel;

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
        CredPanel.SetActive(false);

    }

    public void CredButtonPressed()
    {
        TutPanel.SetActive(false);
        MainPanel.SetActive(false);
        BG.SetActive(true);
        CredPanel.SetActive(true);
    }

   public void backPressed()
    {
        TutPanel.SetActive(false);
        MainPanel.SetActive(true);
        BG.SetActive(true);

        if (page2Tut == true)
        {
            page2Tut.SetActive(false);
            page1Tut.SetActive(true);
        }
    }


    
}
