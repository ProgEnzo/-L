using UnityEngine;

public class Damager : MonoBehaviour
{
    public float damages;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Inflige des dégâts");
        }
    }
}
