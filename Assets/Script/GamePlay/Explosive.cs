using UnityEngine;
using System.Collections;


public class Explosive : AbstractBullet {

    int idBullet = 5;

    public override int Shoot()
    {
        return idBullet;
    }

}
