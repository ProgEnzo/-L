using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private GameObject _mitraillette;
    [SerializeField] private GameObject _shotgun;
    [SerializeField] private GameObject _missileLauncher;
    [SerializeField] private GameObject _aoe;
    [SerializeField] private GameObject _meteors;

    //Ajouter les 5 armes

    [SerializeField] private List<GameObject> list;

    public void UpgradePartOne()
    {
        if (_mitraillette.GetComponent<ProjectilesWeapon>().level <= 3)
        {
            list.Add(_mitraillette);
        }
        if (_shotgun.GetComponent<ProjectilesWeapon>().level <= 6)
        {
            list.Add(_shotgun);
        }
        if (_missileLauncher.GetComponent<ProjectilesWeapon>().level <= 4)
        {
            list.Add(_missileLauncher);
        }
        if (_aoe.GetComponent<AOE>().level <= 4)
        {
            list.Add(_aoe);
        }
        if (_meteors.GetComponent<Meteors>().level <= 6)
        {
            list.Add(_meteors);
        }
        
        UpgradePartTwo();
    }
    //Vérifier qu'une arme n'est pas déjà au max
    //Ajouter l'arme dans une liste

    public GameObject[] choices;
    
    private void UpgradePartTwo()
    {
        GameObject aChoice = list[Random.Range(0,list.Count-1)];
        GameObject bChoice = list[Random.Range(0,list.Count-1)];
        GameObject cChoice = list[Random.Range(0,list.Count-1)];
        
        while (aChoice == bChoice || aChoice == cChoice || bChoice == cChoice)
        {
            while (aChoice == bChoice)
            {
                aChoice = list[Random.Range(0,list.Count)];
            }
            while (aChoice == cChoice)
            {
                aChoice = list[Random.Range(0,list.Count)];
            }
            while (bChoice == cChoice)
            {
                bChoice = list[Random.Range(0,list.Count)];
            }
        }

        choices[0] = aChoice;
        choices[1] = bChoice;
        choices[2] = cChoice;
        
        list.Clear();

        UpgradePartThree();

    }

    private void UpgradePartThree()
    {
        UpgradePartFour();
    }
    //Afficher dans le canva les améliorations

    private void UpgradePartFour()
    {
        
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