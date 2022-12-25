using UnityEngine;

public class Plesio : Creature
{
	public Transform Root,Spine0,Spine1,Spine2,Spine3,Neck0,Neck1,Neck2,Neck3,Neck4,Neck5,Neck6,Neck7,Neck8,Neck9,Neck10,Neck11,Tail0,Tail1,Tail2,Tail3,Tail4;
  public AudioClip Waterflush,Hit_jaw,Hit_head,Hit_tail,Slip,Bite,Swallow,Largesplash,Plesio1,Plesio2,Plesio3;

	//*************************************************************************************************************************************************
	//Play sound
	void OnCollisionStay(Collision col)
	{
		int rndPainsnd=Random.Range(0, 3); AudioClip painSnd=null;
		switch (rndPainsnd) { case 0: painSnd=Plesio1; break; case 1: painSnd=Plesio2; break; case 2: painSnd=Plesio3; break; }
		ManageCollision(col, source, painSnd, Hit_jaw, Hit_head, Hit_tail);
	}
	void PlaySound(string name, int time)
	{
		if(time==currframe && lastframe!=currframe)
		{
			switch (name)
			{
			case "Swim": source[1].pitch=Random.Range(0.75f, 1.0f);
				if(isOnWater && isOnGround) source[1].PlayOneShot(Largesplash, 0.1f);
				else if(isOnGround && !isInWater) source[1].PlayOneShot(Slip, 0.1f);
				else if(isOnWater) source[1].PlayOneShot(Waterflush,  0.1f);
				lastframe=currframe; break;
			case "Bite": source[1].pitch=Random.Range(0.25f, 0.5f); source[1].PlayOneShot(Bite, 0.5f);
				lastframe=currframe; break;
			case "Growl": int rnd=Random.Range(0, 3); source[0].pitch=Random.Range(0.5f, 0.75f);
				if(rnd==0) source[0].PlayOneShot(Plesio1, 0.5f);
        else if(rnd==1) source[0].PlayOneShot(Plesio2, 0.5f);
				else source[0].PlayOneShot(Plesio3, 0.5f);
				lastframe=currframe; break;
			case "Food": source[0].pitch=Random.Range(0.5f, 0.75f); source[0].PlayOneShot(Swallow, 0.25f);
				lastframe=currframe; break;
			case "Die":rnd=Random.Range(0, 3); source[0].pitch=Random.Range(0.5f, 0.75f);
				if(rnd==0) source[0].PlayOneShot(Plesio1, 0.5f);
        else if(rnd==1) source[0].PlayOneShot(Plesio2, 0.5f);
				else source[0].PlayOneShot(Plesio3, 0.5f);
				lastframe=currframe; isDead=true; break;
			}
		}
	}

	//*************************************************************************************************************************************************
	// Add forces to the Rigidbody
	void FixedUpdate ()
	{
		StatusUpdate(); if(!isActive | animSpeed==0.0f) { body.Sleep(); return; }
		onJump=false; onAttack=false; isOnLevitation=false; isConstrained=false; onReset=false;
		Vector3 dir=-Neck0.up;

		if(useAI && health!=0) { AICore(1, 2, 0, 0, 3, 0, 0); }// CPU
		else if(health!=0) { GetUserInputs(1, 2, 0, 0, 3, 0, 0); }// Human
		else { anm.SetBool("Attack", false); anm.SetInteger ("Move", 0); anm.SetInteger ("Idle", -1); }//Dead

    //Set Y position
		if(isInWater)
		{
      body.drag=1; body.angularDrag=1; 
      if(health!=0)
			{
        anm.SetBool("OnGround", false);
			  pitch=Mathf.Lerp(pitch, anm.GetFloat("Pitch")*90f, ang_T);
			  if(anm.GetInteger("Move").Equals(-1)) Move(-dir,40);
        else if(anm.GetInteger("Move").Equals(1)) Move(dir,40);
				else if(anm.GetInteger("Move").Equals(10)) Move(Head.right.normalized,20);
				else if(anm.GetInteger("Move").Equals(-10)) Move(-Head.right.normalized,20);
				else if(!anm.GetInteger("Move").Equals(0)) Move(dir, 100);
        else Move(Vector3.zero);
        isOnLevitation=true;
			}
      if(isOnWater) ApplyGravity();
		}
		else if(isOnGround) { body.drag=4; body.angularDrag=4; anm.SetBool("OnGround", true); ApplyYPos(); }
    else
    {
      if(health!=0) { Move(Vector3.zero); pitch=Mathf.Lerp(pitch, anm.GetFloat("Pitch")*90f, ang_T); }
      onJump=true; body.drag=1; body.angularDrag=1; ApplyGravity();
    }

		//Dead
		if(OnAnm.IsName("Plesio|Die") | OnAnm.IsName("Plesio|DieOnGround"))
		{
			onReset=true; if(!isDead) PlaySound("Die", 2);
		}

		//Forward
		else if(OnAnm.IsName("Plesio|Swim") | OnAnm.IsName("Plesio|SwimGlide"))
		{
			PlaySound("Swim", (int) currframe);
		}

		//Backward/Strafe
		else if(OnAnm.IsName("Plesio|Swim-"))
		{
			PlaySound("Swim", (int) currframe);
		}

		//Running
		else if(OnAnm.IsName("Plesio|SwimFast") )
		{
			PlaySound("Swim",  (int) currframe);
		}

		//Impulse
		else if(OnAnm.IsName("Plesio|SwimGrowl") | OnAnm.IsName("Plesio|SwimFastGrowl"))
		{
			PlaySound("Growl", 3);
			PlaySound("Swim",  (int) currframe);
		}

		//Attack
		else if(OnAnm.IsName("Plesio|SwimFastAtk") | OnAnm.IsName("Plesio|SwimAtk"))
		{
			if(OnAnm.IsName("Plesio|SwimFastAtk")) { PlaySound("Growl", 3);  PlaySound("Bite", 11); onAttack=true; }
			else { PlaySound("Growl", 3); PlaySound("Bite", 12); onAttack=true; }
			PlaySound("Swim",  (int) currframe);
		}

		//On Ground
		else if(OnAnm.IsName("Plesio|OnGround"))
		{
			 if(OnAnm.normalizedTime> 0.4f && OnAnm.normalizedTime< 0.9f)  Move(transform.forward, 60); else  Move(Vector3.zero);
			 PlaySound("Swim", 5); PlaySound("Swim", 10);
		}

		//Various
		else if(OnAnm.IsName("Plesio|EatA")) { onReset=true; isConstrained=true; PlaySound("Food", 2); }
    else if(OnAnm.IsName("Plesio|IdleC")) PlaySound("Growl", 2);
		else if(OnAnm.IsName("Plesio|Die-")) { PlaySound("Growl", 2); isDead=false; }

    RotateBone(IkType.None, 32f, 16f, false);
	}

  //*************************************************************************************************************************************************
	// Bone rotation
	void LateUpdate()
	{
		if(!isActive) return; headPos=Head.GetChild(0).GetChild(0).position;
    Root.rotation*= Quaternion.Euler(Mathf.Clamp(-pitch, -90f, 90f), 0, 0);
		Neck0.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Neck1.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Neck2.rotation*= Quaternion.Euler(spineY, 0, spineX);
    Neck3.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Neck4.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Neck5.rotation*= Quaternion.Euler(spineY, 0, spineX);
    Neck6.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Neck7.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Neck8.rotation*= Quaternion.Euler(spineY, 0, spineX);
    Neck9.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Neck10.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Neck11.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Head.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Spine0.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Spine1.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Spine2.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Spine3.rotation*= Quaternion.Euler(spineY, 0, spineX);
		Tail0.rotation*= Quaternion.Euler(-spineY, 0, -spineX);
		Tail1.rotation*= Quaternion.Euler(-spineY, 0, -spineX);
		Tail2.rotation*= Quaternion.Euler(-spineY, 0, -spineX);
		Tail3.rotation*= Quaternion.Euler(-spineY, 0, -spineX);
		Tail4.rotation*= Quaternion.Euler(-spineY, 0, -spineX);
		if(!isDead) Head.GetChild(0).transform.rotation*=Quaternion.Euler(-lastHit, 0, 0);
		//Check for ground layer
		GetGroundPos(IkType.None);
	}
}



