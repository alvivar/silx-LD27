using UnityEngine;
using System.Collections;


/// <summary>
/// Camera mediator.
/// </summary>

public class CameraMediator : MonoBehaviour
{
	public Transform currentFocus;
	
	public Transform secondaryFocus;

	public float cameraSpeed = 10f;

	public Vector2 offset;


	void Awake()
	{
		Messenger.AddListener<Transform>( CameraEvent.Focus, FocusEventHandler );
	}


	void Update()
	{
		// this is obvious.
		
		if ( !currentFocus )
		{
			return;
		}
		
		Vector3 newCameraPosition = Vector3.zero;
		
		// if the position is gonna be between two objects.
		
		if ( secondaryFocus )
		{
			float distanceBetween = Vector3.Distance( currentFocus.position, secondaryFocus.position );
			
			Vector3 positionBetween = ( currentFocus.position / 2 ) + ( secondaryFocus.position / 2 );
			
			newCameraPosition = new Vector3( positionBetween.x + offset.x, positionBetween.y + offset.y, transform.position.z );
		}
		else
		{
			newCameraPosition = new Vector3( currentFocus.position.x + offset.x, currentFocus.position.y + offset.y, transform.position.z );
		}
        
		transform.position = Vector3.Lerp( transform.position, newCameraPosition, Time.deltaTime * cameraSpeed );
	}
	
	
	/// <summary>
	/// Focuses the camera over the transform..
	/// </summary>
	/// <param name='focus'>
	/// Position.
	/// </param>
	void FocusEventHandler( Transform focus )
	{
		currentFocus = focus;
	}
}
