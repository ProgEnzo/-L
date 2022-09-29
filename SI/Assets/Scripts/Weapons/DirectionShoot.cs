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
        var a = Input.mousePosition.x - transform.position.x;
        var b = Input.mousePosition.y - transform.position.y;
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (Time.timeScale != 0f)
        {
            Debug.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.green);
        }
        
    }
}