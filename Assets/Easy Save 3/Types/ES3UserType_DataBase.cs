using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("sds")]
	public class ES3UserType_DataBase : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_DataBase() : base(typeof(DataBase)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (DataBase)obj;
			
			writer.WriteProperty("sds", instance.sds);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (DataBase)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "sds":
						instance.sds = reader.Read<System.Collections.Generic.List<SkillData>>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new DataBase();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_DataBaseArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_DataBaseArray() : base(typeof(DataBase[]), ES3UserType_DataBase.Instance)
		{
			Instance = this;
		}
	}
}