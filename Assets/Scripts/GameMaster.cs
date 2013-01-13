using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	public GameObject playerCharacter;
	public Camera mainCamera;
	public GameObject gameSettings;
	public float zOffset;
	public float yOffset;
	public float xRotOffset;
	
	GameObject _pc;
	PlayerCharacter _pcScript;
	// Use this for initialization
	void Start () {
		_pc=(GameObject) Instantiate(playerCharacter,Vector3.zero,Quaternion.identity);
		_pcScript= _pc.GetComponent<PlayerCharacter>();
		//Instantiate(playerCharacter,Vector3.zero,Quaternion.identity);
		zOffset= -2.5f;
		yOffset= 2.5f;
		xRotOffset= 22.5f;
		mainCamera.transform.position = new Vector3(_pc.transform.position.x+ xRotOffset,_pc.transform.position.y+ yOffset,_pc.transform.position.z+zOffset);
		mainCamera.transform.Rotate(xRotOffset,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void LoadCharacter(){
		var gs = GameObject.Find("__GameSettings");
		if(gs == null)
		{
			Instantiate(gameSettings,Vector3.zero,Quaternion.identity);
			gs.name="gameSettings";
		}
			
		var gsScript = GameObject.Find("__GameSettings").GetComponent<GameSettings>();
			
		gsScript.LoadCharacterData();
		Application.LoadLevel("initial");	
	}
}
