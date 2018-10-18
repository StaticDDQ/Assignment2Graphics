Shader "Custom/Outline" {
	Properties {
		_Color ("Color", Color) = (0,0,0,1)
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_OutlineWidth ("Outline width", float) = .03
		_OutlineRatio("Outline Ratio", float) = 0.9
		_OutlineSize("Outline Size", float) = 1.05
		_MainTex("Texture", 2D) = "white" {}
	}

	SubShader {
		Tags { "Queue" = "Transparent" }
 
		// note that a vertex shader is specified here but its using the one above
		Pass {

			Cull Off
			ZWrite Off
			ColorMask RGB 

			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			struct appdata {
				float4 vertex : POSITION;
			};

			struct v2f {
				float4 vertex : POSITION;
			};

			#include "UnityCG.cginc"

			float4 _OutlineColor;
			float _OutlineSize;

			v2f vert(appdata v) {
				
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.vertex.xyz *= _OutlineSize;
				return o;
			}

			fixed4 frag(v2f i) : COLOR{
				return _OutlineColor;
			}
		ENDCG
		}
 
		Pass {
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			struct appdata {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed4 _Color;
			float _OutlineWidth;
			float _OutlineRatio;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);

				float3 norm = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
				float2 offset = TransformViewToProjection(norm.xy);

				o.vertex.xy += offset * o.vertex.z * _OutlineWidth;
				o.vertex.xy *= _OutlineRatio;
				o.uv = v.uv;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv) * _Color;
				return col;
			}
			ENDCG
		}
	}
}