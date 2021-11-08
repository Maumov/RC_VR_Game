using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string BRAKE = "Jump";
    private const string RESET = "Reset";
    private const string SHOOT = "Fire1";

    public float horizontalInput;
    public float verticalInput;
    public bool isBreaking;
    public bool Reset;
    public bool Shoot;


    CarController carController;
    public bool isVR = false;
    // Start is called before the first frame update
    void Start()
    {
        carController = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isVR) {
            VR();
        } else {
            Keyboard();
        }

        carController.SetHorizontalInput(horizontalInput);
        carController.SetVerticalInput(verticalInput);
        carController.SetIsBreaking(isBreaking);

        if(Reset) {
            carController.ResetCar();
        }
         
        if(Shoot) {
            carController.Shoot();
        }
    }

    void Keyboard() {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetButton(BRAKE);
        Reset = Input.GetButton(RESET);
        Shoot = Input.GetButton(SHOOT);

    }



    void VR() {
        OVRInput.Update();
        horizontalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
        //verticalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
        verticalInput = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) - OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        //isBreaking = ;
        isBreaking = OVRInput.Get(OVRInput.Button.One);
        Reset = OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.LHand);
        Shoot = OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RHand);
        
    }
}
