using UnityEngine;
using System.Collections;


/// <summary>
/// Silx dead. Game restart.
/// </summary>

public class SilxDead : MonoBehaviour
{
	public float hp = 1;
	
	private float rate = 0;


	void Update()
	{
		if ( hp <= 0 )
		{
			Destroy( gameObject );
		}
	}

	
	void OnCollisionEnter( Collision collision )
	{
		// respect the rate.
		
		if ( rate > Time.time )
		{
			return;
		}
		
		// detects collisions from the player bullets.
		
		if ( collision.gameObject.tag == "Bullet" && collision.gameObject.layer == LayerMask.NameToLayer( "EnemyFaction" ) )
		{
			hp -= 1;
			
			rate = Time.time + 0.25f;
		}
	}
}
