using UnityEngine;
using System.Collections;


/// <summary>
/// Motion system for platform games.
/// </summary>

public enum Direction
{
	None,
	Left,
	Right
}


[RequireComponent( typeof ( CharacterController ) )]

public class Motion : MonoBehaviour
{
	// output
	
	public bool isGrounded
	{
		get
		{
			return controller.isGrounded;
		}
	}


	public float velocity = 0;
	
	public Vector3 lastPosition = Vector3.zero;
	
	public Direction lastDirection = Direction.None;
	
	// properties
	
	public float layer = 0;
	
	public float gravity = 0.6f;
	
	public float speed = 8f;
	
	// configs
	
	public bool backUpX = false; // this two backup the movement, allowing other components...
	
	public bool backUpY = true; // ...to use the same vector.
	
	// modifiers
	
	public Vector3 movement = Vector3.zero;
		
	// core
	
	private CharacterController controller = null;

	
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	
	void Update()
	{	
		// z is fixed.
		
		if ( transform.position.z != layer )
		{
			transform.position = new Vector3( transform.position.x, transform.position.y, layer );
		}
		
		// pack for backup.
		
		float yBack = movement.y;
		
		float xBack = movement.x;
		
		// motion over the object using movement.
		
		movement = transform.TransformDirection( movement );

		movement *= speed;
		
		// unpack if neccesary.
		
		if ( backUpX )
		{
			movement.x = xBack;
		}
		
		if ( backUpY )
		{
			movement.y = yBack;
		}
		
		// gravity control
		
		if ( !controller.isGrounded )
		{
			movement.y -= gravity;
		}
		else
		{	
			movement.y = movement.y < 0 ? 0 : movement.y;
		}
				
		// pure motion
		
		controller.Move( movement * Time.deltaTime );
		
		// velocity calculation
		
		velocity = Vector3.Distance( transform.position, lastPosition );
		
		lastPosition = transform.position;
	}
	

	void OnControllerColliderHit( ControllerColliderHit hit )
	{
		// head collision
		
		if ( ( controller.collisionFlags & CollisionFlags.Above ) != 0 )
		{
			movement = Vector3.zero;
		}
		
		// foot collision
		
		if ( ( controller.collisionFlags & CollisionFlags.Sides ) == 0 && transform.position.y > hit.transform.position.y )
		{
			movement = Vector3.zero;
		}

	}
}
