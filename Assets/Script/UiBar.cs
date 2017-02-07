using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiBar : MonoBehaviour {

    public Image cooldDown;
    public bool coolingDown;
    public float waitTime = 30.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (coolingDown == true)
        {
            cooldDown.fillAmount -= 1.0f / waitTime * Time.deltaTime;
            if (cooldDown.fillAmount == 0f)
            {
                Debug.Log("Shoot");
                coolingDown = false;
            }
        }
    

    }
}
