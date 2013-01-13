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
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			SaveBaseStat(cnt,i=> (AttributeName)i,i=> pcClass.GetPrimaryAttribute(i));
		}
		//SaveAttributes(i=> (VitalName) i, i=> pcClass.GetVital(i));
		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			SaveBaseStat(cnt,i=> (VitalName)i, i=> pcClass.GetVital(i));
			var vital=pcClass.GetVital(cnt);
			var name=((VitalName)cnt).ToString();
			PlayerPrefs.SetInt(name.ToString()+"CurValue",vital.CurValue);
			PlayerPrefs.SetString(name+ "Modifiers", vital.GetModifyingAttributesToSerialize());
			
			
		}
		for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++) {
			SaveBaseStat(cnt,i=> (SkillName)i,i=> pcClass.GetSkill(i));
			var skill=pcClass.GetSkill(cnt);
			var name=((SkillName)cnt).ToString();
			PlayerPrefs.SetString(name+ "Modifiers", skill.GetModifyingAttributesToSerialize());
			
			
		}
	}
	
	void SaveBaseStat<T>(int cnt,Func<int,T> tCast, Func<int,BaseStat> getter) where T:struct{
		if(!typeof(T).IsEnum)
			throw new InvalidOperationException();
			PlayerPrefs.SetInt((tCast(cnt)).ToString()+"BaseValue",getter(cnt).BaseValue);
			PlayerPrefs.SetInt((tCast(cnt)).ToString()+"ExpToLevel",getter(cnt).ExpToLevel);
			PlayerPrefs.SetFloat((tCast(cnt)).ToString()+"LevelModifier",getter(cnt).LevelModifier);
	}
	void LoadBaseStat(int cnt,string name,BaseStat stat){
		
		stat.BaseValue=PlayerPrefs.GetInt(name+"BaseValue",0);
		stat.ExpToLevel=PlayerPrefs.GetInt(name+"ExpToLevel",0);
		stat.LevelModifier=PlayerPrefs.GetFloat(name+"LevelModifier",0.0f);
	}
	
	internal void LoadCharacterData(){
		var pc = GameObject.Find("pc");
		var pcClass = pc.GetComponent<PlayerCharacter>();
		
		pcClass.Name= PlayerPrefs.GetString("Player Name","Name Me");
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			var name=((AttributeName)cnt).ToString();
			var attrib=pcClass.GetPrimaryAttribute(cnt);
			LoadBaseStat(cnt,name,attrib);
			Debug.Log(pcClass.GetPrimaryAttribute(cnt).Name+":" +pcClass.GetPrimaryAttribute(cnt).BaseValue+ ":");
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			var name=((VitalName)cnt).ToString();
			var attrib=pcClass.GetVital(cnt);
			LoadBaseStat(cnt,name,attrib);
			attrib.CurValue=PlayerPrefs.GetInt(name+"CurValue",0);
		}
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++) {
			var name=((SkillName)cnt).ToString();
			var attrib=pcClass.GetSkill(cnt);
			LoadBaseStat(cnt,name,attrib);
			//pcClass.GetSkill(cnt).BaseValue=PlayerPrefs.GetInt(name+"BaseValue",0);
		}
		
		
	}
}
