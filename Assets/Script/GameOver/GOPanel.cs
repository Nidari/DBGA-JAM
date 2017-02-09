using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GOPanel : MonoBehaviour {

	public GameObject Sfondo;
	public GameObject GameOverPanel;
	public GameObject P1WinPanel;
	public GameObject P2WinPanel;
	public GameObject DrawPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void GameOver()
	{
		GameOverPanel.SetActive (true);
		Sfondo.SetActive (false);
	}
	public void P1Win()
	{
		P2WinPanel.SetActive (false);
		P1WinPanel.SetActive (true);
		DrawPanel.SetActive (false);
	}
	public void P2Win()
	{
		P2WinPanel.SetActive (true);
		P1WinPanel.SetActive (false);
		DrawPanel.SetActive (false);
	}
	public void Draw()
	{
		P2WinPanel.SetActive (false);
		P1WinPanel.SetActive (false);
		DrawPanel.SetActive (true);
	}

}
