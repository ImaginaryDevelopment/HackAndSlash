using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject target;
	public float attackTimer;
	public float coolDown;
	
	// Use this for initialization
	void Start () {
		attackTimer = 0;
		coolDown = 2.0f; //2 seconds
	}
	
	// Update is called once per frame
	void Update () {
		if(attackTimer > 0)
			attackTimer -= Time.deltaTime;
		if(attackTimer < 0)
			attackTimer = 0;
		
		if(attackTimer == 0 && Input.GetKeyUp(KeyCode.F))
		{
			Attack();
		}
	}
	//http://www.burgzergarcade.com/tutorials/game-engines/unity3d/005-unity3d-tutorial-melee-combat-13
	void Attack(){
		var distance = Vector3.Distance(target.transform.position,transform.position); 
		Debug.Log(distance);
		Vector3 dir = (target.transform.position - transform.position).normalized;
		float direction = Vector3.Dot(dir, transform.forward); //each unit should be 1 unit long
		
		Debug.Log(direction); //should be between 1 and -1; 0 on side
		if(distance < 2.5f && direction > 0){
			var eh = (EnemyHealth) target.GetComponent("EnemyHealth");	
			eh.AdjustCurrentHealth(-10);
			attackTimer=coolDown;
		}
	}
}
