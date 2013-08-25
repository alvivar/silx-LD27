using UnityEngine;
using System.Collections;


/// <summary>
/// Tk2d anime animates using tk2d and motion data.
/// </summary>

// #todo this component is almost always hardcoded.

[RequireComponent( typeof ( Motion ) )]
[RequireComponent( typeof ( tk2dSpriteAnimator ) )]

public class tk2dAnime : MonoBehaviour
{
	public bool attack = false; // activate the attack sprite.
	
	private Motion motion;
	
	private tk2dSpriteAnimator animator;

	
	void Start()
	{
		motion = GetComponent<Motion>();
		
		animator = GetComponent<tk2dSpriteAnimator>();
	}

	
	void Update()
	{
		// on motion.
		
		if ( motion.velocity != 0 )
		{
			// attack have priority over walk.
			
			if ( attack )
			{
				animator.Play( "Attack" );
			}
			else if ( motion.isGrounded )
			{
				animator.Play( "Walk" );
			}
			
			// change the flipside based on the last direction.
			// this component assume that the sprite is looking right by default.
			
			switch ( motion.lastDirection )
			{
				case Direction.Left:
					
					animator.Sprite.FlipX = true;
					
					break;
										
				case Direction.Right:
					
					animator.Sprite.FlipX = false;
					
					break;
			}
		}
		else
		{
			// do nothing.
			
			animator.Stop();
		}
	}
}
