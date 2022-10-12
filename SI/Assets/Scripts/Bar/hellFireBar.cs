using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class hellFireBar : MonoBehaviour
{
    private Image timerBar;
    public float maxTime;
    private float timeLeft;
    public GameObject timesUp;
    public GameObject gameOverMenu;
    public GameObject gameOverText;
    
    private void Start()
    {
        timesUp.SetActive(false);
        gameOverMenu.SetActive(false);
        gameOverText.SetActive(true);
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.DOFillAmount(timeLeft / maxTime, duration : 0.15f);
            
            Color newColor = Color.red;
        }
        else 
        {
            timesUp.SetActive(true);
            gameOverMenu.SetActive(true);
            gameOverText.SetActive(false);
            Time.timeScale = 0;
        }

        if (timeLeft == 0)
        {
            PlayerController.instance.TakeDamage(1000f);
        }
        
    }

    public void FlagIsCaptured()
    {
        timeLeft += maxTime / 3f;

        timeLeft = Mathf.Clamp(timeLeft, 0, maxTime);
    }
  
}
