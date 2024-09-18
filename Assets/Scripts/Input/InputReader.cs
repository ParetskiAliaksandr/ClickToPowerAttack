using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "NewInputSystem/InputReader", order = 51)]
public class InputReader : ScriptableObject, GameInputControls.IGameplayActions, GameInputControls.IUIActions
{
    private GameInputControls _gameInputControls;

    private void OnEnable()
    {
        if(_gameInputControls == null)
        {
            _gameInputControls = new GameInputControls();

            _gameInputControls.Enable();

            _gameInputControls.Gameplay.SetCallbacks(this);
            _gameInputControls.UI.SetCallbacks(this);

            SetGameplay();
        }
    }

    public void SetGameplay()
    {
        _gameInputControls.Gameplay.Enable();

        _gameInputControls.UI.Disable();
    }

    public void SetUI()
    {
        _gameInputControls.Gameplay.Disable();
        Debug.Log("GamePlay Disable");

        _gameInputControls.UI.Enable();
        Debug.Log("UiPause Enable");
    }

    public void OnTouch(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("tap");
        }
    }

    public void OnUITouch(InputAction.CallbackContext context)
    {
        
    }

    private void OnDisable()
    {
        _gameInputControls.Gameplay.RemoveCallbacks(this);
        _gameInputControls.UI.RemoveCallbacks(this);

        _gameInputControls.Disable();
    }

    
}
