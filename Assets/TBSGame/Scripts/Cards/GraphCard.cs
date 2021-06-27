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
	        LoseDurable, //伤害
	        SkillEffect //技能牌
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
	    public bool notSpendCardWhenDeal = false;
	    
	    [Title("动态属性")]
	    [EnableIf("effectType", EffectType.LoseDurable)]
	    public FlagType flagType = FlagType.Enemy;
	    [EnableIf("effectType", EffectType.LoseDurable)]
	    public ExtraType extraType = ExtraType.None;
		
	    [DetailedInfoBox("针对特殊的目标...", "")]
	    [EnableIf("effectType", EffectType.LoseDurable)]
	    public bool useSpecialSkillTarget = false;
	    [EnableIf("@this.useSpecialSkillTarget")]
	    public GameLink.CardTakeType skillTargetType = GameLink.CardTakeType.Node;
	    [EnableIf("@this.useSpecialSkillTarget && this.skillTargetType == GameLink.CardTakeType.Node")]
	    public NodeCard.NodeType skillNodeType = NodeCard.NodeType.Code;

	    [EnableIf("effectType", EffectType.LoseDurable)]
        [DetailedInfoBox("影响值...", "对施法者的影响数值。")]
	    public float affectValue = 0f;
	    [EnableIf("effectType", EffectType.LoseDurable)]
        [DetailedInfoBox("效果值...", "对承受者的影响数值。")]
	    public float effectValue = 0f;
	    
	    [EnableIf("effectType", EffectType.SkillEffect)]
	    public EffectCard[] effectCard;
	    
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
	    override public GameLink.CardTakeType CardType
	    {
		    get {return GameLink.CardTakeType.Graph;}
	    }
	}
}
