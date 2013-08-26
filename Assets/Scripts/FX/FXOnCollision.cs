using UnityEngine;
using System.Collections;


/// <summary>
/// FX on collision with rigidbodies.
/// </summary>

public class FXOnCollision : MonoBehaviour
{
	public ParticleSystem particles;
	
	public float layer = 0;
	
	public bool destroyObject = false;

	
	void OnCollisionEnter( Collision collision )
	{
		if ( particles )
		{
			// create on the layer.
			
			Vector3 particlesPos = transform.position;
			
			particlesPos.z = layer;
			
			Instantiate( particles, particlesPos, Quaternion.identity );
			
			// destroy.
			
			if ( destroyObject )
			{
				Destroy( transform.gameObject );
			}
		}
	}
}
