using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TbsFramework.Grid;
using TBSGame;

public class GameLink : MonoBehaviour
{
	public enum TurnType
	{
		Human,
		AI
	}
	
	public enum CardTakeType
	{
		None,
		Node,
		CBCore,
		Skill,
		Graph,
		Combo
	}
	
	public enum CellType
	{
		None,
		Node,
		DBNode,
		CBCore,
		Resource
	}
	
	public enum TwiceType
	{
		None,
		NodePlacement,
		SkillTrigger,
		GraphTrigger,
		NodeSelfSkillFirst,
		NodeSelfSkillLast
	}
	
	public enum AIBehaviorType
	{
		Attack,
		Placement,
		Graph
	}
	
	public enum AffectOrEffect
	{
		Affect,
		Effect
	}
	//无卡技能
	public enum NoneCardSkill
	{
		SelfExplosion, //自爆技能
		Checkers //跳棋技能
	}
	public enum UnitType
	{
		None, //无单位
		Solider //兵棋
	}
	
	public enum ClickMode
	{
		NodeMode, //节点模式
		UnitMode, //单位模式
		NodeMove // 节点移动模式
	}
	
	public enum TipsType
	{
		None,
		Checkers // 跳棋
	}
	public enum TurnMode
	{
		Move,
		Attack
	}
	
	public TBSGame.CellGrid cg;
	
	private bool isInit;
	
    // Start is called before the first frame update
    void Start()
    {
	    cg = GameObject.FindObjectOfType<TBSGame.CellGrid>();
    }
	void Update()
	{
		if(!isInit)
		{
			if(cg.isLoaded)
			{
				Bolt.CustomEvent.Trigger(Bolt.Variables.ActiveScene.Get("GameState") as GameObject, "OnLevelLoadingDone");
				isInit = true;
			}
		}
	}
}
