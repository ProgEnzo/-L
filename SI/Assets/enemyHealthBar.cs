using DG.Tweening;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class enemyHealthBar : MonoBehaviour
{
    public Image HealthBarImage;
    public Enemies enemies;
    
    public void UpdateHealthBar()
    {
        float duration = 0.15f * (enemies.life / enemies.maxLife);
        HealthBarImage.DOFillAmount(enemies.life / enemies.maxLife, duration);

        Color newColor = Color.green;
        if (enemies.life < enemies.maxLife * 0.25f)
        {
            newColor = Color.red;
        }
        else if (enemies.life < enemies.maxLife * 0.66f)
        {
            newColor = Color.yellow;
        }

        HealthBarImage.DOColor(newColor, duration);
    }
}
