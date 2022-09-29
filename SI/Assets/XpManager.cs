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
    
    [SerializeField] private float currentXP;

    private UpgradeManager upgradeManager;

    private void Start()
    {
        upgradeManager = GetComponent<UpgradeManager>();
    }

    public void GainXP(float t_xp)
    {
        currentXP += t_xp;
        upgradeManager.UpgradePartOne();
    }

}
