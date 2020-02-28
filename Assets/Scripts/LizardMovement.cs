using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class LizardMovement : MonoBehaviour
{
  public LizardController controller;
  public Animator animator;

  public static float horizontalMove = 0f;
  public float speed = 10f;
  bool jump = false;

  void Start()
  {

  }
  void Update()
    {
    ///Get only X axis input (1, 0, -1)
    horizontalMove =  Input.GetAxisRaw("Horizontal") * speed;
    ///Speed variable for animator controller
    animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

      if (Input.GetButtonDown("Jump"))
      {
        jump = true;
        animator.SetBool("Jumping", true);
      }  
    }

    public void Landing ()
    {
      animator.SetBool("Jumping", false);
    }
    void FixedUpdate()
    {
      controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
      jump = false;
    }
}
