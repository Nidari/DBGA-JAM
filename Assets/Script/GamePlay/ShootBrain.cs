using UnityEngine;
using System.Collections;

public class ShootBrain : MonoBehaviour
{


    public int TypeOfShoot()
    {
        int idBullet = 0;

        if (GetComponent<DamageOne>())
        {
            DamageOne damageOneLinker = GetComponent<DamageOne>();

            idBullet = damageOneLinker.Shoot();
        }

        if (GetComponent<DamageTwo>())
        {
            DamageTwo damageTwoLinker = GetComponent<DamageTwo>();
            idBullet = damageTwoLinker.Shoot();
        }

        if (GetComponent<Dodge>())
        {
            Dodge dodgeLinker = GetComponent<Dodge>();
            idBullet = dodgeLinker.Shoot();
        }

        if (GetComponent<Explosive>())
        {
            Explosive explosiveLinker = GetComponent<Explosive>();
            idBullet = explosiveLinker.Shoot();
        }

        if (GetComponent<Fake>())
        {
            Fake fakeLinker = GetComponent<Fake>();
            idBullet = fakeLinker.Shoot();
        }

        if (GetComponent<Heal>())
        {
            Heal healLinker = GetComponent<Heal>();
            idBullet = healLinker.Shoot();
        }

        return idBullet;

    }
}
