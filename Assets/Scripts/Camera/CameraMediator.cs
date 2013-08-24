using UnityEngine;
using System.Collections;


/// <summary>
/// Camera mediator.
/// </summary>

public class CameraMediator : MonoBehaviour
{
	public Transform currentFocus;

	public float cameraSpeed = 10f;

	public Vector2 offset;


	void Awake()
	{
		Messenger.AddListener<Transform>( CameraEvent.Focus, FocusEventHandler );
	}


	void Update()
	{
		if ( !currentFocus )
		{
			return;
		}

		Vector3 newCameraPosition = new Vector3( currentFocus.position.x + offset.x, currentFocus.position.y + offset.y, transform.position.z );
        
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
