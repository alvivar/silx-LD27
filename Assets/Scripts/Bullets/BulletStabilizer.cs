using UnityEngine;
using System.Collections;


/// <summary>
/// Bullet stabilizer mantains the impulse, direction and layer of a transform.
/// The transform is a bullet now. Also, if there is an enemy, this will follow!
/// </summary>

[RequireComponent( typeof ( Rigidbody ) )]

public class BulletStabilizer : MonoBehaviour
{
	public Transform enemy;
	
	public float layer = 0;

	public Vector3 direction = Vector3.zero;

	public float impulse = 0;

	
	void Start()
	{
		// rigidbody defaults
		
		rigidbody.isKinematic = false;
		
		rigidbody.useGravity = false;
	}

	
	void Update()
	{
		// keep the transform on the layer.
		
		if ( transform.position.z != layer )
		{
			transform.position = new Vector3( transform.position.x, transform.position.y, layer );
		}
		
		// follow the enemy if exists.
		
		if ( enemy )
		{
			direction = MotionUtility.GetDirection( transform.position, enemy.transform.position );
		}
	}

	
	void FixedUpdate()
	{
		// while there is an impulse, keep the reel.
		
		if ( impulse != 0 )
		{
			rigidbody.AddForce( direction * impulse );
		}
	}
}
