using UnityEngine;
using System.Collections;


// Jump into the mouse source!

[RequireComponent( typeof ( Motion ) )]

public class MotionMouseJump : MonoBehaviour
{
	public bool update = true;
	
	public KeyCode key = KeyCode.Space;

	public float impulse = 50f;
	
	private Motion motion;

	
	void Start()
	{
		motion = GetComponent<Motion>();
	}


	void Update()
	{
		// on key press, inject an impulse into the Motion.
		
		if ( Input.GetKeyDown( key ) )
		{
			motion.impulse = MotionUtility.GetMouseDirection( transform ) * impulse;
		}
	}
}
