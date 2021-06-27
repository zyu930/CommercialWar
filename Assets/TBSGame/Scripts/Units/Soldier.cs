using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TBSGame.Units
{
	[CreateAssetMenu(menuName = ("TBSGame/Units/Soldier"))]
	public class Soldier : Unit
	{
		[Title("标准属性")]
		public int Durable = 1; //耐久值
		
		override public GameLink.UnitType UnitType
		{
			get {return GameLink.UnitType.Solider;}
		}
	}
}