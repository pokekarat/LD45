using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int		maxStars = 200;
	public float	starSize = 0.1f;
	public float	starSizeRange = 0.5f;
	public float	fWidth = 20f;
	public float	fHeight = 25f;
	public bool		colorize = false;
	
	float xOffset;
	float yOffset;
 
	ParticleSystem	Particles;
	ParticleSystem.Particle[] Stars;
	
 
	void Awake ()
	{
		Stars = new ParticleSystem.Particle[ maxStars ];
		Particles = GetComponent<ParticleSystem>();
 
		xOffset = fWidth * 0.5f;																										
		yOffset = fHeight * 0.5f;																										
		for ( int i=0; i<maxStars; i++ )
		{
			float rSize = Random.Range( starSizeRange, starSizeRange + 1f );						
			float scaledColor = 0;
            if( true == colorize ){
                scaledColor = rSize - starSizeRange;
            }else{
                scaledColor = 1f;
            }
 
			Stars[ i ].position = GetRandInRect(fWidth,fHeight ) + transform.position;
			Stars[ i ].startSize = starSize * rSize;
			Stars[ i ].startColor = new Color( 1f, scaledColor, scaledColor, 1f );
		}
		Particles.SetParticles( Stars, Stars.Length );  																
	}
 
	Vector3 GetRandInRect ( float width, float height )
	{
		float x = Random.Range( 0, width );
		float y = Random.Range( 0, height );
		return new Vector3 ( x - xOffset , y - yOffset, 0 );
	}
}
