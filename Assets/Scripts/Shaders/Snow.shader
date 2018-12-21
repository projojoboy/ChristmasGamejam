// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "CatchThemBalls/Snow"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_DisplacementTex("Displacement", 2D) = "white" {}
		_SnowTex("Snow texture", 2D) = "white" {}
		_Speed ("Snow speed", Range(0.0001,5)) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _SnowTex;
			sampler2D _DisplacementTex;
			float _Speed;
			
			float4 frag (v2f i) : SV_Target
			{
				float4 col = tex2D(_MainTex, i.uv);
				float4 displacement = tex2D(_DisplacementTex, i.uv);
				
				float2 snowUV = i.uv + _Time.x + displacement;
				float4 depthSnow = tex2D(_SnowTex, (snowUV * 2) % 1);
				
				snowUV.y += _Time.y * _Speed;
				
				float4 snow = tex2D(_SnowTex, snowUV % 1);
				
				float4 snowLayer = (depthSnow + snow);
				
				snowLayer = max(0, sign(snowLayer - 0.1)) * 0.1;
				
				col += snowLayer;
                
				return col;
			}
			ENDCG
		}
	}
}