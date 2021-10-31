//--------------------------------------------------------------------------------------
// File: Tutorial06.fx
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//--------------------------------------------------------------------------------------


//--------------------------------------------------------------------------------------
// Constant Buffer Variables
//--------------------------------------------------------------------------------------
cbuffer ConstantBuffer : register( b0 )
{
	matrix World;
	matrix View;
	matrix Projection;
	float4 vLightDir[2];
	float4 vLightColor[2];
	float4 vOutputColor;
}


//--------------------------------------------------------------------------------------
struct VS_INPUT
{
    float4 Pos : POSITION;
    float3 Norm : NORMAL;
};

struct PS_INPUT
{
    float4 Pos : SV_POSITION;
    float3 Norm : TEXCOORD0;
	float3 WorldPos : TEXCOORD1;
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
    output.Norm = mul( float4( input.Norm, 1 ), World ).xyz;
	output.WorldPos = mul(input.Pos, World);
    return output;
}


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 PS( PS_INPUT input) : SV_Target
{

	//float4 finalColor = 0;

	////do NdotL lighting for 2 lights
	//for(int i=0; i<2; i++)
	//{
	//    finalColor += saturate( dot( (float3)vLightDir[i],input.Norm) * vLightColor[i] );
	//}


	//finalColor.a = 1;
 //   return finalColor;
	float4 finalColor = 0;
	float3 Eye = float3(0.0f, 0.0f, 0.0f);

	finalColor += saturate(dot((float3)vLightDir[0],input.Norm) * vLightColor[0]);

	float power = 2;
	float3 V = normalize(Eye - input.WorldPos);
	float3 R = reflect(normalize(vLightDir[1]), normalize(input.Norm));
	finalColor += vLightColor[1] * pow(saturate(dot(R, V)), power);

	finalColor.a = 1;
	return finalColor;
}


//--------------------------------------------------------------------------------------
// PSSolid - render a solid color
//--------------------------------------------------------------------------------------
float4 PSSolid( PS_INPUT input) : SV_Target
{
    return vOutputColor;
}
