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
		var pc= GameObject.Find("pc");
		var pcClass = pc.GetComponent<PlayerCharacter>();
		PlayerPrefs.SetString("Player Name",pcClass.Name);
	}
	
	void LoadCharacterData(){
		
	}
}
