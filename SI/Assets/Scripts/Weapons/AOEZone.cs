using UnityEngine;

public class AOEZone : MonoBehaviour
{
    public float damages;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Damages
        }
    }
}
