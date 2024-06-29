Shader "Custom/GridOverlayShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _GridColor ("Grid Color", Color) = (1, 1, 1, 0.5) // Transparent white color for grid lines
        _CellSize ("Cell Size", float) = 1.0
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
            
            #include "UnityCG.cginc" // Include Unity's common shader functions
            
            struct appdata
            {
                float4 vertex : POSITION;
            };
            
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                fixed4 gridColor : COLOR;
            };
            
            float _CellSize;
            float4 _GridColor;
            
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.vertex.xy * 0.5 + 0.5; // Calculate texture coordinates
                o.gridColor = _GridColor;
                return o;
            }
            
            fixed4 frag(v2f i) : SV_Target
            {
                float2 gridUV = i.uv / _CellSize;
                float2 gridStep = frac(gridUV);
                float gridLineX = step(gridStep.x, 0.01);
                float gridLineY = step(gridStep.y, 0.01);
                float gridAlpha = min(gridLineX, gridLineY);
                fixed4 color = i.gridColor;
                color.a *= gridAlpha;
                return color;
            }
            
            ENDCG
        }
    }
    
    FallBack "Diffuse"
}
