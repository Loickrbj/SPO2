using UnityEngine;
using System.Collections;

namespace SPO2.Managers
{
	public class SingleBehaviour<T, ST> : MonoBehaviour
	where T : MonoBehaviour
	where ST : Object
	{
		#region Attributes
		protected ST settings;

		protected static T instance_;
		public static T instance
		{
			get
			{
				SetInstance();
				return instance_;
			}
		}
		#endregion

		#region Constructor
		public SingleBehaviour()
		{

		}
		#endregion

		#region MonoBehaviour Methods
		public virtual void Awake()
		{
			/*
            ST[] preLoad = Resources.LoadAll<ST>("ManagersSettings");
            if (preLoad.Length > 0)
                settings = preLoad[0];*/
		}
		#endregion

		#region Methods
		//public YieldInstruction WaitForSeconds(float duration)
		//{
		//	if (gameObject.activeInHierarchy)
		//		return StartCoroutine(Wait(duration));
		//	else
		//		return null;
		//}

		//protected IEnumerator Wait(float duration)
		//{
		//	for (float timer = 0; timer < duration && gameObject.activeInHierarchy; timer += TimeManager.instance.DeltaTime())
		//		yield return null;
		//}

		public static void SetInstance()
		{
			// Manager
			if (instance_ == null)
				instance_ = GameObject.FindObjectOfType(typeof(T)) as T;
			if (instance_ == null)
			{
				GameObject o = new GameObject("_SingleBehaviour_<" + typeof(T).ToString() + ">");
				instance_ = o.AddComponent<T>();

				// Root
				instance.transform.parent = HierarchyManager.GetRootManagersAtInitialization();
			}
		}
		#endregion

		#region Getters
		public ST GetSettings()
		{
			return settings;
		}
		#endregion
	}
}
