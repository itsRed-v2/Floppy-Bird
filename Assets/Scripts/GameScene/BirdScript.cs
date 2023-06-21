using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float jumpStrength;
    public float dashStrength;
    public float dashCooldown;
    public AudioSource audioSource;
    public AudioClip hitSoundClip;
    public AudioClip dashSoundClip;
    public Animator animator;
    public DashDisplayScript dashDisplay;
    private LogicScript logic;

    [Header("Sprites")]
    public SpriteRenderer spriteRenderer;
    public Sprite flapDownBird;
    public Sprite flapUpBird;
    public Sprite deadBird;

    private float timeUntilSpriteChange;
    private bool isInInitialState;
    private float dashTimer;

    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();

        isInInitialState = true;
        // at first, the bird does not fall
        rbody.simulated = false;

        dashTimer = 0;
    }

    void Update()
    {
        if (logic.isGameOver()) return;

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isInInitialState) StartPlayingState();

            rbody.velocity = Vector2.up * jumpStrength;
            audioSource.Play();
            
            setFlapping(true);
            timeUntilSpriteChange = 0.2f;
        }

        if (Input.GetKeyDown(KeyCode.D) && logic.hasGameStarted()) {
            dash();
        }

        if (timeUntilSpriteChange > 0) {
            timeUntilSpriteChange -= Time.deltaTime;
        } else {
            setFlapping(false);
        }

        if (dashTimer > 0) {
            updateDashCooldown();
        }

        if (transform.position.y < -18 || transform.position.y > 18) {
            die();
        }
    }

    void StartPlayingState() {
        isInInitialState = false;
        rbody.simulated = true;
        animator.enabled = false;
    }

    void setFlapping(bool isFlapping) {
        spriteRenderer.sprite = isFlapping ? flapUpBird : flapDownBird;
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (!logic.isGameOver()) {
            die();
        }

        float hitStrength = collisionInfo.relativeVelocity.magnitude / 20;
		hitStrength = Mathf.Min(1, hitStrength);
        if (hitStrength > 0.2) {
            audioSource.PlayOneShot(hitSoundClip, hitStrength);
        }
    }

    void die() {
        logic.gameOver(); 
        spriteRenderer.sprite = deadBird;
    }

    void dash() {
        if (dashTimer == 0) {
            rbody.velocity += Vector2.down * dashStrength;
            dashTimer = dashCooldown;
            audioSource.PlayOneShot(dashSoundClip, 0.6f);
        }
    }

    void updateDashCooldown() {
        dashTimer -= Time.deltaTime;
        if (dashTimer < 0) 
            dashTimer = 0;

        float timeLeft = dashCooldown - dashTimer;
        float dashCoolDownProgress = timeLeft / dashCooldown;
        dashDisplay.Display(dashCoolDownProgress);
    }

}
