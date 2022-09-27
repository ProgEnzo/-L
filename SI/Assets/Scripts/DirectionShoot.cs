using UnityEngine;

public class DirectionShoot : MonoBehaviour
{
    public Vector2 direction;

    public static DirectionShoot instance;
    private void Awake()
    {
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        }
    }
    void Update()
    {
        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        Debug.DrawLine(transform.position, direction * 100f, Color.green);
    }
}