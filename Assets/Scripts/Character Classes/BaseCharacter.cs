using UnityEngine;
using System.Collections;
using System; // Enum

public class BaseCharacter : MonoBehaviour {
	public string Name{get; set;}
	public int Level{get; set;}
	public uint FreeExp{get; private set;}
	
	Attribute[] _primaryAttribute;
	Vital[] _vital;
	Skill[] _skill;
	
	public void Awake(){
		
		Name = string.Empty;
		_primaryAttribute= new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		_vital= new Vital[Enum.GetValues(typeof(VitalName)).Length];
		_skill= new Skill[Enum.GetValues(typeof(SkillName)).Length];
		
		SetupPrimaryAttributes();
		SetupVitals();
		SetupSkills ();
	}
	
	public void StatUpdate(){
		foreach(var v in _vital)
			v.Update();
		foreach(var s in _skill)
			s.Update();
	}
	
	public void AddExp(uint exp){
		FreeExp += exp;
		CalculateLevel();
	}
	
	//take avg of player's skills and assign as the player level
	public void CalculateLevel(){}
	
	public Attribute GetPrimaryAttribute(AttributeName name)
	{
		return _primaryAttribute[(int)name];
	}
	public Attribute GetPrimaryAttribute(int index)
	{
		return _primaryAttribute[index];
	}
	
	public Vital GetVital(int index)
	{
		return _vital[index];
	}
	
	public Skill GetSkill(int index)
	{
		return _skill[index];
	}
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}
	
	void SetupStat<T>(T[] array,Func<int,string> nameMap) 
		where T:BaseStat,new()
	{
		for(int cnt = 0; cnt< array.Length; cnt++){
			{
				array[cnt] = new T();	
				array[cnt].Name=nameMap(cnt);
			}
		}
	}
	void SetupPrimaryAttributes(){
		SetupStat(_primaryAttribute,i=>((AttributeName)i).ToString());
		
	}
	
	void SetupVitals(){
		
		SetupStat(_vital,(i) => ((VitalName)i).ToString());
		SetupVitalModifiers();
	}
	
	void SetupSkills(){
		SetupStat(_skill,i => ((SkillName)i).ToString());
		SetupSkillModifiers();
	}
	void AddModifier<T>(T item,Func<T,ModifiedStat> getter, float ratio,params AttributeName[] attributes) 
		where T:struct
	{
		var stat=getter(item);
		foreach(var attrib in attributes)
		{
			stat.AddModifier(new ModifyingAttribute{ attribute=GetPrimaryAttribute((int)attrib), ratio=ratio});
		}
	}
	void AddVitalModifier(VitalName vital, float ratio ,params AttributeName[] attributes)
	{
		AddModifier(vital,v=> GetVital((int)v),.33f, attributes);
	}
	void AddSkillModifier(SkillName skill,  float ratio,params AttributeName[] attributes)
	{
		AddModifier(skill, s=> GetSkill((int)s),.33f,attributes);
	}
	
	void SetupVitalModifiers(){
		//health
		
		AddVitalModifier(VitalName.Health,  .5f,AttributeName.Constitution);
		
		//energy, AttributeName.Constitution
		AddVitalModifier(VitalName.Energy,  1f, AttributeName.Constitution);
		
		//mana
		AddVitalModifier(VitalName.Mana, 1f, AttributeName.Willpower);
	}
	
	void SetupSkillModifiers(){
		
		AddSkillModifier(SkillName.Melee_Offense, .33f, AttributeName.Might, AttributeName.Nimbleness);
		
		AddSkillModifier(SkillName.Melee_Defense, .33f, AttributeName.Speed , AttributeName.Constitution);
		
		AddSkillModifier(SkillName.Magic_Offense,.33f, AttributeName.Concentration, AttributeName.Willpower);
		
		AddSkillModifier(SkillName.Magic_Defense, .33f, AttributeName.Concentration, AttributeName.Willpower);
		
		AddSkillModifier(SkillName.Ranged_Offense, .33f, AttributeName.Concentration, AttributeName.Speed);
		
		AddSkillModifier(SkillName.Ranged_Defense, .33f, AttributeName.Speed, AttributeName.Nimbleness);
	}
	
}
