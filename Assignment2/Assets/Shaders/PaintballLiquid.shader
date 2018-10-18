Shader "Custom/PaintballLiquid"
{
	Properties
	{
		_PointLightColor ("Point Light Color", Color) = (0, 0, 0)
		_PointLightPosition ("Point Light Position", Vector) = (0.0, 0.0, 0.0)
		_NoiseTex ("Texture", 2D) = "white" {}
		_WaveOscillation ("Oscillation", Range(0.0, 100.0)) = 25.0
		_WaveAmplitude ("Amplitude", Range(0.01, 0.1)) = 0.05
		_Color ("Color", Color) = (1,1,1,1)
		_Transparency ("Transparency", Range(0.0, 0.75)) = 0.75
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		LOD 100

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform float3 _PointLightColor;
			uniform float3 _PointLightPosition;

			uniform sampler2D _NoiseTex;
			float _WaveOscillation;
			float _WaveAmplitude;
			uniform float _TextureAlpha;

			float _Transparency;
			fixed4 _Color;

			struct vertIn
			{
				float4 vertex : POSITION;
				float4 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct vertOut
			{
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
				float2 uv : TEXCOORD0;
				float4 worldVertex : TEXCOORD1;
				float3 worldNormal : TEXCOORD2;
			};

			// Implementation of the vertex shader
			vertOut vert(vertIn v)
			{
				vertOut o;

				o.color = _Color;
				o.uv = v.uv;

				float noise = tex2Dlod(_NoiseTex, float4(v.uv.xy, 0, 0));
				//float4 normalized = normalize(v.normal);
				//float4 displacement = float4(normalized.x * sin(noise * 25 * _Time.y) / 10, normalized.y * sin(noise * 25 * _Time.y) / 10, normalized.z * sin(noise * 25 * _Time.y) / 10, 0.0f);
				float4 displacement = mul(normalize(v.normal), sin((noise + _Time.y) * _WaveOscillation) * _WaveAmplitude);
				displacement.w = 0;
				v.vertex += displacement;

				// Transform vertex in world coordinates to camera coordinates
				o.vertex = UnityObjectToClipPos(v.vertex);

				o.worldVertex = mul(unity_ObjectToWorld, v.vertex);
				o.worldNormal = normalize(mul(transpose((float3x3)unity_WorldToObject), v.normal.xyz));

				return o;
			}
			
			// Implementation of the fragment shader
			fixed4 frag(vertOut v) : SV_Target
			{
				v.worldNormal = normalize(v.worldNormal);
				
				fixed4 col = _Color;
				col.a = _Transparency;
				return col;
			}
			ENDCG
		}
	}
}
