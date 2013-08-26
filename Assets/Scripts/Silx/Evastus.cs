using UnityEngine;
using System.Collections;


public class Evastus : MonoBehaviour
{
	void Start()
	{
		Messenger.Broadcast( FXBlinkMediatorEvent.Set, 0.1f, 0.1f );
	}


	void Update()
	{
	
	}
}
