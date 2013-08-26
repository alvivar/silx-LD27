using UnityEngine;
using System.Collections;


/// <summary>
/// FX blinker change the material with a timer over a list (or random).
/// It's compatible with the magnificient Messenger.
/// </summary>

public class FXBlinkMediator : MonoBehaviour
{	
	public Material defaultMaterial;

	public Material[] materials;
	
	public float rate = 0; // if this is 0, it's turned off.
	
	public float lerpDuration = 0;
	
	private float rateTimer = 0;

	
	void Awake()
	{
		// Messenger functions
		
		Messenger.AddListener<float, float>( FXBlinkEvent.Set, SetEventHandler );
		
		Messenger.AddListener( FXBlinkEvent.Suicide, SuicideEventHandler );
		
		// if there is a default material, let's change clothes.
		
		if ( defaultMaterial )
		{
			transform.renderer.material = defaultMaterial;
		}
	}


	void Update()
	{
		// needs to be over 0 to be active.
		
		if ( rate <= 0 || materials.Length <= 0 )
		{
			return;
		}
		
		// timer to change the lerp.
		
		if ( Time.time > rateTimer )
		{
			LerpMaterial( RandomMaterial(), RandomMaterial(), lerpDuration );
			
			rateTimer = Time.time + rate;
		}
	}

	/// <summary>
	/// Lerps the material.
	/// </summary>
	/// <param name='origin'>
	/// Origin.
	/// </param>
	/// <param name='destiny'>
	/// Destiny.
	/// </param>
	/// <param name='duration'>
	/// Duration.
	/// </param>/
	// #todo this need to be in a utility class.
	void LerpMaterial( Material origin, Material destiny, float duration )
	{
		float lerp = Mathf.PingPong( Time.time, duration ) / duration;
			
		renderer.material.Lerp( origin, destiny, lerp );
	}


	/// <summary>
	/// Get a random material from the list.
	/// </summary>
	/// <returns>
	/// The material.
	/// </returns>
	Material RandomMaterial()
	{
		return materials[ Random.Range( 0, materials.Length ) ];
	}

	
	/// <summary>
	/// Set the specified rate and lerpDuration.
	/// </summary>
	/// <param name='rate'>
	/// Rate.
	/// </param>
	/// <param name='lerpDuration'>
	/// Lerp duration.
	/// </param>
	public void Set( float rate, float lerpDuration )
	{
		SetEventHandler( rate, lerpDuration );
	}


	void SetEventHandler( float rate, float lerpDuration )
	{
		this.rate = rate;
		
		this.lerpDuration = lerpDuration;
	}
	
	
	/// <summary>
	/// Suicide this gameObject.
	/// </summary>
	void SuicideEventHandler()
	{
		Messenger.RemoveListener<float, float>( FXBlinkEvent.Set, SetEventHandler );
		
		Messenger.RemoveListener( FXBlinkEvent.Suicide, SuicideEventHandler );
		
		Destroy( transform.gameObject );
	}
}
