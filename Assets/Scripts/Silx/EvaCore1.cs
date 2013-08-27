using UnityEngine;
using System.Collections;


/// <summary>
/// Eva core: hardcoded boss stuff.
/// </summary>

public class EvaCore1 : MonoBehaviour
{
	private bool soundLock = false;

	
	void Update()
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes( Camera.main );
		
		bool visible = GeometryUtility.TestPlanesAABB( planes, renderer.bounds );
		
		if ( visible && !soundLock )
		{
			Messenger.Broadcast( CameraEvent.SetSecondaryFocus, transform );
			
			soundLock = true;
		}
	}
}
