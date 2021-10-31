//--------------------------------------------------------------------------------------
// File: Tutorial07.fx
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//--------------------------------------------------------------------------------------

//--------------------------------------------------------------------------------------
// Constant Buffer Variables
//--------------------------------------------------------------------------------------
Texture2D txDiffuse : register( t0 );
SamplerState samLinear : register( s0 );

cbuffer cbNeverChanges : register( b0 )
{
    matrix View;
};

cbuffer cbChangeOnResize : register( b1 )
{
    matrix Projection;
};

cbuffer cbChangesEveryFrame : register( b2 )
{
    matrix World;
    float4 vMeshColor;
};


//--------------------------------------------------------------------------------------
struct VS_INPUT
{
    float4 Pos : POSITION;
    float2 Tex : TEXCOORD0;
    float3 normal : NORMAL;
    float3 tangent : TANGENT;

};

struct PS_INPUT
{
    float4 Pos : SV_POSITION;
    float2 Tex : TEXCOORD0;
    float3 normal : NORMAL;
    float3 tangent : TANGENT;

};


//--------------------------------------------------------------------------------------
// Vertex Shader
//--------------------------------------------------------------------------------------
PS_INPUT VS( VS_INPUT input )
{
    PS_INPUT output = (PS_INPUT)0;
    output.Pos = mul( input.Pos, World );
    output.Pos = mul( output.Pos, View );
    output.Pos = mul( output.Pos, Projection );
    output.Tex = input.Tex;
    output.normal = mul(input.normal, World);
    output.tangent = mul(input.tangent, World);

    return output;
}

float f(float4 col)
{
    return (col.x + col.y + col.z) / 3.0;
}

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 PS( PS_INPUT input) : SV_Target
{
    float2 t = input.Tex;
    float2 dx = float2(1.0 / 256.0, 0.0);
    float2 dy = float2(0.0, 1.0 / 256.0);
    float3 N;
    float scale = 12.0;
    N.x = scale * (f(txDiffuse.Sample(samLinear,t + dx)) - f(txDiffuse.Sample(samLinear,t - dx)));
    N.y = scale * (f(txDiffuse.Sample(samLinear,t + dy)) - f(txDiffuse.Sample(samLinear,t - dy)));
    N.z = 1.0;
    normalize(N);
    //Create the biTangent
    float3 biTangent = cross(input.normal, input.tangent);
    //Create the "Texture Space"
    float3x3 texSpace = float3x3(input.tangent, biTangent, input.normal);
    //Convert normal from normal map to texture space and store in input.normal
    float3 normal = normalize(mul(N, texSpace));
    float4 finalColor = txDiffuse.Sample(samLinear, t);
    finalColor = saturate(dot(float3(0.0, 0.0, -1.0), normal) * finalColor);
    return finalColor;

}
