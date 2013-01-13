using System.Collections.Generic;
using System.Linq;
using System;

public class ModifiedStat : BaseStat {
	int _modValue; //amount added to base after mods
		IList<ModifyingAttribute> _mods = new List<ModifyingAttribute>(); // which attributes modify this stat
	
	public ModifiedStat(){
		_modValue=0;
	}
	
	public void AddModifier(ModifyingAttribute mod){
		if(_mods.Any(m=>m.attribute.Name == mod.attribute.Name))
			throw new InvalidOperationException("duplicate mod added:"+mod.attribute.Name);
		_mods.Add(mod);
	}
	
	void CalculateModValue()
	{
		_modValue=0;
		if(_mods.Any()==false)
			return;
		foreach(var m in _mods)
		{
			_modValue+=(int)( m.attribute.AdjustedBaseValue*m.ratio);
		}
	}
	
	public new int AdjustedBaseValue{
		get { return BaseValue+BuffValue+_modValue;}
	}
	public void Update(){
		CalculateModValue();
	}
	
	public string GetModifyingAttributesToSerialize(){
		string temp=string.Empty;
		//foreach(var m in _mods)
		for (int cnt = 0; cnt < _mods.Count; cnt++) {
			var attrib=_mods[cnt].attribute;
			temp+= _mods[cnt].attribute.Name;
			temp+= "_"+ _mods[cnt].ratio;
			
			if(cnt<_mods.Count -1)
				temp+="|";
			
			
		}
		UnityEngine.Debug.Log(this.Name+":"+ temp);
		return temp;
	}
}
public struct ModifyingAttribute{
		public Attribute attribute;
		public float ratio;
		
	}