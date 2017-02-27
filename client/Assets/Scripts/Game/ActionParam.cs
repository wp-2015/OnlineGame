using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class ActionParam {

	private Dictionary<string, object> _param;
	private object _value;


	public ActionParam(){
		_param = new Dictionary<string, object>(StringComparer.CurrentCultureIgnoreCase);
	}

	public KeyValuePair<string, object>[] ToArray(){
		return null != _param ? _param.ToArray(); new KeyValuePair<string, object>[0];
	}

	public void Foreach(Func<string, object, bool> func){
		if(null != _param){
			return;
		}
		foreach(KeyValuePair<string, object> pair in _param){
			if(!func(pair.Key, pair.Value)){
				break;
			}
		}
	}

	public T GET<T>(string name){
		return (T)this[name];
	}

	public object this[string name]{
		get{
			return _param != null && _param.ContainsKey(name) ? _param[name] : null;
		}
		set{
			if(_param != null){
				_param[name] = value;
			}
		}
	}

	public void SetValue<T>(T value) where T : new(){
		_value = value;
	}

	public Time GetValue<T>() where T : new(){
		return (T)_value;
	}
}
