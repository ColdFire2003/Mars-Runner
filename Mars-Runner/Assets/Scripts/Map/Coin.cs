using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player_Controller player;
    private GameManager Instance;
    [SerializeField] private int Amount;
    private void Awake()
    {
       player = FindObjectOfType<Player_Controller>();
       Instance = FindObjectOfType<GameManager>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Collect());
    }

    IEnumerator Collect()
    {
        FindObjectOfType<AudioManager>().Play("Collect");
        yield return new WaitForSeconds(0.25f);
        player.IncreaseSpeed();
        Instance.CollectMoney(Amount);
        Destroy(gameObject);
       // StopAllCoroutines();
    }
}
