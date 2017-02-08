using UnityEngine;
using System.Collections;
using System;

public class Heal :AbstractBullet {


    int heal = 3;

    public override int Shoot()
    {
        
        return heal;
    }

    
}
