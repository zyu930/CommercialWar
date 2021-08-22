using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TBSGame
{
	public class LevelManager : MonoBehaviour
	{
		public static LevelManager Instance
		{
			get; private set;
		}
		
		public UnityEvent OnGameExit;
		
		protected void Awake()
		{
			if(Instance != null)
			{
				Destroy(gameObject);
			}
			Instance = this;
			DontDestroyOnLoad(this);
		}
		public void HandlerOnGameExit()
		{
			OnGameExit.Invoke();
		}
		// 加载商战关卡（Level 1, Level 2 测试两关可选）
		public void LoadGameLevel(string levelName = "Level 1")
		{
			Bolt.CustomEvent.Trigger(gameObject, "LoadGame", levelName);
		}
	}
}
