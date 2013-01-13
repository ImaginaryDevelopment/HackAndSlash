using System;
public class Disposable:IDisposable {
	bool isDisposed;
	Action _onDispose;
	public Disposable(Action onDispose)
	{
		_onDispose=onDispose;
	}
	
	public void Dispose(){
		if(isDisposed)
			return;
		isDisposed=true;
		_onDispose();
	}
	
	public static Disposable RestoreValueDisposable<T>(T current, Action<T> setter,T temporaryValue)
	{
		setter(temporaryValue);
		return new Disposable(()=> setter(current));
	}
	
	public static Disposable RestoreValueIfDisposable<T>(T current, Action<T> setter,T temporaryValue,bool condition)
	{
		if(condition)
			setter(temporaryValue);
		return new Disposable(()=> setter(current));
	}
}

