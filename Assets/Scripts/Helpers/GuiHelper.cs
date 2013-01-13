using UnityEngine;
using System.Collections;
using System;
public static class GuiHelper {

	public static IDisposable ContentColor(Color color)
	{
		return Disposable.RestoreValueDisposable(GUI.contentColor,v=> GUI.contentColor=v, color);
	}
	public static IDisposable Color(Color color)
	{
		return Disposable.RestoreValueDisposable(GUI.color,v=> GUI.color=v, color);
	}
	public static IDisposable ColorIf(Color color,bool condition)
	{
		return Disposable.RestoreValueIfDisposable(GUI.color,v=> GUI.color=v, color,condition);
	}
	public static IDisposable ContentColorIf(Color color,bool condition)
	{
		return Disposable.RestoreValueIfDisposable(GUI.contentColor,v=> GUI.contentColor=v, color,condition);
	}
	
	public static IDisposable Disabled(bool condition)
	{
		return Disposable.RestoreValueDisposable(GUI.enabled,v=> GUI.enabled=v, false);
	}
}
