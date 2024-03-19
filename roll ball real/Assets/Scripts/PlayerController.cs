using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Linq; 
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPosition;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public float rotationSpeed = 100.0f;
    private List<GameObject> pickUps;

    public int lives = 3;

    public TextMeshProUGUI livesText;

    public Timer timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position; // Guarda a posição inicial do jogador

        count = 0;
        SetCountText();

        pickUps = new List<GameObject>(GameObject.FindGameObjectsWithTag("PickUp")); // Encontra e guarda todas as moedas

         if (livesText == null)
            {
               Debug.LogError("livesText não foi atribuído no Inspector");
            }
        
        SetLivesText(); // Atualiza a exibição de vidas no início do jogo
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        if (movement.magnitude > 0.1)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void Update(){
      if (timer.timeLeft <= 0){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }
    }

   void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("PickUp"))
      {
         other.gameObject.SetActive(false);
         count += 1;
         SetCountText();
         if (timer != null)
         {
               timer.AddTime(30.0f);
         }
         else
         {
               Debug.LogError("deu ruim no timer");
         }
      }
      else if (other.gameObject.CompareTag("LavaPuddle"))
      {
         lives -= 1;

         if (lives <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         }


         SetLivesText();
         timer.ResetTimeToTwoMinutes();
         ResetGame();
      }
      else if (other.gameObject.CompareTag("Finish"))
      {
         SceneManager.LoadScene("WinScreen");
      }
   }


    void ResetGame()
    {
        transform.position = startPosition;
        rb.velocity = Vector3.zero;
        count = 0;
        SetCountText();
        
        foreach (var pickUp in pickUps)
        {
            pickUp.SetActive(true);
        }   
    }

    void SetCountText()
    {
        countText.text = "Moedas coletadas: " + count.ToString();
    }

    void SetLivesText()
    {
        livesText.text = "Vidas: " + lives.ToString();
    }
}
