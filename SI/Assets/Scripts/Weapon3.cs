using UnityEngine;

public class Weapon3 : MonoBehaviour
{
    public float angle;
    
    [Header("Tiers")]
    public int tierCooldowns;
    public int tierDamages;
    public int tierSizes;

    [Header("Valeurs")]
    [SerializeField] public float[] cooldowns;
    [SerializeField] public float[] damages;
    [SerializeField] public float[] sizes;
    void Update()
    {
        angle = Vector2.Angle(Vector2.right, DirectionShoot.instance.direction);
        if (DirectionShoot.instance.direction.y < transform.position.y)
        {
            angle = 360 - angle;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
