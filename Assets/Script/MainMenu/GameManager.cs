using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    protected static GameManager _self;
    public static GameManager Self
    {
        get
        {
            if (_self == null)
                _self = FindObjectOfType(typeof(GameManager)) as GameManager;
            return _self;
        }

    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
