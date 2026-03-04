Shader "Custom/URP/ReticleGlow_XR"
{
    Properties
    {
        _MainTex ("Reticle (RGBA)", 2D) = "white" {}
        [HDR]_GlowColor ("Glow Color (HDR)", Color) = (1,0,0,1)
        _Intensity ("Glow Intensity", Float) = 20
    }

    SubShader
    {
        Tags
        {
            "RenderPipeline"="UniversalPipeline"
            "Queue"="Transparent+50"
            "RenderType"="Transparent"
        }

        Pass
        {
            Name "ReticleGlowXR"
            Blend One One
            ZWrite Off
            ZTest Always
            Cull Off

            // OPTIONAL stencil test (only show through lens mask):
            
            Stencil
            {
                Ref 1
                Comp Equal
                Pass Keep
            }
            

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            // XR / instancing support:
            #pragma multi_compile_instancing
            #pragma multi_compile _ _STEREO_INSTANCING_ENABLED _STEREO_MULTIVIEW_ENABLED

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            float4 _GlowColor;
            float  _Intensity;

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv         : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv          : TEXCOORD0;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            Varyings vert (Attributes v)
            {
                Varyings o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                o.positionHCS = TransformObjectToHClip(v.positionOS.xyz);
                o.uv = v.uv;
                return o;
            }

            half4 frag (Varyings i) : SV_Target
            {
                UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

                half4 t = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
                half mask = t.a; // alpha defines the reticle shape

                half3 glow = _GlowColor.rgb * (_Intensity * mask); // HDR output for bloom
                return half4(glow, mask);
            }
            ENDHLSL
        }
    }
}
