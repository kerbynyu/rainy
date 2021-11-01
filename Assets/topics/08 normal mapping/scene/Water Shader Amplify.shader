// Upgrade NOTE: upgraded instancing buffer 'WaterShaderAmplify' to new syntax.

// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Water Shader Amplify"
{
	Properties
	{
		_Texture0("Texture 0", 2D) = "white" {}
		_Jitterspeed("Jitterspeed", Range( 0 , 1)) = 0.05803797
		_surfacespeed("surfacespeed", Range( 0 , 1)) = 0.4652335
		_Speedthing("Speed thing", Range( 0 , 1)) = 1
		_twirl1("twirl  1", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		Blend SrcAlpha OneMinusSrcAlpha
		GrabPass{ }
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma multi_compile_instancing
		#if defined(UNITY_STEREO_INSTANCING_ENABLED) || defined(UNITY_STEREO_MULTIVIEW_ENABLED)
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex);
		#else
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex)
		#endif
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows exclude_path:deferred vertex:vertexDataFunc 
		struct Input
		{
			float3 worldPos;
			float2 uv_texcoord;
			float4 screenPos;
		};

		uniform sampler2D _Texture0;
		ASE_DECLARE_SCREENSPACE_TEXTURE( _GrabTexture )

		UNITY_INSTANCING_BUFFER_START(WaterShaderAmplify)
			UNITY_DEFINE_INSTANCED_PROP(float, _surfacespeed)
#define _surfacespeed_arr WaterShaderAmplify
			UNITY_DEFINE_INSTANCED_PROP(float, _Speedthing)
#define _Speedthing_arr WaterShaderAmplify
			UNITY_DEFINE_INSTANCED_PROP(float, _Jitterspeed)
#define _Jitterspeed_arr WaterShaderAmplify
			UNITY_DEFINE_INSTANCED_PROP(float, _twirl1)
#define _twirl1_arr WaterShaderAmplify
		UNITY_INSTANCING_BUFFER_END(WaterShaderAmplify)


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float4 ase_screenPos = ComputeScreenPos( UnityObjectToClipPos( v.vertex ) );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float _surfacespeed_Instance = UNITY_ACCESS_INSTANCED_PROP(_surfacespeed_arr, _surfacespeed);
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			float _Speedthing_Instance = UNITY_ACCESS_INSTANCED_PROP(_Speedthing_arr, _Speedthing);
			float simplePerlin2D37 = snoise( ( ( _Time.y * _surfacespeed_Instance ) + ase_worldPos ).xy*_Speedthing_Instance );
			simplePerlin2D37 = simplePerlin2D37*0.5 + 0.5;
			float3 ase_vertexNormal = v.normal.xyz;
			float3 temp_output_41_0 = ( ase_screenPosNorm.x + ( simplePerlin2D37 * ase_vertexNormal ) );
			v.vertex.xyz += temp_output_41_0;
			v.vertex.w = 1;
			v.normal = temp_output_41_0;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float _Jitterspeed_Instance = UNITY_ACCESS_INSTANCED_PROP(_Jitterspeed_arr, _Jitterspeed);
			float2 temp_cast_0 = (_Jitterspeed_Instance).xx;
			float2 panner16 = ( 1.0 * _Time.y * temp_cast_0 + i.uv_texcoord);
			float2 temp_cast_1 = (( -1.0 * _Jitterspeed_Instance )).xx;
			float2 panner20 = ( 1.0 * _Time.y * temp_cast_1 + i.uv_texcoord);
			float4 color23 = IsGammaSpace() ? float4(1,0.4392157,0.9316358,0) : float4(1,0.1620294,0.8514725,0);
			float4 color69 = IsGammaSpace() ? float4(0.4858491,0.8571421,1,0) : float4(0.2011763,0.7052517,1,0);
			float4 lerpResult70 = lerp( color23 , color69 , _SinTime.w);
			float4 color43 = IsGammaSpace() ? float4(0.1226415,0.06489882,0.04107334,1) : float4(0.01390275,0.005411901,0.003180102,1);
			float4 temp_output_42_0 = ( ( ( tex2D( _Texture0, panner16 ) + tex2D( _Texture0, panner20 ) ) * lerpResult70 ) + color43 );
			o.Albedo = temp_output_42_0.rgb;
			float2 center45_g1 = float2( 0.5,0.5 );
			float2 delta6_g1 = ( i.uv_texcoord - center45_g1 );
			float angle10_g1 = ( length( delta6_g1 ) * 20.0 );
			float x23_g1 = ( ( cos( angle10_g1 ) * delta6_g1.x ) - ( sin( angle10_g1 ) * delta6_g1.y ) );
			float2 break40_g1 = center45_g1;
			float _twirl1_Instance = UNITY_ACCESS_INSTANCED_PROP(_twirl1_arr, _twirl1);
			float2 temp_cast_3 = (( _twirl1_Instance * _Time.y )).xx;
			float2 break41_g1 = temp_cast_3;
			float y35_g1 = ( ( sin( angle10_g1 ) * delta6_g1.x ) + ( cos( angle10_g1 ) * delta6_g1.y ) );
			float2 appendResult44_g1 = (float2(( x23_g1 + break40_g1.x + break41_g1.x ) , ( break40_g1.y + break41_g1.y + y35_g1 )));
			float2 temp_output_45_0 = appendResult44_g1;
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float4 screenColor3 = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture,( ( float4( temp_output_45_0, 0.0 , 0.0 ) * temp_output_42_0 ) + ase_screenPosNorm ).rg);
			o.Emission = screenColor3.rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18912
246.5;75;748.5;663;1214.675;31.41926;2.095661;True;False
Node;AmplifyShaderEditor.RangedFloatNode;26;-1423.219,283.7219;Inherit;False;Constant;_Float0;Float 0;3;0;Create;True;0;0;0;False;0;False;-1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;5;-1492.39,378.9328;Inherit;False;InstancedProperty;_Jitterspeed;Jitterspeed;2;0;Fetch;True;0;0;0;False;0;False;0.05803797;0.24;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;17;-1339.463,121.4628;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;25;-1242.219,274.7219;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;16;-956.2623,291.4441;Inherit;True;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TexturePropertyNode;12;-837.3442,-91.97903;Inherit;True;Property;_Texture0;Texture 0;1;0;Create;True;0;0;0;False;0;False;2af7dec9d0b994d4781945376ae3ef5e;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.PannerNode;20;-1046.266,131.4001;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;19;-460.9412,246.1288;Inherit;True;Property;_TextureSample1;Texture Sample 1;3;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;4;-460.1393,24.98495;Inherit;True;Property;_TextureSample0;Texture Sample 0;1;0;Create;True;0;0;0;False;0;False;-1;2af7dec9d0b994d4781945376ae3ef5e;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;69;-492.6661,648.8459;Inherit;False;Constant;_Color2;Color 2;6;0;Create;True;0;0;0;False;0;False;0.4858491,0.8571421,1,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SinTimeNode;71;-405.524,867.0193;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;23;-421.8704,476.3966;Inherit;False;Constant;_Color1;Color 1;3;1;[HDR];Create;True;0;0;0;False;0;False;1,0.4392157,0.9316358,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;70;-221.2215,488.1812;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;22;-120.7626,164.2812;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;34;-777.1443,-560.0502;Inherit;False;InstancedProperty;_surfacespeed;surfacespeed;3;0;Fetch;True;0;0;0;False;0;False;0.4652335;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;47;-306.1574,-190.4983;Inherit;False;InstancedProperty;_twirl1;twirl  1;5;0;Fetch;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;33;-553.1085,-157.9658;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;50;100.4261,-261.9593;Inherit;False;Constant;_Vector1;Vector 1;6;0;Create;True;0;0;0;False;0;False;0.5,0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.WorldPosInputsNode;32;-418.5792,-513.1235;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.ColorNode;43;175.2741,556.7379;Inherit;False;Constant;_Color0;Color 0;5;0;Create;True;0;0;0;False;0;False;0.1226415,0.06489882,0.04107334,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;35;-454.9498,-615.0707;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;51;112.2062,-114.1732;Inherit;False;Constant;_Float1;Float 1;6;0;Create;True;0;0;0;False;0;False;20;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;24;101.3515,292.7675;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;46;149.5371,-14.89999;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;38;-60.54191,-457.038;Inherit;False;InstancedProperty;_Speedthing;Speed thing;4;0;Fetch;True;0;0;0;False;0;False;1;500;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;45;383.9604,-178.9428;Inherit;True;Twirl;-1;;1;90936742ac32db8449cd21ab6dd337c8;0;4;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;3;FLOAT;0;False;4;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;42;412.8589,363.9911;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;36;-149.2258,-604.2148;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;37;134.9728,-605.572;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.NormalVertexDataNode;40;253.079,-786.4731;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;67;559.6376,123.0114;Inherit;False;2;2;0;FLOAT2;0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;2;363.5731,-393.0557;Float;True;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;39;463.8818,-528.8254;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;68;729.3259,-168.7209;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;41;663.5584,-632.1448;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;57;1313.925,45.22211;Inherit;True;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;48;792.4568,84.063;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SinTimeNode;55;-119.4925,-353.1897;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ScreenColorNode;3;768.9518,-400.3651;Inherit;False;Global;_GrabScreen0;Grab Screen 0;1;0;Create;True;0;0;0;False;0;False;Object;-1;False;False;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;979.7401,-380.3184;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Water Shader Amplify;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;False;Transparent;;Geometry;ForwardOnly;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;0;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;25;0;26;0
WireConnection;25;1;5;0
WireConnection;16;0;17;0
WireConnection;16;2;5;0
WireConnection;20;0;17;0
WireConnection;20;2;25;0
WireConnection;19;0;12;0
WireConnection;19;1;20;0
WireConnection;4;0;12;0
WireConnection;4;1;16;0
WireConnection;70;0;23;0
WireConnection;70;1;69;0
WireConnection;70;2;71;4
WireConnection;22;0;4;0
WireConnection;22;1;19;0
WireConnection;35;0;33;0
WireConnection;35;1;34;0
WireConnection;24;0;22;0
WireConnection;24;1;70;0
WireConnection;46;0;47;0
WireConnection;46;1;33;0
WireConnection;45;2;50;0
WireConnection;45;3;51;0
WireConnection;45;4;46;0
WireConnection;42;0;24;0
WireConnection;42;1;43;0
WireConnection;36;0;35;0
WireConnection;36;1;32;0
WireConnection;37;0;36;0
WireConnection;37;1;38;0
WireConnection;67;0;45;0
WireConnection;67;1;42;0
WireConnection;39;0;37;0
WireConnection;39;1;40;0
WireConnection;68;0;67;0
WireConnection;68;1;2;0
WireConnection;41;0;2;1
WireConnection;41;1;39;0
WireConnection;48;0;45;0
WireConnection;48;1;55;4
WireConnection;3;0;68;0
WireConnection;0;0;42;0
WireConnection;0;2;3;0
WireConnection;0;11;41;0
WireConnection;0;12;41;0
ASEEND*/
//CHKSM=DB4B8D89B86E6B7AD0962C4C3F2E84C6E68399B4