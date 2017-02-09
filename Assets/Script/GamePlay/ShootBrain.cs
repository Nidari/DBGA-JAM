using UnityEngine;
using System.Collections;

public class ShootBrain : MonoBehaviour
{
    BulletType whichBullet = BulletType.noShoot;

    public BulletType bulletType
    {
        get { return whichBullet; }
        
    }

    public int TypeOfShoot()
    {
        int idBullet = 0;
        
        if (GetComponent<DamageOne>())
        {
            DamageOne damageOneLinker = GetComponent<DamageOne>();
            whichBullet = BulletType.fire;
            idBullet = damageOneLinker.Shoot();
        }

        if (GetComponent<DamageTwo>())
        {
            DamageTwo damageTwoLinker = GetComponent<DamageTwo>();
            whichBullet = BulletType.doubleFire;
            idBullet = damageTwoLinker.Shoot();
        }

        if (GetComponent<Dodge>())
        {
            Dodge dodgeLinker = GetComponent<Dodge>();
            whichBullet = BulletType.dodge;
            idBullet = dodgeLinker.Shoot();
        }

        if (GetComponent<Explosive>())
        {
            Explosive explosiveLinker = GetComponent<Explosive>();
            whichBullet = BulletType.explosion;
            idBullet = explosiveLinker.Shoot();
        }

        if (GetComponent<Fake>())
        {
            Fake fakeLinker = GetComponent<Fake>();
            whichBullet = BulletType.miss;
            idBullet = fakeLinker.Shoot();
        }

        if (GetComponent<Heal>())
        {
            Heal healLinker = GetComponent<Heal>();
            whichBullet = BulletType.heal;
            idBullet = healLinker.Shoot();
        }

        return idBullet;

    }
}
