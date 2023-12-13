//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Core/Input/PlayerInputs.inputactions
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

public partial class @PlayerInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""86c133bd-27a9-4f01-913e-fafc76c9dcc4"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8eccadf8-fc50-45be-b10c-7b43ff75dd0d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""d15b0da8-7c62-4a11-946c-3f93a133dfe0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mouse1 Pressed"",
                    ""type"": ""Button"",
                    ""id"": ""44e10e22-a8a1-444c-8669-3475ad82ad5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mouse2 Pressed"",
                    ""type"": ""Button"",
                    ""id"": ""6c9dc40b-13cb-4f0b-a193-c4e2555272f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mouse3 Pressed"",
                    ""type"": ""Button"",
                    ""id"": ""56b2491b-a551-4b0e-a5ab-e0c1130534df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mouse3 Scroll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1471ea42-b403-433d-bfb2-a45b14f661de"",
                    ""expectedControlType"": ""Delta"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""6e963acc-f693-42f3-a75b-af350d4b7ac0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Time Pause"",
                    ""type"": ""Button"",
                    ""id"": ""6ab4157f-2e83-4c8e-b2a8-07ad424a0b9b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Time 1 Speed"",
                    ""type"": ""Button"",
                    ""id"": ""8ef4905b-f00d-4d34-a044-21a5ee998a58"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Time 2 Speed"",
                    ""type"": ""Button"",
                    ""id"": ""7de8bf33-d177-41e3-9eb9-d80424bb7add"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Time 3 Speed"",
                    ""type"": ""Button"",
                    ""id"": ""85d21560-0b49-436d-a071-60f2830e4e0f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleTimePause"",
                    ""type"": ""Button"",
                    ""id"": ""34dcfe42-2200-4a25-823b-e2550828d4cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseMove"",
                    ""type"": ""Button"",
                    ""id"": ""21a3ea35-b837-469f-9ea9-4d9026d37809"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD Move"",
                    ""id"": ""fe027404-7def-4d8c-a42f-0a4e14098c9f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3ca77ea1-4cc4-4db2-9de6-835ddf97e969"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b2d6efe7-2bd0-4c37-8ddb-d1b92136f6eb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""376bd36c-cba3-4ebf-b104-f37e2278bbe3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7a5eb855-89cd-4288-9f57-48f7c5616bc6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f0802889-4e8a-42c0-bbee-5811367fb546"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse1 Pressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffec333e-b733-465d-9e30-0be8324011cb"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse2 Pressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf6fcacd-69fd-4a42-af75-75591ede4d83"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse3 Pressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17afde31-caf7-468e-a745-f01632b68f0f"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse3 Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85bb6afb-4943-4df3-a4a1-f86ad41bfe67"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e8691a9-e63a-4c50-a608-7aa180a6b332"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Time Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32dd7e22-354a-40ba-b181-7491778bdbca"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Time 1 Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e35a1874-36f3-4307-b47f-d0228e756b78"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Time 2 Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed652bee-e443-4582-9372-e98903aeea7d"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Time 3 Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d16f74cc-f78b-4430-aa64-305c7a5f009e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleTimePause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""id"": ""f8375626-7ba9-4d72-b2a4-6d1d0a6c0a11"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ae8c74d3-85ea-4e6c-b123-d69dac6a10cc"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a4b1b842-6104-48cf-bada-c08ab4fc9ab1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""MouseMove"",
                    ""id"": ""97d6e211-d614-4675-8f3d-423638b50ca3"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""8b4c2ae6-25e6-4d1d-a13f-2fc1909c7e3f"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""5cecd0b6-99ff-4705-9cf5-5fd3f8b42407"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Move = m_PlayerControls.FindAction("Move", throwIfNotFound: true);
        m_PlayerControls_Rotate = m_PlayerControls.FindAction("Rotate", throwIfNotFound: true);
        m_PlayerControls_Mouse1Pressed = m_PlayerControls.FindAction("Mouse1 Pressed", throwIfNotFound: true);
        m_PlayerControls_Mouse2Pressed = m_PlayerControls.FindAction("Mouse2 Pressed", throwIfNotFound: true);
        m_PlayerControls_Mouse3Pressed = m_PlayerControls.FindAction("Mouse3 Pressed", throwIfNotFound: true);
        m_PlayerControls_Mouse3Scroll = m_PlayerControls.FindAction("Mouse3 Scroll", throwIfNotFound: true);
        m_PlayerControls_Menu = m_PlayerControls.FindAction("Menu", throwIfNotFound: true);
        m_PlayerControls_TimePause = m_PlayerControls.FindAction("Time Pause", throwIfNotFound: true);
        m_PlayerControls_Time1Speed = m_PlayerControls.FindAction("Time 1 Speed", throwIfNotFound: true);
        m_PlayerControls_Time2Speed = m_PlayerControls.FindAction("Time 2 Speed", throwIfNotFound: true);
        m_PlayerControls_Time3Speed = m_PlayerControls.FindAction("Time 3 Speed", throwIfNotFound: true);
        m_PlayerControls_ToggleTimePause = m_PlayerControls.FindAction("ToggleTimePause", throwIfNotFound: true);
        m_PlayerControls_MouseMove = m_PlayerControls.FindAction("MouseMove", throwIfNotFound: true);
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

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private List<IPlayerControlsActions> m_PlayerControlsActionsCallbackInterfaces = new List<IPlayerControlsActions>();
    private readonly InputAction m_PlayerControls_Move;
    private readonly InputAction m_PlayerControls_Rotate;
    private readonly InputAction m_PlayerControls_Mouse1Pressed;
    private readonly InputAction m_PlayerControls_Mouse2Pressed;
    private readonly InputAction m_PlayerControls_Mouse3Pressed;
    private readonly InputAction m_PlayerControls_Mouse3Scroll;
    private readonly InputAction m_PlayerControls_Menu;
    private readonly InputAction m_PlayerControls_TimePause;
    private readonly InputAction m_PlayerControls_Time1Speed;
    private readonly InputAction m_PlayerControls_Time2Speed;
    private readonly InputAction m_PlayerControls_Time3Speed;
    private readonly InputAction m_PlayerControls_ToggleTimePause;
    private readonly InputAction m_PlayerControls_MouseMove;
    public struct PlayerControlsActions
    {
        private @PlayerInputs m_Wrapper;
        public PlayerControlsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControls_Move;
        public InputAction @Rotate => m_Wrapper.m_PlayerControls_Rotate;
        public InputAction @Mouse1Pressed => m_Wrapper.m_PlayerControls_Mouse1Pressed;
        public InputAction @Mouse2Pressed => m_Wrapper.m_PlayerControls_Mouse2Pressed;
        public InputAction @Mouse3Pressed => m_Wrapper.m_PlayerControls_Mouse3Pressed;
        public InputAction @Mouse3Scroll => m_Wrapper.m_PlayerControls_Mouse3Scroll;
        public InputAction @Menu => m_Wrapper.m_PlayerControls_Menu;
        public InputAction @TimePause => m_Wrapper.m_PlayerControls_TimePause;
        public InputAction @Time1Speed => m_Wrapper.m_PlayerControls_Time1Speed;
        public InputAction @Time2Speed => m_Wrapper.m_PlayerControls_Time2Speed;
        public InputAction @Time3Speed => m_Wrapper.m_PlayerControls_Time3Speed;
        public InputAction @ToggleTimePause => m_Wrapper.m_PlayerControls_ToggleTimePause;
        public InputAction @MouseMove => m_Wrapper.m_PlayerControls_MouseMove;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
            @Mouse1Pressed.started += instance.OnMouse1Pressed;
            @Mouse1Pressed.performed += instance.OnMouse1Pressed;
            @Mouse1Pressed.canceled += instance.OnMouse1Pressed;
            @Mouse2Pressed.started += instance.OnMouse2Pressed;
            @Mouse2Pressed.performed += instance.OnMouse2Pressed;
            @Mouse2Pressed.canceled += instance.OnMouse2Pressed;
            @Mouse3Pressed.started += instance.OnMouse3Pressed;
            @Mouse3Pressed.performed += instance.OnMouse3Pressed;
            @Mouse3Pressed.canceled += instance.OnMouse3Pressed;
            @Mouse3Scroll.started += instance.OnMouse3Scroll;
            @Mouse3Scroll.performed += instance.OnMouse3Scroll;
            @Mouse3Scroll.canceled += instance.OnMouse3Scroll;
            @Menu.started += instance.OnMenu;
            @Menu.performed += instance.OnMenu;
            @Menu.canceled += instance.OnMenu;
            @TimePause.started += instance.OnTimePause;
            @TimePause.performed += instance.OnTimePause;
            @TimePause.canceled += instance.OnTimePause;
            @Time1Speed.started += instance.OnTime1Speed;
            @Time1Speed.performed += instance.OnTime1Speed;
            @Time1Speed.canceled += instance.OnTime1Speed;
            @Time2Speed.started += instance.OnTime2Speed;
            @Time2Speed.performed += instance.OnTime2Speed;
            @Time2Speed.canceled += instance.OnTime2Speed;
            @Time3Speed.started += instance.OnTime3Speed;
            @Time3Speed.performed += instance.OnTime3Speed;
            @Time3Speed.canceled += instance.OnTime3Speed;
            @ToggleTimePause.started += instance.OnToggleTimePause;
            @ToggleTimePause.performed += instance.OnToggleTimePause;
            @ToggleTimePause.canceled += instance.OnToggleTimePause;
            @MouseMove.started += instance.OnMouseMove;
            @MouseMove.performed += instance.OnMouseMove;
            @MouseMove.canceled += instance.OnMouseMove;
        }

        private void UnregisterCallbacks(IPlayerControlsActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
            @Mouse1Pressed.started -= instance.OnMouse1Pressed;
            @Mouse1Pressed.performed -= instance.OnMouse1Pressed;
            @Mouse1Pressed.canceled -= instance.OnMouse1Pressed;
            @Mouse2Pressed.started -= instance.OnMouse2Pressed;
            @Mouse2Pressed.performed -= instance.OnMouse2Pressed;
            @Mouse2Pressed.canceled -= instance.OnMouse2Pressed;
            @Mouse3Pressed.started -= instance.OnMouse3Pressed;
            @Mouse3Pressed.performed -= instance.OnMouse3Pressed;
            @Mouse3Pressed.canceled -= instance.OnMouse3Pressed;
            @Mouse3Scroll.started -= instance.OnMouse3Scroll;
            @Mouse3Scroll.performed -= instance.OnMouse3Scroll;
            @Mouse3Scroll.canceled -= instance.OnMouse3Scroll;
            @Menu.started -= instance.OnMenu;
            @Menu.performed -= instance.OnMenu;
            @Menu.canceled -= instance.OnMenu;
            @TimePause.started -= instance.OnTimePause;
            @TimePause.performed -= instance.OnTimePause;
            @TimePause.canceled -= instance.OnTimePause;
            @Time1Speed.started -= instance.OnTime1Speed;
            @Time1Speed.performed -= instance.OnTime1Speed;
            @Time1Speed.canceled -= instance.OnTime1Speed;
            @Time2Speed.started -= instance.OnTime2Speed;
            @Time2Speed.performed -= instance.OnTime2Speed;
            @Time2Speed.canceled -= instance.OnTime2Speed;
            @Time3Speed.started -= instance.OnTime3Speed;
            @Time3Speed.performed -= instance.OnTime3Speed;
            @Time3Speed.canceled -= instance.OnTime3Speed;
            @ToggleTimePause.started -= instance.OnToggleTimePause;
            @ToggleTimePause.performed -= instance.OnToggleTimePause;
            @ToggleTimePause.canceled -= instance.OnToggleTimePause;
            @MouseMove.started -= instance.OnMouseMove;
            @MouseMove.performed -= instance.OnMouseMove;
            @MouseMove.canceled -= instance.OnMouseMove;
        }

        public void RemoveCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnMouse1Pressed(InputAction.CallbackContext context);
        void OnMouse2Pressed(InputAction.CallbackContext context);
        void OnMouse3Pressed(InputAction.CallbackContext context);
        void OnMouse3Scroll(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnTimePause(InputAction.CallbackContext context);
        void OnTime1Speed(InputAction.CallbackContext context);
        void OnTime2Speed(InputAction.CallbackContext context);
        void OnTime3Speed(InputAction.CallbackContext context);
        void OnToggleTimePause(InputAction.CallbackContext context);
        void OnMouseMove(InputAction.CallbackContext context);
    }
}
