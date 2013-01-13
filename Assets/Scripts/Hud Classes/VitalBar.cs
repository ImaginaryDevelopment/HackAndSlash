using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {
	bool _isPlayerHealthBar;
	// Use this for initialization
	void Start () {
		_isPlayerHealthBar=true;
		OnEnable();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnEnable(){
		
	}
	
	public void OnDisable(){
		
	}
	
	public void ChangeHealthBarSize(int curHealth, int maxHealth){
		
	}
	
	public void SetPlayerHealthBar(bool b){
		_isPlayerHealthBar=b;
	}
}
