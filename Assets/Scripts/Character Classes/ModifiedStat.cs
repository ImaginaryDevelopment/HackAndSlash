using System.Collections.Generic;
using System.Linq;

public class ModifiedStat : BaseStat {
	int _modValue; //amount added to base after mods
		IList<ModifyingAttribute> _mods = new List<ModifyingAttribute>(); // which attributes modify this stat
	
	public ModifiedStat(){
		_modValue=0;
	}
	
	public void AddModifier(ModifyingAttribute mod){
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
			UnityEngine.Debug.Log(_mods[cnt].attribute.Name);
		}
		return temp;
	}
}
public struct ModifyingAttribute{
		public Attribute attribute;
		public float ratio;
		
	}