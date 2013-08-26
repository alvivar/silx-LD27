using UnityEngine;
using System.Collections;


/// <summary>
/// FX blinker change the material with a timer over a list (or random).
/// It's compatible with the magnificient Messenger.
/// </summary>

public class FXBlinkMediator : MonoBehaviour
{
	public Material[] materials;
	
	public float rate = 0; // if this is 0, it's turned off.
	
	public float lerpDuration = 0;
	
	private float rateTimer = 0;

	
	void Awake()
	{
		Messenger.AddListener<float, float>( FXBlinkMediatorEvent.Set, SetEventHandler );
	}


	void Update()
	{
		// needs to be over 0 to be active.
		
		if ( rate < 0 || materials.Length <= 0 )
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
		return materials[ Random.Range( 0, materials.Length - 1 ) ];
	}

	
	/// <summary>
	/// Sets the rate and lerp duration.
	/// </summary>
	/// <param name='rate'>
	/// Rate.
	/// </param>
	/// <param name='lerpDuration'>
	/// Lerp duration.
	/// </param>
	void SetEventHandler( float rate, float lerpDuration )
	{
		this.rate = rate;
		
		this.lerpDuration = lerpDuration;
	}
}
