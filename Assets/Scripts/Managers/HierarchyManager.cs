using UnityEngine;

namespace SPO2.Managers
{
	public class HierarchyManager : SingleBehaviour<HierarchyManager, HierarchyManager>
	{
		#region Attributes
		// Managers Root
		private GameObject rootManagers;
		#endregion

		#region Methods
		private GameObject SetupRoot(string rootName)
		{
			GameObject root = new GameObject(rootName);
			root.tag = rootName;
			DontDestroyOnLoad(root);
			return root;
		}
		#endregion

		#region Root Getters
		public static Transform GetRootManagersAtInitialization()
		{
			GameObject root = GameObject.FindGameObjectWithTag("Managers");
			if (root == null)
			{
				root = new GameObject("Managers")
				{
					tag = "Managers"
				};
				DontDestroyOnLoad(root);
			}
			return root.transform;
		}

		// MANAGERS ROOT
		public Transform GetRootManagers()
		{
			if (rootManagers == null)
				rootManagers = SetupRoot("Managers");
			return rootManagers.transform;
		}
		#endregion
	}
}