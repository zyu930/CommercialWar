using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TBSGame.Cards
{
	[CreateAssetMenu(menuName = ("TBSGame/Cards/Node Card"))]
	public class NodeCard : Card
	{
		public enum NodeType
		{
			Code, //代码
			Framework, //架构
			Core //核心
		}
		[Title("标准属性")]
		public int Durable = 1; //耐久值
		public NodeType NType = NodeType.Code;
		
		override public GameLink.CardTakeType CardType
		{
			get {return GameLink.CardTakeType.Node;}
		}
	}
}
