using UnityEngine;
using System.Collections;


/// <summary>
/// THIS IS HARDCORE.
/// </summary>

public class Mother : MonoBehaviour
{
	public GUIText text;
		
	public Transform boss1;
	
	private bool booss1kill = false;

	public Transform boss2;
	
	private bool booss2kill = false;

	public Transform boss3;
	
	private bool booss3kill = false;

	
	void Start()
	{
		text.text = "";
			
		Transform newBoss1 = Instantiate( boss1, new Vector3( 0, 0, 0 ), Quaternion.identity ) as Transform;
		
		GameObject.Find( "EnemyLocatorCompassPrefab" ).GetComponent<EnemyLocatorCompassMediator>().target = newBoss1;
		
		boss1 = newBoss1;
	}

	
	void Update()
	{				
		// check for the R to restart.
		
		if ( Input.GetKeyDown( KeyCode.R ) )
		{
			Application.LoadLevel( 0 );
		}
		
		// HARDCORE STUFF
		
		if ( boss1 == null && !booss1kill )
		{
			Transform newBoss2 = Instantiate( boss2, new Vector3( 100, 100, 0 ), Quaternion.identity ) as Transform;
		
			GameObject.Find( "EnemyLocatorCompassPrefab" ).GetComponent<EnemyLocatorCompassMediator>().target = newBoss2;
			
			boss2 = newBoss2;
			
			booss1kill = true;
		}
		
		if ( boss2 == null && !booss2kill )
		{
			Transform newBoss3 = Instantiate( boss3, new Vector3( -50, -50, 0 ), Quaternion.identity ) as Transform;
		
			GameObject.Find( "EnemyLocatorCompassPrefab" ).GetComponent<EnemyLocatorCompassMediator>().target = newBoss3;
			
			boss3 = newBoss3;
			
			booss2kill = true;
		}
		
		if ( boss3 == null && !booss3kill )
		{
			if ( text )
			{
				text.text = "ludum dare 27 by @alvivar\nspecial thanks to @tzamora";
			}
			
			booss2kill = true;
		}
	}
}
