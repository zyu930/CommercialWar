using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TBSGame.Cards
{
	[CreateAssetMenu(menuName = ("TBSGame/Custom/SimpleHit"))]
	public class SimpleHit : ScriptableObject, IModifyDurable
	{
		[DetailedInfoBox("影响值...", "对施法者的影响数值。")]
		public float affectValue = 0f;
		[DetailedInfoBox("效果值...", "对承受者的影响数值。")]
		public float effectValue = 0f;
		
		public float GetAffectValue()
		{
			return affectValue;
		}
		public float GetEffectValue()
		{
			return effectValue;
		}
	}
}