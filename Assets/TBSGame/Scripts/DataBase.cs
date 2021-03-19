using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataBase
{
	public List<SkillData> sds;
	
	public DataBase addOrUpdateSkillData(SkillData sd)
	{
		bool finded = false;
		if (sds == null) sds = new List<SkillData>();
		if (sds.Count > 0 && sd != null)
		{
			foreach(var item in sds)
			{
				if (item.skillName == sd.skillName)
				{
					item.graphs = sd.graphs;
					item.pos = sd.pos;
					item.effects = sd.effects;
					finded = true;
					break;
				}
			}
		}
		if(!finded)
		{
			sds.Add(sd);
		}
		return this;
	}
	public SkillData getSkillDataByName(string sname)
	{
		if (sds != null && sds.Count > 0 && sname != null)
		{
			foreach(var item in sds)
			{
				if (item.skillName == sname)
				{
					return item;
				}
			}
		}
		return null;
	}
	public SkillData getSkillDataByGraph(List<Vector2> items)
	{
		if (sds != null && sds.Count > 0 && items != null)
		{
			foreach(var item in sds)
			{
				if (item.graphs.Count == items.Count)
				{
					bool check = true;
					for (int i = 0, len = item.graphs.Count; i < len; i++)
					{
						if (item.graphs[i] != items[i])
						{
							check = false;
							break;
						}
					}
					if (check)
					{
						return item;
						break;
					}
				}
			}
		}
		return null;
	}
	public DataBase Save()
	{
		ES3.Save<DataBase>("database", this);
		return this;
	}
}
