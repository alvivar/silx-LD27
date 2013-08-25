using UnityEngine;
using System.Collections;


/// <summary>
/// Impulse the player into the mouse cursor when the mouse button 2
/// is pressed.
/// </summary>

[RequireComponent( typeof ( Motion ) )]

public class MotionMouseJump : MonoBehaviour
{
	public bool freezeLastCursorPosition = false;
	
	public float impulse = 50f;

	public Vector3 lastCursorPosition = Vector3.zero;
	
	private Motion motion;
	
	private MotionAD wasd;

	
	void Start()
	{
		motion = GetComponent<Motion>();
		
		wasd = GetComponent<MotionAD>(); // have wasd compatibility but is not required to work.
	}


	void Update()
	{
		// on key press, inject an impulse into the Motion.
		
		if ( Input.GetMouseButton( 1 ) )
		{			
			// toggle?
		
			if ( !freezeLastCursorPosition )
			{
				ImpulseIntoMouse();
			}
			else
			{
				// back up last x, y.
				
				lastCursorPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			}			
		}
		
		// if toggle, toggle into the last cursor position.
		
		if ( freezeLastCursorPosition && lastCursorPosition != Vector3.zero )
		{
			Vector3 direction = MotionUtility.GetDirection( transform.position, lastCursorPosition );
			
			ImpulseIntoMouse( direction.x, direction.y, impulse );
		}
	}
	
	
	/// <summary>
	/// Impulses the transform into mouse.
	/// </summary>
	void ImpulseIntoMouse()
	{
		ImpulseIntoMouse( MotionUtility.GetMouseDirectionFrom( transform ).x, MotionUtility.GetMouseDirectionFrom( transform ).y, impulse );
	}

	
	/// <summary>
	/// Impulses the transform into mouse. 
	/// </summary>
	/// <param name='xPosition'>
	/// X position.
	/// </param>
	/// <param name='yPosition'>
	/// Y position.
	/// </param>
	/// <param name='impulse'>
	/// Impulse.
	/// </param>
	void ImpulseIntoMouse( float xPosition, float yPosition, float impulse )
	{
		if ( wasd )
		{
			// if the WASD component exists, tell them to wait.
				
			wasd.wait = true;
		}
							
		// activate the back-up system.
			
		motion.backUpX = true;
			
		motion.backUpY = true;
		
		// impulse the player into the mouse.
			
		motion.movement.x = xPosition * impulse;
			
		motion.movement.y = yPosition * impulse;
	}
}
