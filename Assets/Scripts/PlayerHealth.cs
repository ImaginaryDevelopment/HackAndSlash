using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth =100;
	public int currentHealth =100;
	bool playerHit=false; //draw when you get hit 
	float hitTimer=0.0f;
	float hitCooldown=0.2f;
	public float healthBarLength;
	
	// Use this for initialization
	void Start () {
		healthBarLength=Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		AdjustCurrentHealth(0);
		if(hitTimer > 0)
			hitTimer -= Time.deltaTime;
		if(hitTimer < 0)
			hitTimer = 0;
		
		if(hitTimer == 0)
		{
			playerHit=false;	
		}
	}
	//http://www.burgzergarcade.com/tutorials/game-engines/unity3d/001-unity3d-tutorial-health-bar-12
	void OnGUI(){
		GUI.Box(new Rect(10,10,healthBarLength,20),currentHealth + "/"+maxHealth);
		if(playerHit)
		{
			GUI.Box(new Rect(10,Screen.height /2 - 10,Screen.width-10,Screen.height / 2+10),"X");	
		}
	}
	
	public void AdjustCurrentHealth(int adj){
		currentHealth+=adj;
		if(currentHealth < 0)
			currentHealth=0;
		if(currentHealth>maxHealth)
			currentHealth=maxHealth;
		if(maxHealth <1)
			maxHealth=1;
		healthBarLength = (Screen.width /2)* (currentHealth / (float)maxHealth);
		if(adj < 0)
		{
			playerHit=true;
			hitTimer=hitCooldown;
		}
	}
}
