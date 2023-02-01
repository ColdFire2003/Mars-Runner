using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathOnHit : MonoBehaviour
{
    private GameManager Instance;
    private void Awake()
    {
        Instance = FindObjectOfType<GameManager>();
    }
    // If the player collides with an object with this script They will die. 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            StartCoroutine(WaitBeforeGoBack());
        }
    }

    IEnumerator WaitBeforeGoBack()
    {
        FindObjectOfType<AudioManager>().Play("Player Death");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Main");
        StopAllCoroutines();
    }
}
