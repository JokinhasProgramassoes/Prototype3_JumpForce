using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
//Variaveis:
    //Salto
    public float jumpForce = 10f;
    public float gravityModifier;
    //Detecta o chão
    public bool isOnGround = true;
    //Game over:
    public bool gameOver = false;
    //Animações
    private Animator playerAnim;
    private Rigidbody playerRb;
    //FX:
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    //Sound:
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Pressionar espaço para saltar:
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            //Animação de saltar:
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Detectar o chao para não dar infinte jumps:
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
