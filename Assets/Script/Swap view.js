#pragma strict

var FPScamera : Camera;
var TPScamera : Camera;
var menuCamera : Camera;
public var player : GameObject;

private var SwitchCamera : boolean = false;
private var isActive : boolean = false;

var myScript;

function Start ()
{
  TPScamera.GetComponent("FlyCamScript").active = false;
  player.active = true;
  FPScamera.camera.enabled = true;
  TPScamera.camera.enabled = false;
  menuCamera.camera.enabled = false;
  menuCamera.transform.GetChild(0).GetChild(0).active = false;

}

function Update ()
{
   if(Input.GetKeyDown("j")){
   SwitchCamera = !SwitchCamera;
   }
   
   if ( Input.GetKeyDown("escape")){
   		isActive = !isActive;
   }
   
   if(SwitchCamera == true){
   TPScamera.GetComponent("FlyCamScript").active = true;
   menuCamera.transform.GetChild(0).GetChild(0).active = false;
   player.active = false;
   FPScamera.camera.enabled = false;
   TPScamera.camera.enabled = true;
   menuCamera.camera.enabled = false;
   }
   else
   {
   TPScamera.GetComponent("FlyCamScript").active = false;
   menuCamera.transform.GetChild(0).GetChild(0).active = false;
   player.active = true;
   FPScamera.camera.enabled = true;
   TPScamera.camera.enabled = false;
   menuCamera.camera.enabled = false;
   }
   
   if ( isActive == true) {
    menuCamera.transform.GetChild(0).GetChild(0).active = true;
   	menuCamera.camera.enabled = true;
   	FPScamera.camera.enabled = false;
   	TPScamera.camera.enabled = false;
   	player.active = false;
   }
}

function SetIsActiveFalse(){
	this.isActive = false;
}