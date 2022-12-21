using UnityEngine;
using System.Collections;

public class SeaTurtleUserController : MonoBehaviour {
	SeaTurtleCharacter seaTurtleCharacter;
	
	void Start () {
		seaTurtleCharacter = GetComponent < SeaTurtleCharacter> ();
	}

	void Update () {	
		if (Input.GetButtonDown ("Fire1")) {
			seaTurtleCharacter.Attack();
		}		
		if (Input.GetKeyDown (KeyCode.H)) {
			seaTurtleCharacter.Hit();
		}		
		if (Input.GetButtonDown ("Jump")) {
			seaTurtleCharacter.Swim ();
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			seaTurtleCharacter.Eat();
		}	
		if (Input.GetKeyDown (KeyCode.K)) {
			seaTurtleCharacter.Death();
		}	
		if (Input.GetKeyDown (KeyCode.R)) {
			seaTurtleCharacter.Rebirth();
		}	

		if (Input.GetKeyDown (KeyCode.L)) {
			seaTurtleCharacter.UpFromWater ();
		}
	}
	
	private void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		seaTurtleCharacter.forwardAcceleration = v;
		seaTurtleCharacter.turnAcceleration = h;

		if (Input.GetKeyDown (KeyCode.N)) {
			seaTurtleCharacter.upDownAcceleration=-1f;
		}
		if (Input.GetKeyDown (KeyCode.U)) {
			seaTurtleCharacter.upDownAcceleration=1f;
		}
		if (Input.GetKeyUp (KeyCode.N)) {
			seaTurtleCharacter.upDownAcceleration=0f;
		}
		if (Input.GetKeyUp (KeyCode.U)) {
			seaTurtleCharacter.upDownAcceleration=0f;
		}
	}
}
