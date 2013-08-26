using UnityEngine;
using System.Collections;


/// <summary>
/// Instantiate a particle when velocity is over velocity.
/// Release when down.
/// </summary>

[RequireComponent( typeof ( Motion ) )]

public class FXMotionVelocity : MonoBehaviour
{
	public ParticleSystem particles;
	
	public float layer = 0;
	
	public float velocity = 0.5f;
	
	private Motion motion;
	
	private bool limitLock = false;

	
	void Start()
	{
		motion = GetComponent<Motion>();
	}

	
	void Update()
	{		
		// overflow
		
		if ( !limitLock && motion.velocity >= velocity )
		{
			Vector3 pos = transform.position;
				
			pos.z = layer;
			
			if ( particles )
			{
				Instantiate( particles, pos, Quaternion.identity );
			}
				
			limitLock = true;
		}
		
		// cooldown
		
		if ( motion.velocity < velocity )
		{
			limitLock = false;
		}
	}
}
