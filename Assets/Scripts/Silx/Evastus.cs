using UnityEngine;
using System.Collections;


/// <summary>
/// Evastus is a god?
/// </summary>

public class Evastus : MonoBehaviour
{
	/// <summary>
	/// Suicides on timer.
	/// </summary>
	/// <param name='time'>
	/// Time.
	/// </param>
	public void SuicideTimer( float time )
	{
		Invoke( "Suicide", time );
	}

	
	/// <summary>
	/// Simple destroy object trick.
	/// </summary> 
	void Suicide()
	{
		Destroy( transform.gameObject );
	}
}
