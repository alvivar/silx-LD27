using UnityEngine;
using System.Collections;


/// <summary>
/// How many eyes can an Evastus have?
/// </summary>

[RequireComponent( typeof ( FXBlinkMediator ) )]

public class EvastusEye : MonoBehaviour
{
	public static int brothers;
	
	public int hp = 1;
	
	private float massiveCrySuicide = 2;
	
	private FXBlinkMediator blinker;
	
	private bool deadLock = false; // you only die once.
	
	private bool cryLock = true; // the list need to have > 0 elements to activate the cry.
	
	private float selfDestruct = 0; // dead activation.
	
	private float rate = 0;

	
	void Start()
	{
		blinker = GetComponent<FXBlinkMediator>();
		
		// rigidbody config
		
		if ( rigidbody )
		{
			rigidbody.isKinematic = false;
		
			rigidbody.useGravity = false;
		}
		
		// add yourself into the list of eyes!
		
		brothers += 1;
	}


	void Update()
	{
		// deactivate the lock.
		
		if ( cryLock && brothers > 0 )
		{
			cryLock = false;
		}
		
		// die if needed. remove yourself from the count. BLINK.
		
		if ( !deadLock && hp <= 0 )
		{
			blinker.Set( 0.1f, 0.1f );
			
			brothers -= 1;
			
			deadLock = true;
		}

		// cry when the list is empty.
		
		if ( !cryLock && brothers <= 0 )
		{
			Cry();
			
			selfDestruct = Time.time + massiveCrySuicide;
			
			cryLock = true;
		}
		
		// suicide 
		
		if ( selfDestruct != 0 && Time.time > selfDestruct )
		{
			Messenger.Broadcast( CameraEvent.RemoveSecundaryFocus );
			
			Messenger.Broadcast( FXBlinkEvent.RandomSuicide, 3f );
			
			GameObject father = GameObject.FindWithTag( "Evastus" );
			
			if ( father )
			{
				Evastus evastus = father.GetComponent<Evastus>();
				
				if ( evastus )
				{
					evastus.SuicideTimer( 3.25f );
				}
			}
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
		
		if ( collision.gameObject.tag == "Bullet" && collision.gameObject.layer == LayerMask.NameToLayer( "PlayerFaction" ) )
		{
			hp -= 1;
			
			rate = Time.time + 0.25f;
		}
	}

	
	/// <summary>
	/// The dead of the eternals.
	/// </summary>
	void Cry()
	{
		Messenger.Broadcast<float, float>( FXBlinkEvent.Set, 0.1f, 0.1f );
	}
}
