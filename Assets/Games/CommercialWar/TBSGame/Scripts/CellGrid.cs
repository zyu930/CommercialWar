using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TbsFramework.Cells;

namespace TBSGame
{
	public class CellGrid : MonoBehaviour
	{
		public List<Cell> Cells;
		
		public bool isLoaded;
		
		void Start()
		{
			Cells = new List<Cell>();
			for (int i = 0; i < transform.childCount; i++)
			{
				var cell = transform.GetChild(i).gameObject.GetComponent<Cell>();
				if (cell != null)
					Cells.Add(cell);
				else
					Debug.LogError("Invalid object in cells paretn game object");
			}
			isLoaded = true;
		}
	}
}
