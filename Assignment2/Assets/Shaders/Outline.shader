Shader "Unlit/Outline"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_OutlineRange("Outline Width", Range(0.0,1.0)) = 0.9
	}
	
	SubShader
	{
		Tags{"Queue" = "Transparent"}

		// Pass for the outline effect
		Pass{

			ZWrite Off
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			struct appdata {
				float4 vertex : POSITION;
			};

			struct v2f {
				float4 vertex : POSITION;
			};

			float4 _OutlineColor;

			v2f vert(appdata v) {

				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			fixed4 frag(v2f i) : COLOR{
				return _OutlineColor;
			}

			ENDCG
		}
		// Pass for the regular vertices
		Pass{

			ZWrite On

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float _OutlineRange;
			fixed4 _Color;

			v2f vert(appdata v)
			{
				v2f o;
				v.vertex.xyz *= _OutlineRange;
				o.vertex = UnityObjectToClipPos(v.vertex);
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
