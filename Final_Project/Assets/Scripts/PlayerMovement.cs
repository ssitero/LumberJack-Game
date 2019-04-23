using UnityEngine;

using System.Collections;
public class PlayerMovement : MonoBehaviour
 
{
 
private Vector3 movementVector;
private CharacterController characterController;
private float movementSpeed = 8;
private float jumpPower = 15;
private float gravity = 40;
void Start()

{
 
characterController = GetComponent<CharacterController>();
  
}
  26:  
  27: void Update()
  28:  
  29: {
  30:  
  31: movementVector.x = Input.GetAxis("LeftJoystickX") * movementSpeed;
  32:  
  33: movementVector.z = Input.GetAxis("LeftJoystickY") * movementSpeed;
  34:  
  35: if(characterController.isGrounded)
  36:  
  37: {
  38:  
  39: movementVector.y = 0;
  40:  
  41: if(Input.GetButtonDown("A"))
  42:  
  43: {
  44:  
  45: movementVector.y = jumpPower;
  46:  
  47: }
  48:  
  49: }
  50:  
  51: movementVector.y -= gravity* Time.deltaTime;
  52:  
  53: characterController.Move(movementVector* Time.deltaTime);
  54:  
  55: }
  56:  
  57: }