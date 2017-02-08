using UnityEngine;
using System.Collections;


public class DamageOne : AbstractBullet {

    int idBullet = 1;

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
