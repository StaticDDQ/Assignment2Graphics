Shader "Custom/CelShader"
{
	Properties
	{
		_Color ("Diffuse Color", Color) = (1, 1, 1, 1)
		_UnlitColor ("Unlit Diffuse Color", Color) = (0.5, 0.5, 0.5, 1)
		_DiffuseThreshold ("Diffuse Threshold", Range(0, 1)) = 0.1
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_LitOutlineThickness ("Lit Outline Thickness", Range(0,1)) = 0.1
		_UnlitOutlineThickness ("Unlit Outline Thickness", Range(0,1)) = 0.4
		_SpecColor ("Specular Color", Color) = (1,1,1,1) 
		_Shininess ("Shininess", Float) = 10
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "LightMode" = "ForwardBase" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			uniform float4 _LightColor0;

			uniform float4 _Color; 
			uniform float4 _UnlitColor;
			uniform float _DiffuseThreshold;
			uniform float4 _OutlineColor;
			uniform float _LitOutlineThickness;
			uniform float _UnlitOutlineThickness;
			uniform float4 _SpecColor; 
			uniform float _Shininess;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 normal : NORMAL;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				float4 worldVertex : TEXCOORD1;
				float3 worldNormal : TEXCOORD2;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;

				o.worldVertex = mul(unity_ObjectToWorld, v.vertex);
				o.worldNormal = normalize(mul(transpose((float3x3)unity_WorldToObject), v.normal.xyz));

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				i.worldNormal = normalize(i.worldNormal);
				float3 viewDir = normalize(_WorldSpaceCameraPos - i.worldVertex.xyz);
				fixed4 col;

				float attenuation = 1.0;
				float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);

				float3 fragCol = _UnlitColor.rgb;

				if (attenuation * max(0.0, dot(i.worldNormal, lightDir)) >= _DiffuseThreshold) {
					fragCol = _LightColor0.rgb * _Color.rgb;
				}

				if (dot(viewDir, i.worldNormal) <
					lerp(_UnlitOutlineThickness, _LitOutlineThickness, max(0.0, dot(i.worldNormal, lightDir)))) {
					fragCol = _LightColor0.rgb * _OutlineColor.rgb;
				}

				if (dot(i.worldNormal, lightDir) > 0.0 &&
					attenuation * pow(max(0.0, dot(reflect(-lightDir, i.worldNormal), viewDir)), _Shininess) > 0.5) {
					fragCol = _SpecColor.a * _LightColor0.rgb * _SpecColor.rgb + (1.0 - _SpecColor.a) * fragCol;
				}

				// sample the texture
				//fixed4 col = tex2D(_MainTex, i.uv);
				//fixed4 col = _Color;
				return float4(fragCol, 1.0);
			}
			ENDCG
		}
	}
}
