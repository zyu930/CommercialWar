using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("x", "y", "z")]
	public class ES3UserType_Vector3 : ES3Type
	{
		public static ES3Type Instance = null;

		public ES3UserType_Vector3() : base(typeof(UnityEngine.Vector3)){ Instance = this; priority = 1;}


		public override void Write(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.Vector3)obj;
			
			writer.WriteProperty("x", instance.x, ES3Type_float.Instance);
			writer.WriteProperty("y", instance.y, ES3Type_float.Instance);
			writer.WriteProperty("z", instance.z, ES3Type_float.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			var instance = new UnityEngine.Vector3();
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
					case "z":
						instance.z = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
			return instance;
		}
	}


	public class ES3UserType_Vector3Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_Vector3Array() : base(typeof(UnityEngine.Vector3[]), ES3UserType_Vector3.Instance)
		{
			Instance = this;
		}
	}
}