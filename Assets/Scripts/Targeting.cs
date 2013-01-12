using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Targeting : MonoBehaviour {
	
	public List<Transform> targets = new List<Transform>();
	public Transform _currentTarget;
	Color _previousColor;
	Transform myTransform;
	// Use this for initialization
	void Start () {
		myTransform=transform;
		AddAllEnemies();
		SortTargetsByDistance();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Tab))
		{
			TargetEnemy();
		}
		
	}
	void OnGUI()
	{
		if(_currentTarget!= null)
		{
			GUI.Label(new Rect(10,60,10,20), _currentTarget.name);
			
		}
	}
	public void AddAllEnemies(){
		var gameObjects= GameObject.FindGameObjectsWithTag("Enemy");
		foreach(var e in gameObjects)
		{
			if( targets.Contains(e.transform) == false)
				targets.Add(e.transform);
		}
			
	}
	void SortTargetsByDistance()
	{
		targets.Sort((t1, t2) => {
			return Vector3.Distance(t1.position,myTransform.position).CompareTo(Vector3.Distance(t2.position,myTransform.position));
		});
	}
	public void AddTarget(Transform enemy)
	{
		if(targets.Contains(enemy.transform) == false)
			targets.Add(enemy);
	}
	
	void SelectTarget(){
		_previousColor=_currentTarget.renderer.material.color;
		_currentTarget.renderer.material.color = Color.red;
		var pa = (PlayerAttack) GetComponent("PlayerAttack");
		pa.target=_currentTarget.gameObject;
	}
	
	void TargetEnemy(){
		if(targets.Any()==false)
		{
			_currentTarget=null;
			AddAllEnemies();
			return;
		}
		SortTargetsByDistance();
		if(_currentTarget == null)
		{
			_currentTarget = targets[0];
		} else
		{
			_currentTarget.renderer.material.color=_previousColor;
			var targetIndex=targets.IndexOf(_currentTarget);
			if(targetIndex < targets.Count -1)
			{
				targetIndex++;
			} else 
			{
				targetIndex=0;
			}
			_currentTarget=targets[targetIndex];
		}
		SelectTarget();
		
		
		
	}
	
}
