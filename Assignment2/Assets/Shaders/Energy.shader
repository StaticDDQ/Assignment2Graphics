Shader "Custom/Energy"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_Fadeout("Fadeout", float) = 4
	}
	SubShader
	{
		//Enable transparency:
		Tags { "Queue" = "Transparent"}
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			//We need position and color by default.
			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 worldPos: POSITION1;
				float3 normal : NORMAL;
			};

			fixed4 _Color;
			float _Fadeout;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.worldPos = v.vertex;
				//Here we calculate intensity of the color. Closer to the edge, more intensity:
				o.normal = v.normal;

				return o;

			}

			fixed4 frag(v2f i) : SV_Target
			{
				float intensity;

				float3 dir = normalize(ObjSpaceViewDir(i.worldPos));
				intensity = 1 / dot(dir, i.normal);

				//Color by intensity
				float4 color = (_Color * intensity);
				color.a = intensity / _Fadeout;

				return color * _Color.a;
			}

			ENDCG
		}
	}
}
