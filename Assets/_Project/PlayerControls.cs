//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/_Project/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerTurret"",
            ""id"": ""ca507aac-edba-4a40-9b31-ff7299c59543"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1fa1ae40-fbe9-4a02-8df1-a18cb98685b3"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""4f6389e1-4fd2-4374-bcd2-88ff49a50aeb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Build"",
                    ""type"": ""Button"",
                    ""id"": ""049ed06c-816e-457a-b7e4-dfb35f243d81"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7009a182-8615-4e98-b551-483c625920df"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ee42ad4-acb5-4ae5-9bc9-5ef62f5ebdcf"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51e40f6e-4ec4-4da0-b5bd-9d60d99d75a0"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1722122c-db93-4d65-8fdb-4cf3b80b8b63"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": ""Hold"",
                    ""processors"": ""InvertVector2(invertX=false),StickDeadzone(min=0.1)"",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keys"",
                    ""id"": ""938ecf24-42c0-4630-9603-713e968272f7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ac870cc4-65a3-480e-8797-51a5f6e79e5c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3bbffeb6-c6f7-44e1-85a9-c10ec997c146"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0b282c6b-443d-4e8c-91ec-22ec38b81bcd"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0d937455-9e96-49a2-b87f-c8d2d1e6f656"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b83fe013-1938-4fc6-b454-845b8d213dea"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bec8d8db-0bfd-4d77-b8c7-6e6b35f33788"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""731c293a-d967-4036-b4f9-d6a0b4810e5d"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerTurret
        m_PlayerTurret = asset.FindActionMap("PlayerTurret", throwIfNotFound: true);
        m_PlayerTurret_Fire = m_PlayerTurret.FindAction("Fire", throwIfNotFound: true);
        m_PlayerTurret_Rotate = m_PlayerTurret.FindAction("Rotate", throwIfNotFound: true);
        m_PlayerTurret_Build = m_PlayerTurret.FindAction("Build", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerTurret
    private readonly InputActionMap m_PlayerTurret;
    private IPlayerTurretActions m_PlayerTurretActionsCallbackInterface;
    private readonly InputAction m_PlayerTurret_Fire;
    private readonly InputAction m_PlayerTurret_Rotate;
    private readonly InputAction m_PlayerTurret_Build;
    public struct PlayerTurretActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerTurretActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_PlayerTurret_Fire;
        public InputAction @Rotate => m_Wrapper.m_PlayerTurret_Rotate;
        public InputAction @Build => m_Wrapper.m_PlayerTurret_Build;
        public InputActionMap Get() { return m_Wrapper.m_PlayerTurret; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerTurretActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerTurretActions instance)
        {
            if (m_Wrapper.m_PlayerTurretActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_PlayerTurretActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerTurretActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerTurretActionsCallbackInterface.OnFire;
                @Rotate.started -= m_Wrapper.m_PlayerTurretActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerTurretActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerTurretActionsCallbackInterface.OnRotate;
                @Build.started -= m_Wrapper.m_PlayerTurretActionsCallbackInterface.OnBuild;
                @Build.performed -= m_Wrapper.m_PlayerTurretActionsCallbackInterface.OnBuild;
                @Build.canceled -= m_Wrapper.m_PlayerTurretActionsCallbackInterface.OnBuild;
            }
            m_Wrapper.m_PlayerTurretActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Build.started += instance.OnBuild;
                @Build.performed += instance.OnBuild;
                @Build.canceled += instance.OnBuild;
            }
        }
    }
    public PlayerTurretActions @PlayerTurret => new PlayerTurretActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface IPlayerTurretActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnBuild(InputAction.CallbackContext context);
    }
}
