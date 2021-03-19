using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TbsFramework.Grid;

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
		Graph
	}
	
	public enum CellType
	{
		None,
		Node,
		DBNode,
		CBCore
	}
	
	public enum TwiceType
	{
		None,
		NodePlacement,
		SkillTrigger,
		GraphTrigger
	}
	
	public enum AIBehaviorType
	{
		Attack,
		Placement,
		Graph
	}
	
	public CellGrid cg;
	
    // Start is called before the first frame update
    void Start()
    {
	    cg = GameObject.FindObjectOfType<CellGrid>();
	    
	    cg.LevelLoadingDone += OnLevelLoadingDone;
    }
    
	void OnLevelLoadingDone(object sender, EventArgs e)
	{
		Bolt.CustomEvent.Trigger(Bolt.Variables.ActiveScene.Get("GameState") as GameObject, "OnLevelLoadingDone");
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
