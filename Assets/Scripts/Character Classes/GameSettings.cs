using UnityEngine;
using System.Collections;
using System;

public class GameSettings : MonoBehaviour {
	
	void Awake(){
		//survive from game scene to game scene
		DontDestroyOnLoad(this);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	internal void SaveCharacterData(){
		var pc= GameObject.Find("pc");
		var pcClass = pc.GetComponent<PlayerCharacter>();
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetString("Player Name",pcClass.Name);
		SaveAttributes(i=> (AttributeName)i,i=> pcClass.GetPrimaryAttribute(i));
		SaveAttributes(i=> (VitalName) i, i=> pcClass.GetVital(i));
		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			PlayerPrefs.SetInt(((VitalName)cnt).ToString() + "BaseValue",pcClass.GetVital(cnt).BaseValue);	
			PlayerPrefs.SetInt(((VitalName)cnt).ToString()+"ExpToLevel",pcClass.GetVital(cnt).ExpToLevel);
			PlayerPrefs.SetInt(((VitalName)cnt).ToString()+"CurValue",pcClass.GetVital(cnt).CurValue);
			PlayerPrefs.SetFloat(((VitalName)cnt).ToString()+"LevelModifier",pcClass.GetVital(cnt).LevelModifier);
		}
	}
	
	void SaveAttributes<T>(Func<int,T> tCast, Func<int,BaseStat> getter) where T:struct{
		if(!typeof(T).IsEnum)
			throw new InvalidOperationException();
		for(int cnt = 0; cnt < Enum.GetValues(typeof(T)).Length; cnt++){
			PlayerPrefs.SetInt((tCast(cnt)).ToString()+"BaseValue",getter(cnt).BaseValue);
			PlayerPrefs.SetInt((tCast(cnt)).ToString()+"ExpToLevel",getter(cnt).ExpToLevel);
			PlayerPrefs.SetFloat((tCast(cnt)).ToString()+"LevelModifier",getter(cnt).LevelModifier);
		}
	}
	
	void LoadCharacterData(){
		var pc = GameObject.Find("pc");
		var pcClass = pc.GetComponent<PlayerCharacter>();
		pcClass.Name= PlayerPrefs.GetString("Player Name");
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			pcClass.GetPrimaryAttribute(cnt).BaseValue=PlayerPrefs.GetInt(((AttributeName)cnt).ToString() + "BaseValue");	
			pcClass.GetPrimaryAttribute(cnt).ExpToLevel=PlayerPrefs.GetInt(((AttributeName)cnt).ToString()+"ExpToLevel");
			pcClass.GetPrimaryAttribute(cnt).LevelModifier=PlayerPrefs.GetInt(((AttributeName)cnt).ToString()+"LevelModifier");
		}
	}
}
