using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UpgradeUI : MonoBehaviour
{
    private GameManager Instance;
    private Player_Controller Player;

    //Skins
    private int Skin_1;
    private int Skin_2;
    private int Skin_3;
    private int Skin_4;
    public int CurrentSkin;

    [SerializeField] private int Cost_Skin_1;
    [SerializeField] private int Cost_Skin_2;
    [SerializeField] private int Cost_Skin_3;
    [SerializeField] private int Cost_Skin_4;

    [SerializeField] private RuntimeAnimatorController[] Skin = new RuntimeAnimatorController[5];

    private void Awake()
    {
        Instance = FindObjectOfType<GameManager>();
        Player = FindObjectOfType<Player_Controller>();
    }

    private void Start()
    {
        //skins
        //These make a int for every different skin
        Skin_1 = PlayerPrefs.GetInt("Skin1");
        Skin_2 = PlayerPrefs.GetInt("Skin2");
        Skin_3 = PlayerPrefs.GetInt("Skin3");
        Skin_4 = PlayerPrefs.GetInt("Skin4");
        CurrentSkin = PlayerPrefs.GetInt("CurrentSkin"); // this is the current skin
        Player.animator.runtimeAnimatorController = Skin[CurrentSkin]; //Sets the current skin selected to the player 
    }
    //With in are 4 functions 
    //each funtion does the same only different value's
    //When function is used the player sprites will change to 1 of the 4 skins
    #region Skins
    public void Skin1()
    {
        //checks if skin is unlocked if not then you buy it.
        if (Skin_1 != 0)
        {
            CurrentSkin = 1;
            PlayerPrefs.SetInt("CurrentSkin", 1);
            Player.animator.runtimeAnimatorController = Skin[CurrentSkin];
        }
        else
        {
            Instance.UsedMoney(Cost_Skin_1);

            PlayerPrefs.SetInt("Skin1", 1);
            Skin_1 = PlayerPrefs.GetInt("Skin1");
            CurrentSkin = 1;
            PlayerPrefs.SetInt("CurrentSkin", 1);
            Player.animator.runtimeAnimatorController = Skin[CurrentSkin];
        }
    }

    public void Skin2()
    {
        if (Skin_2 != 0)
        {
            CurrentSkin = 2;
            PlayerPrefs.SetInt("CurrentSkin", 2);
            Player.animator.runtimeAnimatorController = Skin[CurrentSkin];
        }
        else
        {
            Instance.UsedMoney(Cost_Skin_2);

            PlayerPrefs.SetInt("Skin2", 1);
            Skin_2 = PlayerPrefs.GetInt("Skin2");
            CurrentSkin = 2;
            PlayerPrefs.SetInt("CurrentSkin", 2);
            Player.animator.runtimeAnimatorController = Skin[CurrentSkin];
        }
    }

    public void Skin3()
    {
        if (Skin_3 != 0)
        {
            CurrentSkin = 3;
            PlayerPrefs.SetInt("CurrentSkin", 3);
            Player.animator.runtimeAnimatorController = Skin[CurrentSkin];
        }
        else
        {
            Instance.UsedMoney(Cost_Skin_3);

            PlayerPrefs.SetInt("Skin3", 1);
            Skin_3 = PlayerPrefs.GetInt("Skin3");
            CurrentSkin = 3;
            PlayerPrefs.SetInt("CurrentSkin", 3);
            Player.animator.runtimeAnimatorController = Skin[CurrentSkin];
        }
    }

    public void Skin4()
    {
        if (Skin_4 != 0)
        {
            CurrentSkin = 4;
            PlayerPrefs.GetInt("CurrentSkin", 4);
            Player.animator.runtimeAnimatorController = Skin[CurrentSkin];
        }
        else
        {
            Instance.UsedMoney(Cost_Skin_4);

            PlayerPrefs.SetInt("Skin4", 1);
            Skin_4 = PlayerPrefs.GetInt("Skin4");
            CurrentSkin = 4;
            PlayerPrefs.GetInt("CurrentSkin", 4);
            Player.animator.runtimeAnimatorController = Skin[CurrentSkin];
        }
    }
    #endregion

    //Deletes all saved data
    public void ResetAllData()
    {
        StartCoroutine(ResetButton());
    }

    IEnumerator ResetButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        yield return new WaitForSeconds(0.25f);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main");
        StopAllCoroutines();
    }
}
