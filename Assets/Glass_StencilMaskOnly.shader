Shader "Custom/StencilMaskOnly"
{
    SubShader
    {
        Tags { "Queue"="Transparent-1" "RenderType"="Transparent" "RenderPipeline"="UniversalPipeline" }
        Pass
        {
            ZWrite Off
            ZTest LEqual
            ColorMask 0

            Stencil
            {
                Ref 1
                Comp Always
                Pass Replace
            }
        }
    }
}
