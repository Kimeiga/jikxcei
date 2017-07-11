using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	//First Raycast

	RaycastHit hit1;
	Vector3 rayDir1;
	Vector3 startPoint1;
	Ray ray1;

	//Second Raycast
	
	RaycastHit hit2;
	Vector3 rayDir2;
	Vector3 startPoint2;
	Ray ray2;

	//Third Raycast
	
	RaycastHit hit3;
	Vector3 rayDir3;
	Vector3 startPoint3;
	Ray ray3;

	//Line Renderers

	public LineRenderer line1;
	public LineRenderer line2;
	public LineRenderer line3;

	//First Laser Start

	public Transform laserStart;

	//Colors

	public Color c1 = Color.red;
	public Color c2 = Color.red;
	public Color c3 = Color.red;
	public Color c4 = Color.red;

	// Use this for initialization
	void Start () {
		
		line1.SetColors(c1, c2);
		line1.SetWidth(0.05F, 0.05F);
		line1.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(1, 1, 1, 0.3f));
		
		line2.SetColors(c2, c3);
		line2.SetWidth(0.05f, 0.05f);
		line2.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(1, 1, 1, 0.3f));

		line3.SetColors(c3, c4);
		line3.SetWidth(0.05f, 0.05f);
		line3.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(1, 1, 1, 0.3f));


		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		startPoint1 = transform.position;
		rayDir1 = transform.TransformDirection(Vector3.forward);

			StartCoroutine("FireLaser");
		

	}

	/*
	void DrawLaser() {

		if(Physics.Raycast(startPoint1, rayDir1, out hit1, 1000)){
			Debug.DrawLine(startPoint1, hit1.point);
			rayDir2 = Vector3.Reflect( (hit1.point - startPoint1).normalized, hit1.normal);
			startPoint2 = hit1.point;

			ray1 = new Ray(laserStart.position, rayDir1);
			
			line1.SetPosition(0, ray1.origin);
			line1.SetPosition(1, ray1.GetPoint(1000));

			if(hit1.transform != null){

				ray1 = new Ray(laserStart.position, rayDir1);

				line1.SetPosition(0, ray1.origin);
				line1.SetPosition(1, ray1.GetPoint(hit1.distance));


				if(Physics.Raycast(startPoint2, rayDir2, out hit2, 1000)){
					Debug.DrawLine(startPoint2, hit2.point);
					rayDir3 = Vector3.Reflect( (hit2.point - startPoint2).normalized, hit2.normal);
					startPoint3 = hit2.point;

					ray2 = new Ray(startPoint2, rayDir2);
					
					line2.SetPosition(0, ray2.origin);
					line2.SetPosition(1, ray2.GetPoint(hit2.distance));
					
					if(Physics.Raycast(startPoint3, rayDir3, out hit3, 1000)){
						Debug.DrawLine(startPoint3, hit3.point);
						rayDir4 = Vector3.Reflect( (hit3.point - startPoint3).normalized, hit3.normal);
						startPoint4 = hit3.point;

						ray3 = new Ray(startPoint3, rayDir3);
						
						line3.SetPosition(0, ray3.origin);
						line3.SetPosition(1, ray3.GetPoint(hit3.distance));
						
						if(Physics.Raycast(startPoint4, rayDir4, out hit4, 1000)){
							Debug.DrawLine(startPoint4, hit4.point);

							ray4 = new Ray(startPoint4, rayDir4);
							
							line4.SetPosition(0, ray4.origin);
							line4.SetPosition(1, ray4.GetPoint(hit4.distance));
						}
					}
				}
			}
		}
	}
	*/

	IEnumerator FireLaser(){
		line1.enabled = true;


		line2.enabled = false;
		line3.enabled = false;

		line1.SetPosition(0, laserStart.position);
		ray1 = new Ray(startPoint1,rayDir1);


			if(Physics.Raycast(ray1, out hit1, 1000)){
				line1.SetPosition(1, hit1.point);

				//Setting up next Raycast
				line2.enabled = true;
				line2.SetPosition(0, hit1.point);
				rayDir2 = Vector3.Reflect( (hit1.point - startPoint1).normalized, hit1.normal);
				startPoint2 = hit1.point;
				ray2 = new Ray(startPoint2, rayDir2);

				if(Physics.Raycast (ray2, out hit2, 1000)){
					line2.SetPosition(1, hit2.point);

					//Setting up next Raycast

					//print ("LOL");

					line3.enabled = true;
					line3.SetPosition(0, hit2.point);
					rayDir3 = Vector3.Reflect( (hit2.point - startPoint2).normalized, hit2.normal);
					startPoint3 = hit2.point;
					ray3 = new Ray(startPoint3, rayDir3);

					if(Physics.Raycast (ray3, out hit3, 1000)){
						line3.SetPosition(1, hit3.point);
						
						//Setting up next Raycast



					}else{
						line3.SetPosition(1, ray3.GetPoint(1000));
					}

				}else{
					line2.SetPosition(1, ray2.GetPoint(1000));
				}

			}else{
				line1.SetPosition(1, ray1.GetPoint(1000));
			}

			yield return null;
	



	}

}
