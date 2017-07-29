using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class GUIManager { 

	private static Dictionary<string, KeyValuePair<GameObject, IView>> m_UIViewDic = new Dictionary<string, KeyValuePair<GameObject, IView>>();

	public static GameObject Instantiate(string PanelName)
	{
		GameObject prefeb = ResourcesManager.Instance.GetUIPrefeb (PanelName);
		if (prefeb == null) {
			Debug.LogError ("cannot find prefeb, PanelName:" + PanelName);
			return prefeb;
		}
		GameObject UIPrefeb = GameObject.Instantiate (prefeb) as GameObject;
		UIPrefeb.name = PanelName;

		Camera uiCamera = GameObject.FindWithTag ("UICameta").camera;
		if (uiCamera == null) {
			Debug.LogError ("UICamera is not found!");
			return null;
		}
		UIPrefeb.transform.parent = uiCamera.transform;
		UIPrefeb.transform.localScale = new Vector3 (1, 1, 1);
		UIPrefeb.transform.localPosition = new Vector3 (UIPrefeb.transform.localScale.x,
														UIPrefeb.transform.localScale.y,
														Mathf.Clamp (UIPrefeb.transform.localScale.x, -2f, 2f));  //预处理层级关系
		return UIPrefeb;
	}

	public static void ShowView(string name)
	{
		GameObject panel = null;
		IView view = null;
		KeyValuePair<GameObject, IView> found;
		if (!m_UIViewDic.TryGetValue (name, out found)) {
			view = Assembly.GetExecutingAssembly ().CreateInstance (name) as IView;
			if (view == null) {
				Debug.LogError ("[ShowView:" + name + "] not found");
			}
			panel = Instantiate(name);
			//TODO
		}
	}

	public static void HideView(string name)
	{
		
	}

	public static void DestroyAllView()
	{
		
	}
}
