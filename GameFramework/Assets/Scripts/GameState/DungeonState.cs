using UnityEngine;
using System.Collections;

public class DungeonState : GameState {

	protected override void OnStart()
	{
		
	}
	protected override void OnStop()
	{
		GUIManager.HideView ("DungeonPanel");
	}
	protected override void OnLoadComplete()
	{
		GUIManager.ShowView ("DungeonPanel");
	}
}
