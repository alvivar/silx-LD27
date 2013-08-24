using UnityEngine;
using System.Collections;


public class MotionUtility
{
	/// <summary>
	/// Gets the mouse direction.
	/// </summary>
	/// <returns>
	/// The mouse direction.
	/// </returns>
	/// <param name='obj'>
	/// Object.
	/// </param>
	public static Vector3 GetMouseDirection( Transform obj )
	{
		Vector3 direction = ( Camera.main.ScreenToWorldPoint( Input.mousePosition ) - obj.position ).normalized;
		
		return direction;
	}
}
