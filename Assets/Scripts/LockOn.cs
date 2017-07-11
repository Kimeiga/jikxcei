using UnityEngine;
using System.Collections;

public class LockOn : MonoBehaviour {

	public Transform myCam;
	public Transform myBody;
	bool activated;
	public Transform aimArms;
	public MouseLook aimArmsScript;
	public MouseLook myCamScript;
	public MouseLook myBodyScript;
	Transform Enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	/*
		if(Input.GetButton("Fire2")){
			raycastActive = !raycastActive;

			if(raycastActive){
				if(activated == false){
					RaycastHit hit;
					if(Physics.Raycast(myCam.position, myCam.TransformDirection(Vector3.forward), out hit, 1000)){
						if(hit.collider.tag == "Enemy"){
							activated = true;
							Enemy = hit.transform;
						}
					}
				}
			}

			if(activated == true){
				activated = false;
				myCamScript.enabled = true;
				aimArmsScript.enabled = false;
				myBodyScript.enabled = true;
			}

		}

		if(activated){
			LockOnToEnemy(Enemy);
		}
*/

		if(Input.GetButtonDown("Fire2")){

			switch (activated){

			case true:
				activated = false;
				myCamScript.enabled = true;
				aimArmsScript.enabled = false;
				myBodyScript.enabled = true;
				aimArms.rotation= new Quaternion(0,0,0,0);
				myBody.rotation.Set(0,myBody.rotation.y,0,myBody.rotation.w);
				break;

			case false:
				RaycastHit hit;
				if(Physics.Raycast(myCam.position, myCam.TransformDirection(Vector3.forward), out hit, 1000)){
					if(hit.collider.tag == "Enemy"){
						activated = true;
						Enemy = hit.transform;
					}
				}
				break;

			}


			/*
			if(activated == true){
				activated = false;
				myCamScript.enabled = true;
				aimArmsScript.enabled = false;
				myBodyScript.enabled = true;
			}

			if(activated == false){
				RaycastHit hit;
				if(Physics.Raycast(myCam.position, myCam.TransformDirection(Vector3.forward), out hit, 1000)){
					if(hit.collider.tag == "Enemy"){
						activated = true;
						Enemy = hit.transform;
					}
				}
			}
			*/
		}

		if(activated){
			LockOnToEnemy (Enemy);
		}
	}

	void LockOnToEnemy( Transform enemy){
		myCamScript.enabled = false;
		myCam.LookAt(enemy);
		aimArmsScript.enabled = true;
		myBodyScript.enabled = false;
		myBody.LookAt(enemy);
	}
}
