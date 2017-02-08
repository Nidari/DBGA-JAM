using UnityEngine;
using System.Collections;


public class DamageTwo : AbstractBullet {

    int idBullet = 2;

    public override int Shoot()
    {
        return idBullet;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
