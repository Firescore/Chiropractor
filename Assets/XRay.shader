Shader "Shader/XRay"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
		//_XColor("XRay Color", Color) = (1,1,1,1)
		_HDR("Intensity",float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="2000" }
        LOD 200

		//Normal
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0
        sampler2D _MainTex;
        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
		float _HDR;
		

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c =_Color;
            o.Albedo =c.rgb;
			o.Albedo = c.rgb;
			//o.Emission = c.rgb * _HDR;
            o.Alpha = c.a;
        }

        ENDCG

		//XRay
		ZTEST GREATER

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0
		struct Input
		{
			float2 uv_MainTex;
		};

		fixed4 _Color;
		float _HDR;

		UNITY_INSTANCING_BUFFER_START(Props)
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = _Color;
			o.Albedo = c.rgb;
			//o.Emission = c.rgb*_HDR;
			o.Alpha = c.a;
		}
		ENDCG
    }
    FallBack "Diffuse"
}
