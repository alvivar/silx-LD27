using UnityEngine;
using System.Collections;


/// <summary>
/// Generate bullets based on configuration.
/// </summary>
// #todo this class probably need a better fusion with bullet fire.

public class BulletFireGenerator : MonoBehaviour
{
	public Transform bullet;
	
	public Transform focus;
	
	public bool usePlayerAsFocus = false; // if set, the focus will always be the "Player".
	
	public bool followFocus = false;
	
	public float rate = 1; // for a random instantiater, min, max.
	
	public float rateVariation = 0; // this is added to rate to determine the max.
	
	public float layer = 0;
	
	public float impulse = 5f;
	
	private float rateLock = 1; // starts 1 seconds late, by default.
	
	
	void Update()
	{
		if ( Time.time > rateLock )
		{
			// player tag.
			
			if ( usePlayerAsFocus )
			{
				GameObject player = GameObject.FindWithTag( Tag.Player );
				
				if ( player )
				{
					focus = player.transform;
				}
			}
			
			// bullet factory (?)
			
			if ( bullet && focus )
			{
				// direction / creation
				
				Vector3 fireDirection = MotionUtility.GetDirection( transform.position, focus.transform.position );
				
				Transform fireBullet = Instantiate( bullet, transform.position, Quaternion.identity ) as Transform;
				
				// stabilizer
				
				BulletStabilizer stab = fireBullet.GetComponent<BulletStabilizer>();
			
				if ( !stab )
				{
					// the bullet stabilizer is required.
				
					return;
				}
				
				// follow?
				
				if ( followFocus )
				{
					stab.enemy = focus;
				}
				
				stab.layer = layer;
			
				stab.direction = fireDirection;
			
				stab.impulse = impulse;
				
				// fire rate lock (with variation)
			
				rateLock = Time.time + Random.Range( rate, rate + rateVariation );
			}
		}
	}
}
