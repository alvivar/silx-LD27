using UnityEngine;
using System.Collections;


public class LevelSoundHelperMediator : MonoBehaviour
{	
	public AudioClip BG1Sound;
	
	public AudioClip BG2Sound;
	
	public AudioClip BG3Sound;

	
	void Awake()
	{
		Messenger.AddListener<int, bool>( "playclip", PlaySoundEventHandler );
	}

	
	void PlaySoundEventHandler( int soundID, bool loop )
	{
		switch ( soundID )
		{
			case 0:
				SoundManager.Get.PlayClip( BG1Sound, loop );
				break;
			case 1:
				SoundManager.Get.PlayClip( BG2Sound, loop );
				break;
			case 2:
				SoundManager.Get.PlayClip( BG3Sound, loop );
				break;
		}
	}
	
	
}
