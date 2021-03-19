using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_ArrayList : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ArrayList() : base(typeof(System.Collections.ArrayList)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (System.Collections.ArrayList)obj;
			
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (System.Collections.ArrayList)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new System.Collections.ArrayList();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_ArrayListArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ArrayListArray() : base(typeof(System.Collections.ArrayList[]), ES3UserType_ArrayList.Instance)
		{
			Instance = this;
		}
	}
}