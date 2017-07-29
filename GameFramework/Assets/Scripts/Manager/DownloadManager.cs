using UnityEngine;
using System.Collections;
using System;

public class DownloadManager : MonoBehaviour {

	private static DownloadManager _instance;
	public static DownloadManager Instance
	{
		get{
			if (_instance == null) {
				_instance = FindObjectOfType (typeof(DownloadManager)) as DownloadManager;
			}
			return _instance;
		}
	}
	public delegate void LoadCallback(params object[] args);
	public void LoadSceneBundle(string name, LoadCallback LoadHandler, params object[] args)
	{// 异步
		StartCoroutine(LoadSceneBundleAsync(name, LoadHandler, args));
	}
	private IEnumerator LoadSceneBundleAsync(string name, LoadCallback LoadHandler, params object[] args)
	{
		AsyncOperation async = Application.LoadLevelAsync (name);
		yield return async;

		Resources.UnloadUnusedAssets ();
		GC.Collect ();

		if (LoadHandler != null) {
			LoadHandler (args);
		}
	}
}
