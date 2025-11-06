Shader "Hidden/SephirothGrayScaleFadeSceneSwitching"
{
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _GrayScaleTex("GrayScaleTex", 2D) = "white" {}
        _CircleValue("Circle Value", Float) = 0
    }
    SubShader{
        Tags { "RenderType" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _GrayScaleTex;
            float4 _MainTex_ST;
            float _CircleValue;

            v2f vert(appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag(v2f i) : SV_Target{
                float pow = tex2D(_GrayScaleTex, i.uv).r;
                //pow = tex2D(_GrayScaleTex, i.uv).a; //If you want to judge based on transparency, please remove the comment out.
                
                pow = pow - _CircleValue + 0.2f;
                
                //clip(pow); //If you can expect faster speed by using clip, please remove the comment out.

                pow = saturate(5 * pow);
                //pow = step(_CircleValue, pow); //If you want to remove the soft mask, please remove the comment out.

                float4 result = tex2D(_MainTex, i.uv);
                result.w *= pow;
                //result.w *= pow; //If you want beauty in the fade, please remove the comment out.(Multiply pow twice in total)
                //result = float4(pow, pow, pow, 1) * result; //If you want to make the border darker,  please remove the comment out.
                
                return result;
            }
            ENDCG
        }
    }
}
