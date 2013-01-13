using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	public GameObject playerCharacter;
	public Camera mainCamera;
	public GameObject gameSettings;
	public float zOffset;
	public float yOffset;
	public float xRotOffset;
	Vector3 _playerSpawnPointPos;
	
	GameObject _pc;
	PlayerCharacter _pcScript;
	// Use this for initialization
	void Start () {
		_playerSpawnPointPos= new Vector3(240,6,116);
		var go = (GameObject) GameObject.Find(GameSettings.PLAYER_SPAWN_POINT);
		if(go == null)
		{
			Debug.LogWarning("No spawn point found");
			go =new GameObject(GameSettings.PLAYER_SPAWN_POINT);
			
			Debug.Log("Created Player spawn point found");
			go.transform.position=_playerSpawnPointPos;
		}
		_pc=(GameObject) Instantiate(playerCharacter,go.transform.position,Quaternion.identity);
		_pc.name="pc";
		_pcScript= _pc.GetComponent<PlayerCharacter>();
		//Instantiate(playerCharacter,Vector3.zero,Quaternion.identity);
		zOffset= -2.5f;
		yOffset= 2.5f;
		xRotOffset= 22.5f;
		mainCamera.transform.position = new Vector3(_pc.transform.position.x+ xRotOffset,_pc.transform.position.y+ yOffset,_pc.transform.position.z+zOffset);
		mainCamera.transform.Rotate(xRotOffset,0,0);
		
		LoadCharacter();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void LoadCharacter(){
		var gs = GameObject.Find("__GameSettings");
		if(gs == null)
		{
			gs=(GameObject) Instantiate(gameSettings,Vector3.zero,Quaternion.identity);
			gs.name="__GameSettings";
		}
			
		var gsScript = GameObject.Find("__GameSettings").GetComponent<GameSettings>();
			
		gsScript.LoadCharacterData();
		Application.LoadLevel("Level1");	
	}
}
