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
			AddRange,
			LoseDurable,
            Explosion
        }
		
		public enum FlagType
		{
			Enemy,
			Friend
		}

        [Title("标准属性")]

        public EffectType effectType = EffectType.AddRange;
		public FlagType flagType = FlagType.Enemy;
		
		public int Value = 0;

        [Title("动态属性")]
        [EnableIf("effectType", EffectType.AddRange)]
        public int ContinuedRound = 0;
        [DetailedInfoBox("推技能距离...", "发动后，目标格子周围六个方向上的第一格如果另一侧没有节点或争夺目标，则后退一格，否则原地不动。")]
        [EnableIf("effectType", EffectType.Explosion)]
        public int PushRange = 0;

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
	}
}
