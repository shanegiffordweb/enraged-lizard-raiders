using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardMovement : MonoBehaviour
{
    public LizardController controller;
    public Animator animator;

    float horizontalMove = 0f;
    public float speed = 40f;

    // Update is called once per frame
    void Update()
    {
      horizontalMove =  Input.GetAxisRaw("Horizontal") * speed;

      animator.SetFloat("Speed", Mathf.Abs(horizontalMove));  
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime);
    }
}
