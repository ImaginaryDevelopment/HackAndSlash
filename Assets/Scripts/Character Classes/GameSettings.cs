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
	
	void SaveCharacterData(){
		var pc= GameObject.Find("pc");
		var pcClass = pc.GetComponent<PlayerCharacter>();
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetString("Player Name",pcClass.Name);
		
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			PlayerPrefs.SetInt(((AttributeName)cnt).ToString() + "BaseValue",pcClass.GetPrimaryAttribute(cnt).BaseValue);	
			PlayerPrefs.SetInt(((AttributeName)cnt).ToString()+"ExpToLevel",pcClass.GetPrimaryAttribute(cnt).ExpToLevel);
		}
	}
	
	void LoadCharacterData(){
		var pc = GameObject.Find("pc");
		var pcClass = pc.GetComponent<PlayerCharacter>();
		pcClass.Name= PlayerPrefs.GetString("Player Name");
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			pcClass.GetPrimaryAttribute(cnt).BaseValue=PlayerPrefs.GetInt(((AttributeName)cnt).ToString() + "BaseValue");	
			pcClass.GetPrimaryAttribute(cnt).ExpToLevel=PlayerPrefs.GetInt(((AttributeName)cnt).ToString()+"ExpToLevel");
		}
	}
}
