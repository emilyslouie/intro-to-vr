using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputManager : MonoBehaviour
{
    private InputDevice _rightController;
    private InputDevice _leftController;

    [SerializeField]
    private GameObject _piplup;

    [SerializeField]
    private GameObject _safetyHat;

    [SerializeField]
    private Transform _rightControllerTransform;

    [SerializeField]
    private Transform _leftControllerTransform;

    enum ButtonState
    {
        ButtonUp,
        ButtonDown,
        OnButtonUp,
        OnButtonDown,
    }

    private ButtonState _rightPrimaryButtonState = ButtonState.ButtonUp;
    private ButtonState _leftPrimaryButtonState = ButtonState.ButtonUp;

    // Start is called before the first frame update
    void Start()
    {
        InitializeRightController();
        InitializeLeftController();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_rightController.isValid)
            InitializeRightController();
        if (!_leftController.isValid)
            InitializeLeftController();



        _rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool rightPrimaryButtonValue);

        switch (_rightPrimaryButtonState)
        {
            case ButtonState.ButtonUp:
                if (rightPrimaryButtonValue)
                    _rightPrimaryButtonState = ButtonState.OnButtonDown;
                break;
            case ButtonState.OnButtonDown:
                if (rightPrimaryButtonValue)
                    _rightPrimaryButtonState = ButtonState.ButtonDown;
                else
                    _rightPrimaryButtonState = ButtonState.OnButtonUp;
                break;
            case ButtonState.ButtonDown:
                if (!rightPrimaryButtonValue)
                    _rightPrimaryButtonState = ButtonState.OnButtonUp;
                break;
            case ButtonState.OnButtonUp:
                if (rightPrimaryButtonValue)
                    _rightPrimaryButtonState = ButtonState.OnButtonDown;
                else
                    _rightPrimaryButtonState = ButtonState.ButtonUp;
                break;
        }

        if (_rightPrimaryButtonState == ButtonState.OnButtonDown)
        {
            GameObject spawnedHat = Instantiate(_safetyHat);
            spawnedHat.transform.position = _rightControllerTransform.position;
        }

        _leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool leftPrimaryButtonValue);

        switch (_leftPrimaryButtonState)
        {
            case ButtonState.ButtonUp:
                if (leftPrimaryButtonValue)
                    _leftPrimaryButtonState = ButtonState.OnButtonDown;
                break;
            case ButtonState.OnButtonDown:
                if (leftPrimaryButtonValue)
                    _leftPrimaryButtonState = ButtonState.ButtonDown;
                else
                    _leftPrimaryButtonState = ButtonState.OnButtonUp;
                break;
            case ButtonState.ButtonDown:
                if (!leftPrimaryButtonValue)
                    _leftPrimaryButtonState = ButtonState.OnButtonUp;
                break;
            case ButtonState.OnButtonUp:
                if (leftPrimaryButtonValue)
                    _leftPrimaryButtonState = ButtonState.OnButtonDown;
                else
                    _leftPrimaryButtonState = ButtonState.ButtonUp;
                break;
        }

        if (_leftPrimaryButtonState == ButtonState.OnButtonDown)
        {
            GameObject spawnedPiplup = Instantiate(_piplup);
            spawnedPiplup.transform.position = _leftControllerTransform.position;

        }

    }

    private void InitializeRightController()
    {
        _rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    private void InitializeLeftController()
    {
        _leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }

}

