using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TBSGame.Cards
{
	public class Card : ScriptableObject
	{
        [Title("基础属性")]
		public GameLink.CardTakeType CardType = GameLink.CardTakeType.None;
		public int ActionExpend = 1; //行动力消耗
		public string Title = "一张卡片";
		public string Description = "我是一张卡片...";
	}
}
