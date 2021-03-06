﻿Shader "Custom/AmbientWhite"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
		_Ka ("Ka", range(0.0, 5.0)) = 4
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 color : COLOR;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Color;
			float _Ka;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.color = _Color;
				return o;
			}
			
			// Ambient light (from Phong) on white
			fixed4 frag (v2f i) : SV_Target
			{
				float3 amb = i.color.rgb * UNITY_LIGHTMODEL_AMBIENT * _Ka;

				float4 col = float4(0.0f, 0.0f, 0.0f, 0.0f);
				col.rgb += amb.rgb;
				return col;
			}
			ENDCG
		}
	}
}
