using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPO2.Managers
{
	public class ManagerInitializer : MonoBehaviour
	{
		#region MonoBehaviour Methods
		// Use this for initialization
		private void Awake()
		{
			ManagerInitializer[] initializers = FindObjectsOfType<ManagerInitializer>();
			if (initializers.Length > 1)
				Destroy(gameObject);
			else
			{
				// Manager Roots
				HierarchyManager.SetInstance();
				GameManager.SetInstance();
				//GameMasterManager.SetInstance();

				DontDestroyOnLoad(gameObject);
			}
		}

		private void OnDestroy()
		{

		}

		public static void StartManagers()
		{

		}

		public static void StopManagers()
		{

		}
		#endregion
	}

}