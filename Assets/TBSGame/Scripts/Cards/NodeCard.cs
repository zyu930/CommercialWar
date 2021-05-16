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
			Code,
			Framework
		}
		[Title("标准属性")]
		public int Durable = 1; //耐久值
		public NodeType NType = NodeType.Code;
	}
}
