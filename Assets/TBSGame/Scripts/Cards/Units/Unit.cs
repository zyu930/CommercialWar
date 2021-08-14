using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TBSGame.Units
{
	[CreateAssetMenu(menuName = ("TBSGame/Units/None Unit"))]
	public class Unit : ScriptableObject
	{
		[Title("基础属性")]
		public string Title = "单位";
		public string Description = "我是一个单位";
		virtual public GameLink.UnitType UnitType
		{
			get {return GameLink.UnitType.None;}
		}
	}
}
