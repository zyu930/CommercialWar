using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TBSGame.Cards
{
	[CreateAssetMenu(menuName = ("TBSGame/Cards/Graph Card"))]
	public class GraphCard : Card, IModifyDurable
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
	    public enum ExtraType
	    {
	    	None,
	    	AddNode
	    }
        [Title("标准属性")]
	    public string SkillName;
	    public string SkillPrefix;
        public EffectType effectType = EffectType.LoseDurable;
	    public FlagType flagType = FlagType.Enemy;
	    public ExtraType extraType = ExtraType.None;

        [DetailedInfoBox("影响值...", "对施法者的影响数值。")]
        public float affectValue = 0f;
        [DetailedInfoBox("效果值...", "对承受者的影响数值。")]
	    public float effectValue = 0f;
	    
	    [Title("动态属性")]
	    [EnableIf("extraType", ExtraType.AddNode)]
	    public int addNodeCount = 0;

	    public float GetAffectValue()
	    {
		    return affectValue;
	    }
	    public float GetEffectValue()
	    {
		    return effectValue;
	    }
	    public float GetAddNodeCount()
	    {
	    	return addNodeCount;
	    }
	}
}
