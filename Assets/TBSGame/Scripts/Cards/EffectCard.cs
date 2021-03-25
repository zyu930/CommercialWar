using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TBSGame.Cards
{

    [CreateAssetMenu(menuName = ("TBSGame/Cards/Effect Card"))]
	public class EffectCard : Card, IContinued
	{
		public enum EffectType
		{
			AddRange,
			LoseDurable
		}
		
		public enum FlagType
		{
			Enemy,
			Friend
		}
		
		public EffectType effectType = EffectType.AddRange;
		public FlagType flagType = FlagType.Enemy;
		
		public int Value = 0;

        [EnableIf("effectType", EffectType.AddRange)]
        public int ContinuedRound = 0;
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
	}
}
