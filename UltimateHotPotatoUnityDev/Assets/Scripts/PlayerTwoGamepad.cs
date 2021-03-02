// GENERATED AUTOMATICALLY FROM 'Assets/PlayerTwoGamepad.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerTwoGamepad : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerTwoGamepad()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerTwoGamepad"",
    ""maps"": [
        {
            ""name"": ""P2"",
            ""id"": ""652859c5-2a9b-458f-9828-0f5433f2ca43"",
            ""actions"": [
                {
                    ""name"": ""Pickup"",
                    ""type"": ""Button"",
                    ""id"": ""a9f5b464-c257-4bbf-944d-d4f9561e3b43"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8cb2cd61-51af-4dd5-b047-62f40cc50dd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""60e6edcd-f83a-4f71-99e5-46ffcc1bc817"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""04414288-d387-436e-a039-f27e78dbc46c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Respawn"",
                    ""type"": ""Button"",
                    ""id"": ""592d499b-47cb-428f-9387-a7011f1089be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""954d513b-5424-446c-9b22-16e366f8a4d0"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0081e68-04ef-4d8d-9d83-4c93385847e8"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f46a2f5-c63a-4139-9c1d-44f672b9feb5"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0abda04-ea21-4d5d-8c3a-c2f69d3af75d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7db3fa6-2d0d-49c1-b432-d57c7506cef7"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox Control Scheme"",
            ""bindingGroup"": ""Xbox Control Scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // P2
        m_P2 = asset.FindActionMap("P2", throwIfNotFound: true);
        m_P2_Pickup = m_P2.FindAction("Pickup", throwIfNotFound: true);
        m_P2_Jump = m_P2.FindAction("Jump", throwIfNotFound: true);
        m_P2_Movement = m_P2.FindAction("Movement", throwIfNotFound: true);
        m_P2_Camera = m_P2.FindAction("Camera", throwIfNotFound: true);
        m_P2_Respawn = m_P2.FindAction("Respawn", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // P2
    private readonly InputActionMap m_P2;
    private IP2Actions m_P2ActionsCallbackInterface;
    private readonly InputAction m_P2_Pickup;
    private readonly InputAction m_P2_Jump;
    private readonly InputAction m_P2_Movement;
    private readonly InputAction m_P2_Camera;
    private readonly InputAction m_P2_Respawn;
    public struct P2Actions
    {
        private @PlayerTwoGamepad m_Wrapper;
        public P2Actions(@PlayerTwoGamepad wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pickup => m_Wrapper.m_P2_Pickup;
        public InputAction @Jump => m_Wrapper.m_P2_Jump;
        public InputAction @Movement => m_Wrapper.m_P2_Movement;
        public InputAction @Camera => m_Wrapper.m_P2_Camera;
        public InputAction @Respawn => m_Wrapper.m_P2_Respawn;
        public InputActionMap Get() { return m_Wrapper.m_P2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(P2Actions set) { return set.Get(); }
        public void SetCallbacks(IP2Actions instance)
        {
            if (m_Wrapper.m_P2ActionsCallbackInterface != null)
            {
                @Pickup.started -= m_Wrapper.m_P2ActionsCallbackInterface.OnPickup;
                @Pickup.performed -= m_Wrapper.m_P2ActionsCallbackInterface.OnPickup;
                @Pickup.canceled -= m_Wrapper.m_P2ActionsCallbackInterface.OnPickup;
                @Jump.started -= m_Wrapper.m_P2ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_P2ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_P2ActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_P2ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_P2ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_P2ActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_P2ActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_P2ActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_P2ActionsCallbackInterface.OnCamera;
                @Respawn.started -= m_Wrapper.m_P2ActionsCallbackInterface.OnRespawn;
                @Respawn.performed -= m_Wrapper.m_P2ActionsCallbackInterface.OnRespawn;
                @Respawn.canceled -= m_Wrapper.m_P2ActionsCallbackInterface.OnRespawn;
            }
            m_Wrapper.m_P2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pickup.started += instance.OnPickup;
                @Pickup.performed += instance.OnPickup;
                @Pickup.canceled += instance.OnPickup;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @Respawn.started += instance.OnRespawn;
                @Respawn.performed += instance.OnRespawn;
                @Respawn.canceled += instance.OnRespawn;
            }
        }
    }
    public P2Actions @P2 => new P2Actions(this);
    private int m_XboxControlSchemeSchemeIndex = -1;
    public InputControlScheme XboxControlSchemeScheme
    {
        get
        {
            if (m_XboxControlSchemeSchemeIndex == -1) m_XboxControlSchemeSchemeIndex = asset.FindControlSchemeIndex("Xbox Control Scheme");
            return asset.controlSchemes[m_XboxControlSchemeSchemeIndex];
        }
    }
    public interface IP2Actions
    {
        void OnPickup(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnRespawn(InputAction.CallbackContext context);
    }
}
