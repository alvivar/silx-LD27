using UnityEngine;
using System.Collections;


/// <summary>
/// Shoots rigidbody bullets with an impulse, fire rate and layer
/// using the mouse as source.
/// </summary>
// #todo this class probably need a better fusion with bullet fire generator.

public class BulletFire : MonoBehaviour
{
	public Transform bullet;
	
	public int mouseCode = 0;

	public float layer = 0;

	public float impulse = 10f;
	
	public float fireRate = 0.5f;
	
	private float rateLock = 0;


	void Update()
	{
		// fire rate
		
		if ( Time.time < rateLock || !bullet )
		{
			return;
		}
		
		// keep the button down, like a machine gun.
		
		if ( Input.GetMouseButton( mouseCode ) )
		{
			// mouse direction to shoot.
			
			Vector3 fireDirection = MotionUtility.GetMouseDirectionFrom( transform );
			
			// bullet creation
			
			Transform fireBullet = Instantiate( bullet, transform.position, Quaternion.identity ) as Transform;
			
			// connect with bullet stabilizer to apply the impulse.
			
			BulletStabilizer stab = fireBullet.GetComponent<BulletStabilizer>();
			
			if ( !stab )
			{
				// the bullet stabilizer is required.
				
				return;
			}
			
			stab.layer = layer;
			
			stab.direction = fireDirection;
			
			stab.impulse = impulse;
			
			// fire rate lock
			
			rateLock = Time.time + fireRate;
		}
	}
}
