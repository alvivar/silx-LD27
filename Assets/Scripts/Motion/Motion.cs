using UnityEngine;
using System.Collections;


// SILX motion system.

[RequireComponent( typeof ( CharacterController ) )]

public class Motion : MonoBehaviour
{
	public bool update = true;
	
	// properties
	
	public float layer = 0;
	
	public float gravity = 5f;
	
	public float speed = 1.1f;
	
	// modifiers
	
	public Vector3 impulse = Vector3.zero;
	
	// core
	
	private CharacterController controller;
	
	private Vector3 movement = Vector3.zero;
	
	
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	
	void Update()
	{
		// motion over the object using movement.
		
		movement = transform.TransformDirection( movement );

		movement *= speed;
		
		// impulse engine
		
		if ( impulse != Vector3.zero )
		{
			movement = Vector3.Lerp( movement, impulse, 0.25f );

			impulse *= 1.75f;
		}
		
		// gravity control
		
		if ( !controller.isGrounded )
		{
			movement.y -= gravity * Time.deltaTime;
		}
		
		// pure motion
		
		controller.Move( movement * Time.deltaTime );
	}

	
	void FixedUpdate()
	{
		// z is fixed.
		
		if ( transform.position.z != layer )
		{
			transform.position = new Vector3( transform.position.x, transform.position.y, layer );
		}
	}
}
