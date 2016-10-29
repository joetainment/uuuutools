using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This is a Utility class that is generally easier to use than other methods,
// such as standard hashtables, dictionaries, etc.
//
// It has some nice built in convienience functions

public class UuuuOpts : Hashtable {

	//// Static Functions ////////////////////////////////////////////
	////


	//// Make a UuuuOpts from a given string
	//// 	if pairs aren't given, the first part of the string will be added with a key of
	///  	int zero thus, if a user only includes one thing, it will be at key int 0
	///  	otherwise it's a comma seperated list of key/value pair
	public static UuuuOpts
	FromString( string stringGiven_ ){

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




	//// Constructors ////////////////////////////////////////////
	////

	//// Create a default UuuuOpts object
	public UuuuOpts(){
		
	}
	
	//// Create a new UuuuOpts from an existing one
	public
	UuuuOpts( IDictionary idict_ ){
		foreach( DictionaryEntry de_ in idict_ ){
			Add( de_.Key, de_.Value );
		}
	}

	//// Create a new UuuuOpts by Merging two others
	public
	UuuuOpts( IDictionary idict1_, IDictionary idict2_){
		foreach( DictionaryEntry de_ in idict1_ ){
			Add( de_.Key, de_.Value );
		}
		foreach( DictionaryEntry de_ in idict2_ ){
			Add( de_.Key, de_.Value );
		}
	}
	


	//// Get and Set functions /////////////////////////////////
	//// 	These are the main purposes of this class
	//// 	and exist to make getting and setting easier	
	
	//// UuuuOpts simple set functions
	//// 	UuuuOpts uses s instead of set because we can't use set since
	//// 	it's a keyword, thus we shorten it to s.  This also allows us to chain calls together
    public virtual UuuuOpts
    S(string key_, object val_){
		return this.Set( key_, val_ );
    }
    public virtual UuuuOpts
    S(int key_, object val_){
        return this.Set( key_, val_ );
    }

	public UuuuOpts
	Set(string key_, object val_){
		this[key_] = val_;
		return this;
	}
	public UuuuOpts
	Set(int key_, object val_){
		this[key_] = val_;
		return this;
	}

	////////////////////////////////////
	////	Get generic data
	////
	public T
	Get<T>(string key_){
		return (T)this[key_];
	}
	public T
	Get<T>(int key_){
		return (T)this[key_];		
	}
	
	public T
	GetWithDefaultFallback<T>( string key_, T defaultValue_ ){
		if (  this.ContainsKey( key_ )  ) {
			return (T)this[key_];
		} else {
			return defaultValue_;
		}
	}
	public T
	GetWithDefaultFallback<T>( int key_, T defaultValue_ ){
		if (  this.ContainsKey( key_ )  ) {
			return (T)this[key_];
		} else {
			return defaultValue_;
		}
	}


	////////////////////////////////////
	////	Get commonly used standard C# data types
	////
	public bool
	GetBool( string key_ ){
		return (bool)(this[ key_ ]);
	}
	public bool
	GetBool( int key_ ){
		return (bool)(this[ key_ ]);
	}
	
	public int
	GetInt( string key_ ){
		return (int)(this[ key_ ]);
	}
	public int
	GetInt( int key_ ){
		return (int)(this[ key_ ]);
	}
	
	public double
	GetDouble( string key_ ){
		return (double)(this[ key_ ]);
	}
	public double
	GetDouble( int key_ ){
		return (double)(this[ key_ ]);
	}
	
	public float
	GetFloat( string key_ ){
		return (float)(this[ key_ ]);
	}
	public float
	GetFloat( int key_ ){
		return (float)(this[ key_ ]);
	}

	//// This exists so that we can use boo's "single",
	//// which is really the same as a float
	public float
	GetSingle( string key_ ){
		return this.GetFloat( key_ );
	}

	public string
	GetString( string key_ ){
		return (string)(this[ key_ ]);
	}
	public string
	GetString( int key_ ){
		return (string)(this[ key_ ]);
	}



	////////////////////////////////////
	////	Get commonly used Unity specific data types
	////
	public GameObject
	GetGameObject( string key_ ){
		return this[ key_ ] as GameObject;
	}
	public GameObject
	GetGameObject( int key_ ){
		return this[ key_ ] as GameObject;
	}
	public Texture
	GetTexture( string key_ ){
		return this[ key_ ] as Texture;
	}
	public Texture
	GetTexture( int key_ ){
		return this[ key_ ] as Texture;
	}
}
