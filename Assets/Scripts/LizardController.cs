using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LizardController : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
    [SerializeField] private LayerMask IsGround;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float jumpHeight = 300.0f;
    
    
    private bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;
    
    private Rigidbody2D m_Rigidbody2D;


    private bool grounded;
    const float GroundedRadius = .2f;

    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }


    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll (GroundCheck.position, GroundedRadius, IsGround);
        for (int i = 0; i<colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                grounded = true;
                if(!wasGrounded)
                    OnLandEvent.Invoke();
        }

    }
    void Update()
    {
        
    }
    public void Move(float move, bool jump)
    {
        ///Movement smoothing. Stolen Code!
		Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        ///Flip our boi based on movement direction.
        ///Also stolen code, but kind of the only way to do it.
		if (move > 0 && !m_FacingRight)
		{
			Flip();
		}
		else if (move < 0 && m_FacingRight)
		{
			Flip();
		} 

        if (grounded && jump)
        {
            grounded = false;
             m_Rigidbody2D.AddForce(transform.up * jumpHeight);
        }
         
    }

    



    ///The stuff that actually flips our boi
    private void Flip()
     {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
     }

}
