using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Melons;
    [SerializeField] private TextMeshProUGUI Money_Text;
    public GameObject UI;

    private void Start()
    {
        Melons = PlayerPrefs.GetInt("Melon");
    }

    private void Update()
    {
        //Sets the text to current amount of money
        Money_Text.text = Melons.ToString();
#if UNITY_EDITOR
        //cheat
        if(Input.GetKeyDown(KeyCode.C))
        CollectMoney(100);
#endif
    }

    public void CollectMoney(int Amount)
    {
        PlayerPrefs.SetInt("Melon", Melons + Amount); //Gives the player more money
        Melons = PlayerPrefs.GetInt("Melon");
    }

    public void UsedMoney(int Amount)
    {
        PlayerPrefs.SetInt("Melon", Melons - Amount); //Gives the player more money
        Melons = PlayerPrefs.GetInt("Melon");
    }

    public void HitObject()
    {
        UI.SetActive(true);
    }

    //Resets the current sceen
    public void Reset()
    {
        SceneManager.LoadScene("Main");
    }
}
