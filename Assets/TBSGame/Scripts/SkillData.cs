using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillData
{
	public string skillName;
	public List<Vector2> graphs;
	public List<Vector3> pos;
	public List<Vector3> effects;
	
	public SkillData()
	{
		
	}
	
	public SkillData(string skillName, List<Vector2> graphs, List<Vector3> pos, List<Vector3> effects)
	{
		this.skillName = skillName;
		this.graphs = graphs;
		this.pos = pos;
		this.effects = effects;
	}
	public string toString()
	{
		return string.Format("{0} + {1} + {2} + {3}", this.skillName, this.graphs.Count.ToString(), this.pos.Count.ToString(), this.effects.Count.ToString());
	}
}
