using UnityEngine;
using System.Collections;

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
		//PlayerPrefs.SetString("Player Name",);
	}
	
	void LoadCharacterData(){
		
	}
}
