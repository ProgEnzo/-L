using DG.Tweening;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class healthBar : MonoBehaviour
{
    public Image HealthBarImage;
    public SO_Controller player;
    
    public void UpdateHealthBar()
    {
        float duration = 0.15f * (player.currentLife / player.maxLife);
        HealthBarImage.DOFillAmount(player.currentLife / player.maxLife, duration);

        Color newColor = Color.green;
        if (player.currentLife < player.maxLife * 0.25f)
        {
            newColor = Color.red;
        }
        else if (player.currentLife < player.maxLife * 0.66f)
        {
            newColor = Color.yellow;
        }

        HealthBarImage.DOColor(newColor, duration);
    }
}
