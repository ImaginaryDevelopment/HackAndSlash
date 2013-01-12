using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxDistance;
	public bool moveEnabled = true;
	Transform myTransform;
	
	//almost like a constructor
	void Awake(){
		myTransform = transform;	
	}
	// Use this for initialization
	void Start () {
		var go = GameObject.FindGameObjectWithTag("Player");
		target=go.transform;
		maxDistance=2;
	}
	
	// Update is called once per frame
	void Update () {
		var eh = (EnemyHealth) myTransform.GetComponent("EnemyHealth");
		if(eh.currentHealth <1 )
		{
			return;
		}
		//http://www.burgzergarcade.com/tutorials/game-engines/unity3d/003-unity3d-tutorial-enemy-ai-12
		Debug.DrawLine(target.position,myTransform.position,Color.yellow);
		
		//look at player
		myTransform.rotation=Quaternion.Slerp(myTransform.rotation,
			Quaternion.LookRotation(target.position-myTransform.position),
			rotationSpeed * Time.deltaTime);
		//http://www.burgzergarcade.com/tutorials/game-engines/unity3d/007-unity3d-tutorial-melee-combat-33
		if(!moveEnabled || Vector3.Distance(target.position,transform.position)< maxDistance)
		{
			return;
		}
		//http://www.burgzergarcade.com/tutorials/game-engines/unity3d/004-unity3d-tutorial-enemy-ai-22
		//move towards target
		myTransform.position += myTransform.forward* moveSpeed * Time.deltaTime;
	}
}
