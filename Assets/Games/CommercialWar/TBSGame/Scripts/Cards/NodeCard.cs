using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TBSGame.Units;

namespace TBSGame.Cards
{
	[System.Serializable]
	public struct AICore
	{
		public int SpawnTurnCount; //生产周期
		public int SpawnCount; //生产数量
		public Soldier solider; //兵棋种类
	}
	
	[CreateAssetMenu(menuName = ("TBSGame/Cards/Node Card"))]
	public class NodeCard : Card
	{
		public enum NodeType
		{
			Code, //代码
			Framework, //架构
			Core, //核心
			Barrier, //壁垒
			Obstacle //障碍物
		//Idea //创意（暂时不需要区分）
		}
		
		public enum ImageType
		{
			None, // 使用类型形象
			Idea // 创意的形象
		}
		[Title("标准属性")]
		public int Durable = 1; //耐久值
		public NodeType NType = NodeType.Code;
		
		[Title("动态属性")]
		
		[EnableIf("@this.NType == NodeType.Code")]
		public ImageType IType = ImageType.None;
		[EnableIf("@this.NType == NodeType.Code")]
		public int TurnCount = 0; //在场上的时间，0 是不限时间
		
		[EnableIf("@this.NType == NodeType.Core")]
		public AICore aiCore;
		
		override public GameLink.CardTakeType CardType
		{
			get {return GameLink.CardTakeType.Node;}
		}
	}
}
