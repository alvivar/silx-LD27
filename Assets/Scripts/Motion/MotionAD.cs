using UnityEngine;
using System.Collections;


/// <summary>
/// Allow AD (left, right) movement in Motion with GetAxis.
/// </summary>

[RequireComponent( typeof ( Motion ) )]

public class MotionAD : MonoBehaviour
{
	public bool update = true;
	
	public bool wait = false; // if wait is true, the component will be waiting for a keyboard signal.
	
	private Motion motion;

	
	void Start()
	{
		motion = GetComponent<Motion>();
	}

	
	void Update()
	{
		// activate the component on key press, if (wait). also motion defaults.
		
		if ( wait && ( Input.GetKeyDown( KeyCode.A ) || Input.GetKeyDown( KeyCode.D ) ) )
		{
			motion.backUpX = false;
			
			wait = false;
			
			update = true;
		}
		
		// if we are waiting, then turn off the component.
		
		if ( wait )
		{
			update = false;
		}
		
		// component activation
		
		if ( !update )
		{
			return;
		}
		
		// AD
		
		motion.movement.x = Input.GetAxisRaw( "Horizontal" );
		
		// change the last direction on motion, to tell other components
		// where we go.
		// #todo this need to be automatic.
		
		if ( motion.movement.x < 0 )
		{
			motion.lastDirection = Direction.Left;
		}
		
		if ( motion.movement.x > 0 )
		{
			motion.lastDirection = Direction.Right;
		}
	}
}
