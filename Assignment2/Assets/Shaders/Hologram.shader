Shader "Custom/Hologram"
// If you want to attach it to a rigidbody object, increase the whole collider by a small bit (.01 or something) to avoid Z-fighting
{
	Properties
	{
		_Color("Color", Color) = (1,0,0,1)
		_Bias("Bias", Range(-1,1.5)) = 0
		_Speed("Speed", float) = 3
		_LengthX("Length X", float) = 100
		_LengthY("Length Y", float) = 100
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		LOD 100

		ZWrite Off
		Blend SrcAlpha One
		Cull Off

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
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 worldPos : TEXCOORD1;
			};

			fixed4 _Color;
			float _Bias;
			float _Speed;
			float _LengthX;
			float _LengthY;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.worldPos = mul(unity_ObjectToWorld,v.vertex);
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col;
				
				col = _Color * max(0, sin(i.worldPos.y * _LengthX + _Time.w * _Speed) + _Bias);
				col += _Color * max(0, cos(i.worldPos.x * _LengthY) + _Bias);
				
				
				return col;
			}
			ENDCG
		}
	}
}
