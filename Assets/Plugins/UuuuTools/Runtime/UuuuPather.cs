using UnityEngine;
using System.Collections;
using System.Collections.Generic; 


// A utility class to assist with handling file paths.


public class UuuuPather {



	public static string
	FixPathForUnity( string path_ ){
		path_ = path_.Replace("\\", "/" );		
		return path_;		
	}
	
	public static string
	FixPathForWindows( string path_ ){
		path_ = path_.Replace("/", "\\" );
		return path_;
	}

	
			/*
			public static string
			FixPathForUnity( string path_ ){
				path_ = path_.Replace("\\", "/" );		
				return path_;		
			}
			
			public static string
			FixPathForWindows( string path_ ){
				path_ = path_.Replace("/", "\\" );
				return path_;
			}
			*/

	






	
	public string path;
	
	public
	UuuuPather( string path_ ){
		path_ = FixPathForUnity( path_ );
		
		if (  path_.Contains( Application.dataPath )  ){
			
		}
		else {
			path_ = Application.dataPath + "/" + path_;
		}
		path = path_;
	}
	
	public string getInDataPath( ){
		string p = path;
		string a = FixPathForUnity( Application.dataPath );		
		if ( !p.Contains( a ) )  throw new System.Exception();		
		p = p.Substring( a.Length + 1); //// +1 is used to get rid of the trailing slash
		return p;
	}
	
	public List<string>
	getFilesInFolderAsStrings( ){
		return GetFilesInFolderRelativeToFolder(  path  );	
	}
	
	public List<UuuuPather>
	getFilesInFolder(){
		var pathers_ = new List<UuuuPather>();
		List<string> files_ = GetFilesInFolderRelativeToFolder(  path  );
		foreach ( string file_ in files_ ){
			pathers_.Add(  new UuuuPather( path + "/" + file_ )   );
		}
		return pathers_;
	}
	
	public List<UuuuPather>
	getFoldersInFolder(){

		string[] dirs_ = System.IO.Directory.GetDirectories( path );
		List<UuuuPather> dirPathers_ = new List<UuuuPather>(dirs_.Length);
		
		foreach( string dir_ in dirs_ ){
			dirPathers_.Add(  new UuuuPather(dir_)  );
			Debug.Log( "Added path:" + dir_  );
		}
		
		return dirPathers_;
	}
	
	public string
	getName(){
		return path.Substring(  path.LastIndexOf( "/" )  + 1   );
	}









	
	
	public static List<string>
	GetFilesInFolderRelativeToFolder( string path_ ){
		path_ = FixPathForWindows( path_ );
		
		List<string> filesRelativeToFolder_ = new List<string>();
		
		int originalPathLength_ = path_.Length;
		string [] fileEntries_ = System.IO.Directory.GetFiles( path_ );
		
		foreach(string fileEntry_ in fileEntries_) {
			string r = fileEntry_.Substring( originalPathLength_ + 1 );
			//// this gets everything past the length of the old path,
			//// we have to add one to get rid of the backslash 
			Debug.Log(  "Substring of absolute file path is:  "  +  r  );
			filesRelativeToFolder_.Add( r );
		}
		
		return filesRelativeToFolder_;
	}
		
			/*
			public static List<string>
			GetFilesInFolderRelativeToFolder( string path_ ){
				path_ = FixPathForWindows( path_ );
				
				List<string> filesRelativeToFolder_ = new List<string>();
				
				int originalPathLength_ = path_.Length;
				string [] fileEntries_ = System.IO.Directory.GetFiles( path_ );
				
				foreach(string fileEntry_ in fileEntries_) {
					string r = fileEntry_.Substring( originalPathLength_ + 1 );
					//// this gets everything past the length of the old path,
					//// we have to add one to get rid of the backslash 
					Debug.Log(  "Substring of absolute file path is:  "  +  r  );
					filesRelativeToFolder_.Add( r );
				}
				
				return filesRelativeToFolder_;
			}
			*/	

	














}
