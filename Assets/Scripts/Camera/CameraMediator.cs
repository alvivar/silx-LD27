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
		// event handlers
		
		Messenger.AddListener<Transform>( CameraEvent.Focus, SetFocusEventHandler );
		
		Messenger.AddListener<Transform>( CameraEvent.SetSecondaryFocus, SetSecondaryFocusEventHandler );
		
		Messenger.AddListener( CameraEvent.RemoveSecundaryFocus, RemoveSecondaryFocusHandler );
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
	/// Sets the focus.
	/// </summary>
	/// <param name='focus'>
	/// Focus.
	/// </param>
	void SetFocusEventHandler( Transform focus )
	{
		currentFocus = focus;
	}
	
	
	/// <summary>
	/// Sets the secondary focus.
	/// </summary>
	/// <param name='secondaryFocus'>
	/// Secondary focus.
	/// </param>
	void SetSecondaryFocusEventHandler( Transform secondaryFocus )
	{
		this.secondaryFocus = secondaryFocus;
	}

	
	/// <summary>
	/// Removes the secondary focus.
	/// </summary>
	void RemoveSecondaryFocusHandler()
	{
		if ( secondaryFocus )
		{
			secondaryFocus = null;
		}
	}
}
