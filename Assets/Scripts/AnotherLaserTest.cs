﻿using UnityEngine;
using System.Collections;

public class AnotherLaserTest : MonoBehaviour {
	
	LineRenderer lineRenderer;
	
	void Awake () {
		lineRenderer = GetComponent<LineRenderer> ();
	}
	
	void Start(){
		
	}
	
	void Update () {
		Laser ();
	}
	
	void Laser(){
		RaycastHit hit;
		
		
		if(Physics.Raycast(transform.position,Vector3.forward,out hit,Mathf.Infinity)){
			
			//lineRenderer.enabled = true;         
			//lineRenderer.SetPosition(0, transform.position); 
			//lineRenderer.SetPosition(1, hit.point);   
			

				Vector3 pos = Vector3.Reflect (hit.point - this.transform.position, hit.normal);
				//lineRenderer.SetPosition(2,pos);
				//lineRenderer.SetPosition(3, pos);

		}
	}
}