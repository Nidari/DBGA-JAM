using UnityEngine;
using System.Collections;


public class Fake : AbstractBullet {

    int idBullet = 4;

    public override int Shoot()
    {
        return idBullet;
    }

}
