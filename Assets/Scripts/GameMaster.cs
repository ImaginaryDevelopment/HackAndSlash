using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	public GameObject playerCharacter;
	public Camera mainCamera;
	
	public float zOffset;
	public float yOffset;
	
	
	GameObject _pc;
	// Use this for initialization
	void Start () {
		_pc=(GameObject) Instantiate(playerCharacter,Vector3.zero,Quaternion.identity);
		//Instantiate(playerCharacter,Vector3.zero,Quaternion.identity);
		mainCamera.transform.position = _pc.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
