using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
 // Rigidbody of the player.
 private Rigidbody rb; 

 // Variable to keep track of collected "PickUp" objects.
 private int count;

 // Movement along X and Y axes.
 private float movementX;
 private float movementY;

 // Speed at which the player moves.
 public float speed = 0;

 // UI text component to display count of "PickUp" objects collected.
 public TextMeshProUGUI countText;

  // Velocidade de rotação ajustável no Inspetor
 public float rotationSpeed = 100.0f;


 // Start is called before the first frame update.
 void Start()
    {
 // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();

 // Initialize count to zero.
        count = 0;

 // Update the count display.
        SetCountText();
    }
 
 // This function is called when a move input is detected.
 void OnMove(InputValue movementValue)
    {
 // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

 // Store the X and Y components of the movement.
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

 // FixedUpdate is called once per fixed frame-rate frame.
private void FixedUpdate() 
{
    Vector3 movement = new Vector3(movementX, 0.0f, movementY);

    rb.AddForce(movement * speed); 

    if (movement.magnitude > 0.1) // Certifique-se de que há movimento significativo antes de rotacionar
    {
        Quaternion newRotation = Quaternion.LookRotation(movement);
        rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, rotationSpeed * Time.fixedDeltaTime);
    }
}

 
 void OnTriggerEnter(Collider other) 
    {
 // Check if the object the player collided with has the "PickUp" tag.
 if (other.gameObject.CompareTag("PickUp")) 
        {
 // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);

 // Increment the count of "PickUp" objects collected.
            count = count + 1;

 // Update the count display.
            SetCountText();
        }
    }

 // Function to update the displayed count of "PickUp" objects collected.
 void SetCountText() 
    {
 // Update the count text with the current count.
        countText.text = "Moedas coletadas: " + count.ToString();

//  // Check if the count has reached or exceeded the win condition.
//  if (count >= 6)
//         {
//  // Display the win text.
//             winTextObject.SetActive(true);
//         }
    }
}
