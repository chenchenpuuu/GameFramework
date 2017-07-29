using UnityEngine;
using System.Collections;

public class BattleState : GameState {

	protected override void OnStart()
	{
		
	}
	protected override void OnStop()
	{
		GUIManager.HideView ("BattlePanel");
	}
	protected override void OnLoadComplete()
	{
		GUIManager.ShowView ("BattlePanel");
	}
}
