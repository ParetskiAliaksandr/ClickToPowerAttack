using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "NewInputSystem/InputReader", order = 51)]
public class InputReader : DescriptionBaseSO, GameInputControls.IGameplayActions, GameInputControls.IUIActions
{
    private GameInputControls _gameInputControls;

    public event Action<Vector2> onTouchEvent;

    private void OnEnable()
    {
        if(_gameInputControls == null)
        {
            _gameInputControls = new GameInputControls();

            _gameInputControls.Enable();
            _gameInputControls.UI.Enable();
            _gameInputControls.Gameplay.Enable();

            _gameInputControls.Gameplay.SetCallbacks(this);
            _gameInputControls.UI.SetCallbacks(this);
        }
    }

    public void EnableGameplayActionMap()
    {
        _gameInputControls.Gameplay.Enable();
        Debug.Log("GamePlayMap Enable");
    }

    public void DisableGameplayActionMap()
    {
        _gameInputControls.Gameplay.Disable();
        Debug.Log("GamePlayMap Disable");
    }

    //Gameplay
    public void OnPositionTouch(InputAction.CallbackContext context)
    {
        
    }

    public void OnTouch(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            onTouchEvent?.Invoke(_gameInputControls.Gameplay.PositionTouch.ReadValue<Vector2>());
        }
    }

    //UI
    public void OnUITouch(InputAction.CallbackContext context)
    {
        
    }

    private void OnDisable()
    {
        _gameInputControls.Gameplay.RemoveCallbacks(this);
        _gameInputControls.UI.RemoveCallbacks(this);

        _gameInputControls.UI.Disable();
        _gameInputControls.Gameplay.Disable();

        _gameInputControls.Disable();
    }
}
