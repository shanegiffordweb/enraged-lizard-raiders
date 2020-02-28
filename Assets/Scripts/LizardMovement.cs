using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class LizardMovement : MonoBehaviour
{
    public LizardController controller;
    public Animator animator;

    public static float horizontalMove = 0f;
    public float speed = 40f;
    void Start()
    {

    }
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
