using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class hellFireBar : MonoBehaviour
{
    private Image timerBar;
    public float maxTime;
    private float timeLeft;
    public GameObject TimesUp;
    
    private void Start()
    {
        TimesUp.SetActive(false);
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
            TimesUp.SetActive(true);
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
