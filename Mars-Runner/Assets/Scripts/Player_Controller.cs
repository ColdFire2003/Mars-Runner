using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class Player_Controller : MonoBehaviour
{
    #region Player Variables
    [Header("Player settings")]
    public float CurrentSpeed = 3f; // Base speed
    public float JumpForce = 5f; //The force that sends the player flying.
    [SerializeField] private bool IsJumping;
    [SerializeField] private Rigidbody2D RB_2D;
    [SerializeField] private GameObject StartButton;

    [Header("Animation curve")]
    [SerializeField] private AnimationCurve curve; //This curve desides the speed increase over a short or long periode.

    [Header("Curve settings")]
    public float speedMultiplier = 6.5f; // Max speed limit
    public int maxStep = 35; // iedere step gaat de speed sneller, max speed is na x steps
    private int currentStep = 0;

    [Header("Animator")]
    public Animator animator;
    #endregion
    private void Start()
    {
        RB_2D = GetComponent<Rigidbody2D>();
        CurrentSpeed = 0;
    }

    private void Update()
    {
        //makes the player go forward
        transform.Translate(Vector2.right * CurrentSpeed * Time.deltaTime);

        animator.SetFloat("Speed", CurrentSpeed);

        //if player jumps it checks if it may while the button is help down and prevents that players need to time the jump
        if (Input.GetKey(KeyCode.Space) && IsJumping == false || Input.GetKey(KeyCode.W) && IsJumping == false)
        {
            RB_2D.velocity = Vector2.up * JumpForce;
            FindObjectOfType<AudioManager>().Play("Player Jump");
            animator.SetBool("IsJumping", true);
        }
    }

    //Makes the player go faster with a animation curve to make the speed increase quick or slow
    public void IncreaseSpeed()
    {
        currentStep++; // makes the step go 1 up. 
        CurrentSpeed = 1f + curve.Evaluate((float)currentStep / (float)maxStep) * speedMultiplier; // makes the player faster
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public void StartPlayerMovement()
    {
        StartCoroutine(StartRunning());
    }

    IEnumerator StartRunning()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        yield return new WaitForSeconds(0.25f);
        StartButton.SetActive(false);
        CurrentSpeed += 4f;
        StopAllCoroutines();
    }

    #region Ground check

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;
        }
    }
    #endregion
}
