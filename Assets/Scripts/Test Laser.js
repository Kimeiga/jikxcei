#pragma strict

function Start () {

}

function Update () {
drawLaser(transform.position, 4);

}

function drawLaser(startPoint:Vector3,n:int)  
{
    var hit : RaycastHit;
    var rayDir:Vector3 = transform.TransformDirection (Vector3.forward);
 
    for(var i = 0; i < n; i++)
    {     
        if (Physics.Raycast (startPoint, rayDir, hit, 1000)) 
        {
            Debug.DrawLine (startPoint, hit.point);
         rayDir = Vector3.Reflect( (hit.point - startPoint).normalized, hit.normal  ) ;
                startPoint = hit.point;
                print("lol");
        }
    }
}