using UnityEngine;
using System.Collections;


/// <summary>
/// Bullet cleaner destroy the bullet when is not needed.
/// </summary>

public class BulletCleaner : MonoBehaviour
{
	void OnBecameInvisible()
	{
		Destroy( transform.gameObject );
	}
}
