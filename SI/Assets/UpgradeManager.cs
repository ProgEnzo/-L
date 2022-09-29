using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

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

    private GameObject aChoice;
    private GameObject bChoice;
    private GameObject cChoice;
    
    private void UpgradePartTwo()
    {
        aChoice = list[Random.Range(0,list.Count-1)];
        bChoice = list[Random.Range(0,list.Count-1)];
        cChoice = list[Random.Range(0,list.Count-1)];
        
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

    [SerializeField] private Button[] buttons;
    [SerializeField] private TextMeshProUGUI button1;
    [SerializeField] private TextMeshProUGUI button2;
    [SerializeField] private TextMeshProUGUI button3;
    
    private void UpgradePartThree()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
        
        button1.text = $"{aChoice.name}";
        button2.text = $"{bChoice.name}";
        button3.text = $"{cChoice.name}";

        Time.timeScale = 0f;
    }
    //Afficher dans le canva les améliorations
    
    private GameObject tempChoice;
    
    public void UpgradePartFour(int _x)
    {
        switch (_x)
        {
           case 1:
               tempChoice = aChoice;
               break;
           case 2:
               tempChoice = bChoice;
               break;
           case 3:
               tempChoice = cChoice;
               break;
        }

        if (tempChoice == _mitraillette || tempChoice == _shotgun || tempChoice == _missileLauncher)
        {
            tempChoice.GetComponent<ProjectilesWeapon>().LevelUp();
        }
        else if (tempChoice == _aoe)
        {
            tempChoice.GetComponent<AOE>().LevelUp();
        }
        else if (tempChoice == _meteors)
        {
            tempChoice.GetComponent<Meteors>().LevelUp();
        }

        Time.timeScale = 1f;
        
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        
    }
    //Envoyer la modif aux scripts
}

public enum TierEnum
{
    cooldown =0,
    damage =1,
    angle =2,
    number =3,
    weapon =4
}