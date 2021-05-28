using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TBSGame.Cards
{
	[CreateAssetMenu(menuName = ("TBSGame/Cards/ComboCard Card"))]
	public class ComboCard : Card
	{
		public EffectCard effectCard;
		
		override public GameLink.CardTakeType CardType
		{
			get {return GameLink.CardTakeType.ComboCard;}
		}
	}
}
