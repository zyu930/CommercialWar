using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TBSGame.Units;

namespace TBSGame.Cards
{
	[CreateAssetMenu(menuName = ("TBSGame/Cards/Unit Card"))]
	public class UnitCard : Card
	{
		public Unit spawnUnit;
		
		override public GameLink.CardTakeType CardType
		{
			get {return GameLink.CardTakeType.Unit;}
		}
	}
}
