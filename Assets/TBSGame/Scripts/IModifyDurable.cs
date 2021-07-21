using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TBSGame
{
	public interface IModifyDurable
	{
		float GetAffectValue();//对施法者的耐久值更新
		float GetEffectValue();//对承受者的耐久值更新
	}
}

