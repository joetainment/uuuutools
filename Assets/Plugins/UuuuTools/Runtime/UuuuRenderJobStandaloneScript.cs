using UnityEngine;
using System.Collections;
using System;

//// A rendering script that can be attached to a GameObject
//// 	in Unity to Render you scenes to image files at
//// 	runtime.  This script can be independent
//// 	and doesn't require the rest of UuuuTools to
//// 	function.  Thus you can copy this script alone
//// 	to any other project, and expect it to work.

public class UuuuRenderJobStandaloneScript : MonoBehaviour {
	
	// Controls For The Overall Behavior
	public bool         startRenderingImmediately;
	public bool			persistEvenAfterNewLevelLoad = true;
	public bool			useUnityCaptureRate = true;

	// Render Output Name
	public string 		nameLeaveBlankForTimeStamp="";
	public int			framePadding = 4;

	// Time and framerate controls
	public double		framerate = 24.0d;
	public double 		timeScale = 1.0;
	public double       lengthOfTimeToRender = 1.0;

	// keyboard control keys
	public string       keyboardLetterToStartRendering=".";
	public string       keyboardLetterToStopRendering=",";
	

	public int			sizeMultiplier = 1;

	// The back end object that actually does the rendering for us
	protected UuuuStandaloneRenderJob _renderJob;  // RenderJob here points to a class inside this class
	




	// Use this for initialization
	void
	Awake () {
		//// We might want to keep this "rendering script around even if
		////   a new level is loaded. In that case we mark the object as
		////   something that should not get destroyed
		if (persistEvenAfterNewLevelLoad){
			DontDestroyOnLoad(this.gameObject);
		}

		// Create the RenderJob instance for the backend
		//   we provide an initializer to take care of all the settings
		//   remember, it won't start working without the ini=1, at the end
		//   (a general strategy used for constructors with complex options
		//   that works across C#, Unityscript, and Boo
		_renderJob = new UuuuStandaloneRenderJob(){
			iniTimeScale=timeScale,
			iniUseUnityCaptureRate = useUnityCaptureRate,
			nameLeaveBlankForTimeStamp=nameLeaveBlankForTimeStamp,
			iniFramerate = framerate,
			iniFramePadding = framePadding,
			iniSizeMultiplier = sizeMultiplier,
			ini=1
		};

		if (  startRenderingImmediately  )  _startRender();
	}
	
	void
	LateUpdate () {
		//// Keyboard Controls
		if (  Input.GetKeyDown(keyboardLetterToStartRendering)  ){
			_startRender();
		}
		if (  Input.GetKeyDown( keyboardLetterToStopRendering )  ){
			_stopRender( );
		}
		//// Update the backend renderjob if we have one
		_update();
	}
	
	protected void
	_startRender(){
		if (_renderJob!=null) _renderJob.startRender( lengthOfTimeToRender );
	}

	protected void
	_stopRender(){
		if (_renderJob!=null) _renderJob.stopRender( );
	}

	protected void
	_update(){
		if (_renderJob!=null) _renderJob.update();
	}

	
	/*
	
	UuuuStandaloneRenderJob
	
	This is the backend that does the actual rendering.
	
	RenderJob definition is part of this file because,
	the file can be distributed as a single
	standalone script file, which is important
	since it is a generally useful script
	and many people may want to use it without
	the entire UuuuTools system.
	
	*/

	public class UuuuStandaloneRenderJob {
		
		//// "New" RenderJob
		public static UuuuStandaloneRenderJob
		Go(){
			return  new UuuuStandaloneRenderJob(){ ini=1 } ;
		}
		
		
		
		public bool		iniStartImmediately = false;
		public bool		iniUseUnityCaptureRate = true;
	
		public double  	iniTimeScale = 0.002;
		public double 	iniLengthOfTimeToRender = 1.0;
		public double 	iniFramerate = 24.0d;  // a near zero value will cause update to not render
		public int		iniFramePadding = 4;
		public int		iniSizeMultiplier = 1;

		public string 	nameLeaveBlankForTimeStamp="";
		public string   iniOutputPathNoExt="";  // this would override auto output path
		
		protected double _framerate;
		protected double _expireTime;
		protected double _timeScale;
		protected double _timeScaleBeforeRendering;	
		protected bool _isActive=false;
		protected int _renderedFrameCount=0;
		protected int _framePadding = 4;
		protected double _lastRenderedTime=-1.0;
		protected int _sizeMultiplier = 1;
		
		protected string _outputPathNoExt;
		protected bool _useUnityCaptureRate;
		protected bool _startImmediately;
		
		
		public int ini { set {  _init(); }	}
		
		
		public
		UuuuStandaloneRenderJob( ){
			
		}
		
	
		
		public void
		_init(){
			_useUnityCaptureRate = iniUseUnityCaptureRate;
			_timeScale = iniTimeScale;
			_outputPathNoExt = iniOutputPathNoExt;
			_startImmediately = iniStartImmediately;
			_framerate = iniFramerate;
			_framePadding = iniFramePadding;
			_sizeMultiplier = iniSizeMultiplier;
	
			if (_outputPathNoExt == ""){
				_outputPathNoExt = buildOutputPathNoExt();
			}
			
			if (iniStartImmediately){
				startRender( iniLengthOfTimeToRender );
			}
		}
		
		
		public string
		buildOutputPathNoExt(){
			
			string nameStr_="";
			
			if (  nameLeaveBlankForTimeStamp=="" || nameLeaveBlankForTimeStamp==null  ){
				
				DateTime now_ = DateTime.Now;	
				string nowStr_ = now_.ToString();
				nowStr_ = nowStr_.Replace( "/", "_" );
				nowStr_ = nowStr_.Replace( " ", "_" );
				nowStr_ = nowStr_.Replace( ":", "_" );
				
				nameStr_ = nowStr_;
			}
			else {
				nameStr_ = nameLeaveBlankForTimeStamp;
			}
			
			string loc_ = Application.dataPath;
			string path_ = loc_ + "/../" + nameStr_ + "_";
			
			
			return path_;
		}
		
		
		public void
		startRender( double lengthOfTimeToRender_ ){
			if (_isActive == false){
				_isActive = true;
				
				_timeScaleBeforeRendering = (double)Time.timeScale;
				Time.timeScale = (float)_timeScale;
				
				if ( _useUnityCaptureRate ){
					Time.captureFramerate = (int)   Mathf.Round(  (float)_framerate  );
				}
				
				_expireTime = (double)Time.time + lengthOfTimeToRender_;
			}
		}
		
		public void
		stopRender(){
			if (_isActive == true){
				_isActive = false;
				Time.timeScale = (float) _timeScaleBeforeRendering;	
				if ( _useUnityCaptureRate ){
					Time.captureFramerate = 0;
				}
			}
		}
		
		
		protected void
		_renderFrame(){
			string frameNumberString_ = _renderedFrameCount.ToString().PadLeft( _framePadding, '0');
			string outputPathThisFrame_ = _outputPathNoExt + frameNumberString_ + ".png" ;
			_lastRenderedTime = (double)Time.time;
			
			//Debug.Log( "Render a frame!" );
			Application.CaptureScreenshot( outputPathThisFrame_, _sizeMultiplier );
			_renderedFrameCount++;
		}
		
		
		public void
		update(){
			if (_isActive){
				double curTime_;
				double timePassed_;
				
				curTime_ = (double)Time.time;
				timePassed_= curTime_ - _lastRenderedTime;
				
				if (_framerate>=0.0001){
					if (  timePassed_ >= (1.0/_framerate)  ){
						//Debug.Log ( timePassed_ );
						_renderFrame();
					}
				}
				
				if ( (double)Time.time >= _expireTime  ){
					stopRender ();
				}
				
			}
		}
	}

}