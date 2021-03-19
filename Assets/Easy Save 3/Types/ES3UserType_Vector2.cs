using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("x", "y")]
	public class ES3UserType_Vector2 : ES3Type
	{
		public static ES3Type Instance = null;

		public ES3UserType_Vector2() : base(typeof(UnityEngine.Vector2)){ Instance = this; priority = 1;}


		public override void Write(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.Vector2)obj;
			
			writer.WriteProperty("x", instance.x, ES3Type_float.Instance);
			writer.WriteProperty("y", instance.y, ES3Type_float.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			var instance = new UnityEngine.Vector2();
			string propertyName;
			while((propertyName = reader.ReadPropertyName()) != null)
			{
				switch(propertyName)
				{
					
					case "x":
						instance.x = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "y":
						instance.y = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
			return instance;
		}
	}


	public class ES3UserType_Vector2Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_Vector2Array() : base(typeof(UnityEngine.Vector2[]), ES3UserType_Vector2.Instance)
		{
			Instance = this;
		}
	}
}