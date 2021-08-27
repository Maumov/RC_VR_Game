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

    CarController carController;

    // Start is called before the first frame update
    void Start()
    {
        carController = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
           
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetButton(BRAKE);

        carController.SetHorizontalInput(horizontalInput);
        carController.SetVerticalInput(verticalInput);
        carController.SetIsBreaking(isBreaking);
        if(Input.GetButton(RESET))
        carController.ResetCar();
        if(Input.GetButton(SHOOT))
        carController.Shoot();

    }
}
