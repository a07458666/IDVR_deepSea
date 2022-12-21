using UnityEngine;
using System.Collections;

public class SeaTurtleCharacter : MonoBehaviour {
	Animator seaTurtleAnimator;
	Rigidbody seaTurtleRigid;
	public bool isSwimming=true;
	
	public float maxForwardSpeed=30f;
	public float maxTurnSpeed=10f;
	public float maxUpDownSpeed=5f;

	public float forwardSpeed=0f;
	public float turnSpeed=0f;
	public float upDownSpeed=0f;

	public float forwardAcceleration=0f;
	public float turnAcceleration=0f;
	public float upDownAcceleration=0f;


	void Start () {
		seaTurtleRigid = GetComponent<Rigidbody> ();
		seaTurtleAnimator = GetComponent<Animator> ();
		if (isSwimming) {
			Swim();
		} else {
			UpFromWater();
		}
	}
	
	public void Attack(){
		seaTurtleAnimator.SetTrigger("Attack");
	}

	public void Hit(){
		seaTurtleAnimator.SetTrigger("Hit");
	}

	public void Eat(){
		seaTurtleAnimator.SetTrigger("Eat");
	}

	public void Death(){
		seaTurtleAnimator.SetTrigger("Death");
	}

	public void Rebirth(){
		seaTurtleAnimator.SetTrigger("Rebirth");
	}

	public void Swim(){
		seaTurtleAnimator.SetBool("IsSwimming",true);
		isSwimming = true;
		seaTurtleRigid.useGravity = false;
		seaTurtleAnimator.applyRootMotion = false;
	}

	public void UpFromWater(){
		seaTurtleAnimator.SetBool("IsSwimming",false);
		isSwimming = false;
		seaTurtleRigid.useGravity = true;
		seaTurtleAnimator.applyRootMotion = true;
	}
	
	void FixedUpdate(){
		Move ();
	}

	public void Move(){
		seaTurtleAnimator.SetFloat ("Forward", forwardSpeed);
		seaTurtleAnimator.SetFloat ("Turn", turnSpeed);
		forwardSpeed=Mathf.Clamp(forwardSpeed+forwardAcceleration*Time.deltaTime,-1f,maxForwardSpeed);
		turnSpeed=Mathf.Clamp(turnSpeed+turnAcceleration*Time.deltaTime,-maxTurnSpeed,maxTurnSpeed);
		if (forwardAcceleration == 0f) {
			forwardSpeed = Mathf.Lerp (forwardSpeed, 0, Time.deltaTime * 3f);
		}

		if (turnAcceleration == 0f) {
			turnSpeed = Mathf.Lerp (turnSpeed, 0, Time.deltaTime * 3f);
		}
		if (isSwimming){
			seaTurtleAnimator.SetFloat ("UpDown", upDownSpeed);

			if(upDownAcceleration==0f){
				upDownSpeed=Mathf.Lerp(upDownSpeed,0,Time.deltaTime*3f);
			}
			upDownSpeed=Mathf.Clamp(upDownSpeed+upDownAcceleration*Time.deltaTime,-maxUpDownSpeed,maxUpDownSpeed);
			transform.RotateAround(transform.position,transform.up,Time.deltaTime*turnSpeed*100f);
			seaTurtleRigid.velocity=(transform.up*upDownSpeed+transform.forward)*forwardSpeed;	
		}

	}
}
