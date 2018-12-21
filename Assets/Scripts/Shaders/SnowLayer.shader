// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "CatchThemBalls/SnowLayer" {
	Properties {
   	    _MainColor ("Main Color", Color) = (1.0,1.0,1.0,1.0)
    	_MainTex ("Base (RGB)", 2D) = "white" {}
    	_Bump ("Bump", 2D) = "bump" {}
    	_Snow ("Snow level", Range(1, 0.001)) = 1
    	_SnowColor ("Snow color", Color) = (1.0,1.0,1.0,1.0)
    	_SnowDirection ("Snow direction", Vector) = (0,1,0)
    	_SnowDepth ("How much snow", Range(0,1)) = 0
	}
	SubShader {
    	Tags { "RenderType"="Opaque" }
    	LOD 200
 
    	CGPROGRAM
    	#pragma surface surf Lambert vertex:vert
 
    	sampler2D _MainTex;
    	sampler2D _Bump;
    	float _Snow;
    	float4 _SnowColor;
    	float4 _MainColor;
    	float4 _SnowDirection;
    	float _SnowDepth;
 
    	struct Input {
        	float2 uv_MainTex;
        	float2 uv_Bump;
        	float3 worldNormal;
        	INTERNAL_DATA
    	};
 
    	void vert (inout appdata_full v)
    	{
            float4 sn = mul(_SnowDirection, unity_WorldToObject);
            float d = dot(v.normal, sn.xyz);
            float multiplier = max(0, sign(d - _Snow));
   			v.vertex.xyz += (sn.xyz + v.normal) * _SnowDepth * _Snow * multiplier;		 
    	}
 
    	void surf (Input IN, inout SurfaceOutput o)
    	{
        	half4 c = tex2D (_MainTex, IN.uv_MainTex);
        	o.Normal = UnpackNormal (tex2D (_Bump, IN.uv_Bump));
        	
        	float d = dot(WorldNormalVector(IN, o.Normal), _SnowDirection.xyz);
            float multiplier = max(0, sign(d - _Snow));
        	
            o.Albedo = c.rgb * _MainColor + _SnowColor.rgb * multiplier;
        	o.Alpha = 1;
    	}
    	ENDCG
	}
	FallBack "Diffuse"
}