using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TBSGame;

public class BoltLink
{
	// EasySave 专用
	
	static string databse_file_name = "database";
	
	public static void ES3_Save_Vec3(string n, Vector3 v)
	{
		ES3.Save<Vector3>(n, v);
	}
	public static void ES_Save_SkillData(string n, SkillData v)
	{
		ES3.Save<SkillData>(n, v);
	}
	public static DataBase ES3_Load_DBs()
	{
		if(!ES3.KeyExists(databse_file_name))
			ES3.Save<DataBase>(databse_file_name, new DataBase());
			
		return ES3.Load<DataBase>(databse_file_name);
	}
	public static Vector3 ES3_Load_Vec3(string n)
	{
		return ES3.Load<Vector3>(n);
	}
	public static void ES3_Save_Array(string n, Vector2[] arr)
	{
		ES3.Save(n, arr);
	}
}
