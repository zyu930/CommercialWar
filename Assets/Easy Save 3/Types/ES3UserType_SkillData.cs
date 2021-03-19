using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("skillName", "graphs", "pos", "effects")]
	public class ES3UserType_SkillData : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_SkillData() : base(typeof(SkillData)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (SkillData)obj;
			
			writer.WriteProperty("skillName", instance.skillName, ES3Type_string.Instance);
			writer.WriteProperty("graphs", instance.graphs);
			writer.WriteProperty("pos", instance.pos);
			writer.WriteProperty("effects", instance.effects);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (SkillData)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "skillName":
						instance.skillName = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "graphs":
						instance.graphs = reader.Read<System.Collections.Generic.List<UnityEngine.Vector2>>();
						break;
					case "pos":
						instance.pos = reader.Read<System.Collections.Generic.List<UnityEngine.Vector3>>();
						break;
					case "effects":
						instance.effects = reader.Read<System.Collections.Generic.List<UnityEngine.Vector3>>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new SkillData();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_SkillDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SkillDataArray() : base(typeof(SkillData[]), ES3UserType_SkillData.Instance)
		{
			Instance = this;
		}
	}
}