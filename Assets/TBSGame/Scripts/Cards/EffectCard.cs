using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TBSGame.Cards
{

    [CreateAssetMenu(menuName = ("TBSGame/Cards/Effect Card"))]
	public class EffectCard : Card, IContinued, IModifyDurable
	{
		public enum EffectType
		{
			AddRange, // 增加范围
			LoseDurable, //失耐久
			Explosion, //自爆
			Swap, // 卡牌转换
			Plagiarism // 剽窃
        }
		
		public enum FlagType
		{
			Enemy,
			Friend
		}
		
		public enum SwapType
		{
			Node, //节点
			Unit //单位
		}

        [Title("标准属性")]

        public EffectType effectType = EffectType.AddRange;
		public FlagType flagType = FlagType.Enemy;

		[Title("动态属性")]
        
		
		[EnableIf("@this.effectType == EffectType.AddRange || this.effectType == EffectType.Plagiarism")]
		public int ContinuedRound = 0;
		[EnableIf("@this.effectType == EffectType.AddRange || this.effectType == EffectType.LoseDurable || this.effectType == EffectType.Explosion")]
		public int Value = 0;
        
        [DetailedInfoBox("推技能距离...", "发动后，目标格子周围六个方向上的第一格如果另一侧没有节点或争夺目标，则后退一格，否则原地不动。")]
        [EnableIf("effectType", EffectType.Explosion)]
		public int PushRange = 0;
		
		//卡牌交换
		
		[EnableIf("effectType", EffectType.Swap)]
		public SwapType swapType = SwapType.Node;
		[DetailedInfoBox("卡牌交换...", "")]
		[EnableIf("@this.effectType == EffectType.Swap && this.swapType == SwapType.Node")]
		public Card Origin = null; // 预交换的卡牌
		[EnableIf("effectType", EffectType.Swap)]
		public Card Target = null; // 目标卡牌
		[EnableIf("effectType", EffectType.Swap)]
		public int OriginNum = 1; // 预交换卡牌提供个数
		[EnableIf("effectType", EffectType.Swap)]
		public int TargetNum = 1; // 目标卡牌生成个数
		
		//剽窃
		[DetailedInfoBox("剽窃...", "")]
		[EnableIf("effectType", EffectType.Plagiarism)]
		public int killNum = 1; // 杀死的个数
		[EnableIf("effectType", EffectType.Plagiarism)]
		public int ideaNum = 1; // 获取创意个数
		
		//持续回合		
        public int GetContinuedRound()
		{
			int continuedRound = ContinuedRound;
			switch(effectType)
			{
			case EffectType.AddRange:
				continuedRound = 2;
				break;
			case EffectType.LoseDurable:
				continuedRound = 0;
				break;
			default:
				continuedRound = 0;
				break;
			}
			return continuedRound;
		}
		
		public float GetAffectValue()
		{
			return 0f;
		}
		public float GetEffectValue()
		{
			return Value;
		}
		override public GameLink.CardTakeType CardType
		{
			get {return GameLink.CardTakeType.Skill;}
		}
	}
}
