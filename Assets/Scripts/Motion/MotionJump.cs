using UnityEngine;
using System.Collections;


/// <summary>
/// Allows jump in motion when certain keycode is pressed.
/// </summary>

[RequireComponent( typeof ( Motion ) )]

public class MotionJump : MonoBehaviour
{
	public KeyCode key = KeyCode.Space;
	
	public float jumpForce = 10f;
		
	private Motion motion;


	void Start()
	{
		motion = GetComponent<Motion>();
	}

	
	void Update()
	{
		if ( Input.GetKeyDown( key ) )
		{
			motion.backUpY = true;
			
			motion.movement.y = jumpForce;
		}
	}
}
