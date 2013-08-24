using UnityEngine;
using System.Collections;


/// <summary>
/// Motion static utility.
/// </summary>

public class MotionUtility
{
	/// <summary>
	/// Gets the mouse direction from a transform.
	/// </summary>
	/// <returns>
	/// The mouse direction from a transform.
	/// </returns>
	/// <param name='obj'>
	/// Object.
	/// </param>
	public static Vector3 GetMouseDirectionFrom( Transform obj )
	{
		Vector3 direction = ( Camera.main.ScreenToWorldPoint( Input.mousePosition ) - obj.position ).normalized;
		
		return direction;
	}
	
	/// <summary>
	/// Cleans the XY negativity.
	/// </summary>
	/// <returns>
	/// The vector without negativity.
	/// </returns>
	/// <param name='vector'>
	/// Vector.
	/// </param>
	public static Vector3 CleanXYNegativity( Vector3 vector )
	{
		vector.x = vector.x < 0 ? 0 : vector.x;
		
		vector.y = vector.y < 0 ? 0 : vector.y;
		
		return vector;
	}
}
