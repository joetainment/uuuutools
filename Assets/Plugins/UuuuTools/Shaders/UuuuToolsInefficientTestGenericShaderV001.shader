Shader "UuuuTools/UuuuTools Inefficient Generic Shader V001" {
	//// This shader should *not actually be used* in shipping
	//// products, but it can be very useful for testing
	//// and learning purposes.
	//// 
	//// It can function as an excellent tool for learning,
	//// because it contains a lot of comments and notes about
	//// shader writing. It also features a lot of
	////
	//// For actual production use, we recommend duplicating
	//// this code and creating specialized efficient shaders
	//// from it using only the features you need.
	////
	//// This shader will continue to develop into newer
	//// and more elaborate shaders as new versions
	//// of UuuuTools are developed
	////
	//// Additional notes can be found at the bottom of
	//// the code in this text.

	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}


	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		// Joe_edit:  added "addshadow" - see note001
		#pragma surface surf Standard fullforwardshadows addshadow
		
		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0



		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float4 customColor;
			float4 color : COLOR;
		};

		half _Glossiness;
		half _Metallic;
		float4 _Color;


		void surf (Input IN, inout SurfaceOutputStandard o) {
			float4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

			// Clip (be transparent) if the alpha of the pixel is less than 0.5
			clip( ( IN.color.a * c.a) - 0.4 );

			// Albedo comes from a texture tinted by color
			o.Albedo = c.rgb * IN.color.r;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}

/*

Note001:
added "addshadow" - 
so that the clipping casts the shadows correctly
that will likely affect shadows badly, so there should be a no clip
version of this shader too


Note002: 

		//// Joe_edit: at end, use the vert function for the vertex shader

		//// Joe_edit:  a vertex shader so we can grab vertex colors
		void vert (inout appdata_full v, out Input o) {
			o.customColor = v.color;
		}

Note003:


Roadmap for future development:
	Additional tweaking via more properties, such as
		alpha vert mult
		alpha tex mult
		alpha mult

	Multiple conditionally compiled versions of this shader
		to allow for one without "clip" and addshadows

	A more complete explanation of the various
		texture channels usage
		+
		vertex color channels usage

		// default meanings - metallic r,  smoothness a, occlusion g,
		//						emis is rgb
		//
		// best possible meanings?:
		//   r - metallic
		//   g - occlusion or perhaps height as alternative?
		//   b - emis
		//   a - smoothness
		//
		//
		//
		//
		// vertex colors mean:   (there should be a blender color, so this isn't good enough
		//   r = mult
		//   g = emissive mult
		//   b = displacement mult
		//   a = alpha for cutout level



*/