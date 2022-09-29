using UnityEngine;

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
