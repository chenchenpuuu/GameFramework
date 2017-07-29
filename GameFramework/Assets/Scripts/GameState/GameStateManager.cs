using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class GameStateManager : MonoBehaviour {
	private static Dictionary<string, GameState> m_GameStateMap = null;
	private static GameState m_CurState = null;

	// Use this for initialization
	void Start () {
		m_GameStateMap = new Dictionary<string, GameState> ();
		m_CurState = null;
	}

	public static void SetState(GameState state)
	{
		if (state == null) {
			Debug.LogError ("The State you set is null");
			return;
		}
		if (state != m_CurState && m_CurState != null) {
			m_CurState.Stop ();
		}
		m_CurState = state;
		m_CurState.Start ();
	}

	public static void LoadScene(int sceneID)
	{
		SceneData data = null;
		if (data == null) {
			Debug.LogError ("Init SceneData is null, SceneID:" + sceneID);
			return;
		}
		GameState state = null;
		if (!m_GameStateMap.TryGetValue (data.GameState, out state)) {
			state = Assembly.GetExecutingAssembly ().CreateInstance (data.GameState) as GameState;
			if (state == null) {
				Debug.LogError ("Init state error, gameState:" + data.GameState);
				return;
			}
			m_GameStateMap.Add (data.GameState, state);
		}
		SetState (state);

		//状态设置完毕，开始load场景
		DownloadManager.Instance.LoadSceneBundle(data.LevelName, state.LoadComplete);
	}
}