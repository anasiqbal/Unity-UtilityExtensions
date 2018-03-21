using System.Collections.Generic;
using UnityEngine;

namespace UtilityExtensions
{
	public static class TransformExtensions
	{

		public static T FindComponentInChildWithTag<T>(this Transform parent, string tag) where T : Component
		{
			Transform t = parent.transform;
			foreach (Transform tr in t)
			{
				if (tr.CompareTag (tag))
				{
					return tr.GetComponent<T> ();
				}

				T component = tr.FindComponentInChildWithTag<T> (tag);
				if (component != null)
					return component;
			}

			return null;
		}

		public static List<T> FindComponentsInChildWithTag<T>(this Transform parent, string tag) where T : Component
		{
			Transform t = parent.transform;
			List<T> children = new List<T> ();
			foreach (Transform tr in t)
			{
				if (tr.CompareTag (tag))
				{
					children.Add (tr.GetComponent<T> ());
				}
				children.AddRange (tr.FindComponentsInChildWithTag<T> (tag));
			}

			return children;
		}

		public static void DestroyAllChildren(this Transform _parent)
		{
			List<Transform> children = new List<Transform> ();
			for (int i = 0; i < _parent.childCount; i++)
			{
				children.Add (_parent.GetChild (i));
			}

			children.ForEach (child => GameObject.DestroyImmediate (child.gameObject));
		}
	}
}