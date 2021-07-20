using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TBSGame.Units
{
	[CreateAssetMenu(menuName = ("TBSGame/Units/Soldier"))]
	public class Soldier : Unit
	{
		public enum SoldierType
		{
			Simple = 0,
			Melee = 1,
			LongRange = 2,
			Explode = 3,
			Giant = 4
		}
		
		[Title("标准属性")]
		public int Durable = 1; //耐久值
		public SoldierType soldierType = SoldierType.Simple;
		public int aggressivity = 1;
		public int aggressivityRange = 1;
		public int moveRange = 1;
		
		override public GameLink.UnitType UnitType
		{
			get {return GameLink.UnitType.Solider;}
		}
	}
}