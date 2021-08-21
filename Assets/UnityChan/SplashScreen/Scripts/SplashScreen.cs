using UnityEngine;
using System.Collections;

namespace UnityChan
{
	[ExecuteInEditMode]
	public class SplashScreen : MonoBehaviour
	{
        private void NextLevel ()
		{
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}
}