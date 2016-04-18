using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This is old and totally disabled, only here for reference in case some code here is needed later

/*
public class UuuuOptsOld : Hashtable  {

	public static UuuuOpts FromString( string stringGiven_ ){
		//// if pairs aren't given, the first part of the string will be added with a key of int zero
		///  thus, if a user only includes one thing, it will be at key int 0
		///  otherwise it's a comma seperated list of key/value pairs
		
		UuuuOpts opts_ = new UuuuOpts();
		int num_ = 0;
		if (stringGiven_ != null    &&    stringGiven_!=""){
			List<string> slist_ = new List<string>(  stringGiven_.Split(',')  );
			foreach( string s_ in slist_ ){
				string k_;
				string v_;
				string[] pair_ = s_.Split('=');
				if (pair_.Length > 1){
					k_=pair_[0];
					v_=pair_[1];
					opts_.Add( k_, v_ );
				}
				else {
					v_ = pair_[0];
					opts_.Add( num_, v_ );
					num_++;
				}
			}
		}
		opts_.Add( -1, num_ );
		return opts_;
	}

	public UuuuOpts(){
		
	}
	
	public
	UuuuOpts( IDictionary idict_ ){
		_init( idict_ );
	}


	
	protected void
	_init( IDictionary idict_ ){	
		foreach( DictionaryEntry de_ in idict_ ){
			Add( de_.Key, de_.Value );
		}
	}
	
	

	public UuuuOpts
	set(string key_, object val_)
	{
		this[key_] = val_;
		return this;
	}
	public UuuuOpts
	set(int key_, object val_){
		this[key_] = val_;
		return this;
	}
	
	
	public T
	get<T>(string key_){
		return (T)this[key_];
	}
	public T
	get<T>(int key_){
		return (T)this[key_];		
	}
	
	
	public T
	getWithDefaultFallback<T>( string key_, T defaultValue_ ){
		if (  this.ContainsKey( key_ )  ) {
			return (T)this[key_];
		} else {
			return defaultValue_;
		}
	}
	public T
	getWithDefaultFallback<T>( int key_, T defaultValue_ ){
		if (  this.ContainsKey( key_ )  ) {
			return (T)this[key_];
		} else {
			return defaultValue_;
		}
	}
	
	
	

	/// Methods for returning things when a programmer can't use generics (eg.  unityscript "javascript")
	public bool
	getBool( string key_ ){
		return (bool)(this[ key_ ]);
	}
	public bool
	getBool( int key_ ){
		return (bool)(this[ key_ ]);
	}
	
	public string
	getString( string key_ ){
		return (string)(this[ key_ ]);
	}
	public string
	getString( int key_ ){
		return (string)(this[ key_ ]);
	}
	
	public int
	getInt( string key_ ){
		return (int)(this[ key_ ]);
	}
	public int
	getInt( int key_ ){
		return (int)(this[ key_ ]);
	}
	
	public float
	getFloat( string key_ ){
		return (float)(this[ key_ ]);
	}
	public float
	getFloat( int key_ ){
		return (float)(this[ key_ ]);
	}
	
	public double
	getDouble( string key_ ){
		return (double)(this[ key_ ]);
	}
	public double
	getDouble( int key_ ){
		return (double)(this[ key_ ]);
	}
	
	public Texture
	getTexture( string key_ ){
		return this[ key_ ] as Texture;
	}
	public Texture
	getTexture( int key_ ){
		return this[ key_ ] as Texture;
	}


}
*/