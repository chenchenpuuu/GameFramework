using UnityEngine;
using System.Collections;

public class ResourcesManager : MonoBehaviour {

	private static ResourcesManager _instance;
	public static ResourcesManager Instance
	{
		get{ 
			if (_instance == null) {
				_instance = new ResourcesManager ();
			}
			return _instance;
		}
	}
	private string UIPanelPath = "UI/Panel"; //TODO 移至COMMON_DEF
	public GameObject GetUIPrefeb(string name)
	{
		GameObject prefeb = LoadPrefeb (name, UIPanelPath);
		return prefeb;
	}
	public GameObject LoadPrefeb(string name, string path)
	{
		string loadPath = path + "/" + name;
		GameObject prefeb = Resources.Load (loadPath, typeof(GameObject)) as GameObject;
		if (prefeb == null) {
			Debug.LogError ("cannot find this prefeb, loadPath:" + loadPath);
		}
		return prefeb;
	}
}
