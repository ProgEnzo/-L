using UnityEngine;

public class AOE : Weapon
{
    [SerializeField] private GameObject dangerZone;

    protected override void Shoot()
    {
        GameObject zone = Instantiate(dangerZone, transform.position, Quaternion.identity);
        zone.GetComponent<Damager>().damages = damages[tierDamages];
        Destroy(zone, 0.4f);
    }
}
