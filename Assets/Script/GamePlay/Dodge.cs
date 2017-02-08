using UnityEngine;
using System.Collections;
using System;

public class Dodge : AbstractBullet {

    int idBullet = 6;

    public override int Shoot()
    {
        return idBullet;
    }
   
}
