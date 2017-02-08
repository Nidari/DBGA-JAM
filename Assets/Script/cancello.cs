using UnityEngine;
public class cancello : AbstractBullet
{
    public override int Shoot()
    {

        return Random.Range(1, 6);
    }
}