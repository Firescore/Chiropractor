// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "CrazyLabs/AcrylicNails/Stencil"
{
	Properties
	{
		[KeywordEnum(1Color,2Colors,3Colors)] _GradientColors("GradientColors", Float) = 0
		[Space]_Color1("Color 1", Color) = (0,0,0,0)
		_Color2("Color 2", Color) = (0,0,0,0)
		_Color3("Color 3", Color) = (0,0,0,0)
		[Header(Gradient Settings)]_RotateGradient("Rotate Gradient", Range( 0 , 359)) = 0
		_Start("Start", Range( 0 , 1)) = 0
		_End("End", Range( 0 , 1)) = 1
		[Header(Specular Settings)]_Metalic("Metalic", Range( 0 , 1)) = 0
		_Smoothness("Smoothness", Range( 0 , 1)) = 0
		[Header(Stencil)]_StencilAlpha("Stencil Alpha", 2D) = "white" {}
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		[Header(Normal)]_NormalMap("Normal Map", 2D) = "bump" {}
		_NormalScale("Normal Scale", Range( 0 , 2)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1

		_Color4("Color 4", Color) = (1,1,1,1)
		_DissolveTexture("Dissolve Texture",2D)="white"{}
		_Amount("Amount",Range(0,1))=0
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "AlphaTest+0" }
		Cull Back
		CGPROGRAM
		#include "UnityStandardUtils.cginc"
		#pragma target 3.0
		#pragma shader_feature_local _GRADIENTCOLORS_1COLOR _GRADIENTCOLORS_2COLORS _GRADIENTCOLORS_3COLORS _DISSOLVECOLOR_1COLOR
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 

		sampler2D _MainTex;

		struct Input
		{
			float2 uv_texcoord;
			float2 uv_MainTex;
		};

		uniform sampler2D _NormalMap;
		uniform float4 _NormalMap_ST;
		uniform float _NormalScale;
		uniform float4 _Color1;
		uniform float4 _Color2;
		uniform float _RotateGradient;
		uniform float _Start;
		uniform float _End;
		uniform float4 _Color3;
		uniform float _Metalic;
		uniform float _Smoothness;
		uniform sampler2D _StencilAlpha;
		uniform float4 _StencilAlpha_ST;
		uniform float _Cutoff = 0.5;

		uniform float4 _Color4;
		uniform sampler2D _DissolveTexture;
		uniform half _Amount;


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			half dissolve_value = tex2D(_DissolveTexture, i.uv_texcoord).r;
			clip (dissolve_value - _Amount);
			fixed4 c = tex2D (_MainTex, i.uv_texcoord) * _Color4;

			float2 uv_NormalMap = i.uv_texcoord * _NormalMap_ST.xy + _NormalMap_ST.zw;
			float3 normal17 = UnpackScaleNormal( tex2D( _NormalMap, uv_NormalMap ), _NormalScale );
			o.Normal = normal17;

			float4 color142 = _Color1;
			float4 color243 = _Color2;

			float cos9 = cos( radians( _RotateGradient ) );
			float sin9 = sin( radians( _RotateGradient ) );

			float2 rotator9 = mul( i.uv_texcoord - float2( 0.5,0.5 ) , float2x2( cos9 , -sin9 , sin9 , cos9 )) + float2( 0.5,0.5 );
			float mapedUv37 = saturate( (0.0 + (rotator9.y - _Start) * (1.0 - 0.0) / (_End - _Start)) );

			float4 lerpResult8 = lerp( color142 , color243 , mapedUv37);
			float4 twoColors15 = lerpResult8;

			float4 lerpResult52 = lerp( color142 , color243 , saturate( (0.0 + (mapedUv37 - 0.0) * (1.0 - 0.0) / (0.6666 - 0.0)) ));
			float4 color345 = _Color3;

			float4 lerpResult57 = lerp( lerpResult52 , color345 , saturate( (0.0 + (mapedUv37 - 0.6666) * (1.0 - 0.0) / (1.0 - 0.6666)) ));
			float4 threeColors53 = lerpResult57;

			#if defined(_GRADIENTCOLORS_1COLOR)
				float4 staticSwitch36 = color142;
			#elif defined(_GRADIENTCOLORS_2COLORS)
				float4 staticSwitch36 = twoColors15;
			#elif defined(_GRADIENTCOLORS_3COLORS)
				float4 staticSwitch36 = threeColors53;
			#elif defined(_DISSOLVECOLOR_1COLOR)
				float4 staticSwitch36 = c;
			#else
				float4 staticSwitch36 = color142;
			#endif
			float4 albedo39 = staticSwitch36;

			o.Albedo = albedo39.rgb;
			o.Metallic = _Metalic;
			o.Smoothness = _Smoothness;
			o.Alpha = c.a;	
			float2 uv_StencilAlpha = i.uv_texcoord * _StencilAlpha_ST.xy + _StencilAlpha_ST.zw;
			float stencilAlpha19 = tex2D( _StencilAlpha, uv_StencilAlpha ).a;
			clip( stencilAlpha19 - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}

/*ASEBEGIN
Version=18301
0;728;1279;273;2563.08;945.7657;1.3;True;False
Node;AmplifyShaderEditor.CommentaryNode;40;-3243.131,-400.4829;Inherit;False;1637.835;450.2455;Comment;11;12;11;21;4;9;34;10;33;32;35;37;Mapped UV;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;12;-3193.131,-105.953;Inherit;False;Property;_RotateGradient;Rotate Gradient;4;0;Create;True;0;0;False;1;Header(Gradient Settings);False;0;0;0;359;0;1;FLOAT;0
Node;AmplifyShaderEditor.RadiansOpNode;21;-2888.078,-109.1303;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;11;-2968.131,-236.9529;Inherit;False;Constant;_Vector0;Vector 0;6;0;Create;True;0;0;False;0;False;0.5,0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TexCoordVertexDataNode;4;-2992.246,-350.4828;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RotatorNode;9;-2714.131,-277.9529;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.BreakToComponentsNode;10;-2506.131,-277.9529;Inherit;False;FLOAT2;1;0;FLOAT2;0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.RangedFloatNode;33;-2580.84,-146.1391;Inherit;False;Property;_Start;Start;5;0;Create;True;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;34;-2579.513,-65.23751;Inherit;False;Property;_End;End;6;0;Create;True;0;0;False;0;False;1;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;32;-2214.886,-255.6333;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;35;-2020.383,-255.7277;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;37;-1848.296,-258.9897;Inherit;False;mapedUv;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;7;-2247.666,-951.5483;Inherit;False;Property;_Color2;Color 2;2;0;Create;True;0;0;False;0;False;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;6;-2247.666,-1120.548;Inherit;False;Property;_Color1;Color 1;1;0;Create;True;0;0;False;1;Space;False;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;51;-3488.649,782.0817;Inherit;False;37;mapedUv;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;42;-2025.964,-1121.093;Inherit;False;color1;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;43;-2033.071,-951.6781;Inherit;False;color2;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;59;-3287.605,1020.039;Inherit;False;37;mapedUv;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;44;-2239.661,-770.1238;Inherit;False;Property;_Color3;Color 3;3;0;Create;True;0;0;False;0;False;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TFHCRemapNode;55;-3280.467,786.3572;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.6666;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;56;-3094.467,786.3572;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;54;-3130.514,560.7822;Inherit;False;42;color1;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;45;-2033.066,-770.2537;Inherit;False;color3;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TFHCRemapNode;61;-3079.423,1024.314;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0.6666;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;50;-3131.814,638.7822;Inherit;False;43;color2;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;46;-3057.293,201.4133;Inherit;False;42;color1;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;38;-3062.428,351.7128;Inherit;False;37;mapedUv;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;60;-2893.423,1024.314;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;47;-3058.593,279.4133;Inherit;False;43;color2;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;58;-2914.885,750.4583;Inherit;False;45;color3;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;52;-2921.228,621.064;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;57;-2641.885,625.6587;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;8;-2848.007,261.6951;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;53;-2458.055,619.6727;Inherit;False;threeColors;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;15;-2675.733,256.4039;Inherit;False;twoColors;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;62;-2042.15,397.9939;Inherit;False;53;threeColors;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;3;-3186.616,-1064.507;Inherit;False;Property;_NormalScale;Normal Scale;12;0;Create;True;0;0;False;0;False;0;0;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;49;-2037.33,242.0966;Inherit;False;42;color1;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;48;-2042.531,317.4966;Inherit;False;15;twoColors;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;2;-2890.931,-1110.158;Inherit;True;Property;_NormalMap;Normal Map;11;0;Create;True;0;0;False;1;Header(Normal);False;-1;None;None;True;0;False;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StaticSwitch;36;-1762.112,292.4515;Inherit;False;Property;_GradientColors;GradientColors;0;0;Create;True;0;0;False;0;False;0;0;0;True;;KeywordEnum;3;1Color;2Colors;3Colors;Create;True;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;5;-2897.29,-874.1556;Inherit;True;Property;_StencilAlpha;Stencil Alpha;9;0;Create;True;0;0;False;1;Header(Stencil);False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;39;-1483.219,294.4537;Inherit;False;albedo;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;19;-2597.708,-784.014;Inherit;False;stencilAlpha;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;17;-2584.536,-1111.144;Inherit;False;normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;30;-1255.903,-427.3821;Inherit;False;Property;_Metalic;Metalic;7;0;Create;True;0;0;False;1;Header(Specular Settings);False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;16;-1097.299,-577.0909;Inherit;False;39;albedo;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;29;-1197.17,-183.0245;Inherit;False;19;stencilAlpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;31;-1254.632,-346.4863;Inherit;False;Property;_Smoothness;Smoothness;8;0;Create;True;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;18;-1094.337,-498.2881;Inherit;False;17;normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-877.572,-489.8786;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;CrazyLabs/AcrylicNails/Stencil;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Masked;0.5;True;True;0;False;TransparentCutout;;AlphaTest;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;10;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;21;0;12;0
WireConnection;9;0;4;0
WireConnection;9;1;11;0
WireConnection;9;2;21;0
WireConnection;10;0;9;0
WireConnection;32;0;10;1
WireConnection;32;1;33;0
WireConnection;32;2;34;0
WireConnection;35;0;32;0
WireConnection;37;0;35;0
WireConnection;42;0;6;0
WireConnection;43;0;7;0
WireConnection;55;0;51;0
WireConnection;56;0;55;0
WireConnection;45;0;44;0
WireConnection;61;0;59;0
WireConnection;46;0;42;0
WireConnection;38;0;37;0
WireConnection;60;0;61;0
WireConnection;52;0;54;0
WireConnection;52;1;50;0
WireConnection;52;2;56;0
WireConnection;57;0;52;0
WireConnection;57;1;58;0
WireConnection;57;2;60;0
WireConnection;8;0;46;0
WireConnection;8;1;47;0
WireConnection;8;2;38;0
WireConnection;53;0;57;0
WireConnection;15;0;8;0
WireConnection;2;5;3;0
WireConnection;36;1;49;0
WireConnection;36;0;48;0
WireConnection;36;2;62;0
WireConnection;39;0;36;0
WireConnection;19;0;5;4
WireConnection;17;0;2;0
WireConnection;0;0;16;0
WireConnection;0;1;18;0
WireConnection;0;3;30;0
WireConnection;0;4;31;0
WireConnection;0;10;29;0
ASEEND*/
//CHKSM=009F72DB390F2DE38078BC892D5D8854E7096F59