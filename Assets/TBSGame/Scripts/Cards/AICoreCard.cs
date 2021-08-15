using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TBSGame.Cards
{
	[CreateAssetMenu(menuName = ("TBSGame/Cards/AICore Card"))]
	public class AICoreCard : NodeCard
	{
		override public GameLink.CardTakeType CardType
		{
			get {return GameLink.CardTakeType.Node;}
		}
	}
}