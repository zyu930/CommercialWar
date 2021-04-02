using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TBSGame.Cards
{
	[CreateAssetMenu(menuName = ("TBSGame/Cards/Graph Card"))]
	public class GraphCard : Card
    {
        public enum EffectType
        {
            LoseDurable
        }
        public enum FlagType
        {
            Both,
            Enemy,
            Friend
        }
        [Title("标准属性")]
        public string SkillName;
        public EffectType effectType = EffectType.LoseDurable;
        public FlagType flagType = FlagType.Enemy;

        [DetailedInfoBox("影响值...", "对施法者的影响数值。")]
        public float affectValue = 0f;
        [DetailedInfoBox("效果值...", "对承受者的影响数值。")]
        public float effectValue = 0f;

	}
}
