using UnityEngine;
using UnityEngine.UI;

public class XpManager : MonoBehaviour
{
    #region Instance
    
    public static XpManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Il y a plus d'une instance de XpManager");
            DestroyImmediate(this);
        }
    }
    #endregion
    
    private UpgradeManager upgradeManager;

    private void Start()
    {
        upgradeManager = GetComponent<UpgradeManager>();
    }

    [SerializeField] private int currentLevel;
    [SerializeField] private float currentXP;
    [SerializeField] private float xpToNextLevel;
    [SerializeField] private float addToEachLevel;
    [SerializeField] private int paliers;

    [SerializeField] private Slider xpBar;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GainXP(10);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            FlagXP();
        }
        
        xpBar.value = currentXP / xpToNextLevel; // le faire avec dotween pour que ce soit propre
    }
    
    public void GainXP(float t_xp)
    {
        currentXP += t_xp;

        if (currentXP >= xpToNextLevel)
        {
            float tempXP = currentXP - xpToNextLevel;
            currentLevel++;
            GainALevel();
            currentXP = tempXP;

            if (currentLevel % paliers == 0)
            {
                xpToNextLevel += addToEachLevel;
            }
        }
        Debug.Log(currentXP / xpToNextLevel);
        
    }

    public void FlagXP()
    {
        GainXP(xpToNextLevel);
    }

    private void GainALevel()
    {
        upgradeManager.UpgradePartOne();
    }

}
