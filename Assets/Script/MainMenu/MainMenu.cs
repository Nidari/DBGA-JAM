using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject TutPanel;
    public GameObject BG;
    
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
    }


    
}
