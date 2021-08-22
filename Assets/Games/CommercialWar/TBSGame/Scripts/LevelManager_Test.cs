using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TBSGame;

public class LevelManager_Test : MonoBehaviour
{
	public void OnGameLevelExit()
	{
		Debug.Log("商战退出");
	}
	public void LoadGameLeve()
	{
		LevelManager.Instance.LoadGameLevel("Level 1");
	}
}
