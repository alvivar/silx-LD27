using UnityEngine;
using System.Collections;


/// <summary>
/// Impulse the player into the mouse cursor when the mouse button 2
/// is pressed.
/// </summary>

[RequireComponent( typeof ( Motion ) )]

public class MotionMouseJump : MonoBehaviour
{
	public bool update = true;

	public float impulse = 50f;
	
	private Motion motion;
	
	private MotionAD wasd;

	
	void Start()
	{
		motion = GetComponent<Motion>();
		
		wasd = GetComponent<MotionAD>();
	}


	void Update()
	{
		// on key press, inject an impulse into the Motion.
		
		if ( Input.GetMouseButton( 1 ) )
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
			
			motion.movement.y = MotionUtility.GetMouseDirectionFrom( transform ).y * impulse;
			
			motion.movement.x = MotionUtility.GetMouseDirectionFrom( transform ).x * impulse;
		}
	}
}
