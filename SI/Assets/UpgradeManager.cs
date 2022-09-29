using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject _mitraillette;
    [SerializeField] GameObject _shotgun;
    [SerializeField] GameObject _missileLauncher;
    [SerializeField] GameObject _aoe;
    [SerializeField] GameObject _meteors;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _mitraillette.GetComponent<Weapon>().LevelUp();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            _shotgun.GetComponent<Weapon>().LevelUp();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            _missileLauncher.GetComponent<Weapon>().LevelUp();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            _aoe.GetComponent<Weapon>().LevelUp();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            _meteors.GetComponent<Weapon>().LevelUp();
        }
    }
}

public enum TierEnum
{
    cooldown =0,
    damage =1,
    angle =2,
    number =3,
    weapon =4
}