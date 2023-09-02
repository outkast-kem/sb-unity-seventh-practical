using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedComponent : MonoBehaviour
{
    [SerializeField] GameStateButtonViewComponent pauseButton;
    [SerializeField] GameStateButtonViewComponent slowButton;
    [SerializeField] GameStateButtonViewComponent normalButton;
    [SerializeField] GameStateButtonViewComponent fastButton;

    private GameSpeedState _currentGameSpeed;

    private Dictionary<GameSpeedState, GameStateButtonViewComponent> _buttonsDictionary;

    private void Start()
    {
        _buttonsDictionary = new Dictionary<GameSpeedState, GameStateButtonViewComponent>
        {
            [GameSpeedState.Pause] = pauseButton,
            [GameSpeedState.Fast] = fastButton,
            [GameSpeedState.Normal] = normalButton,
            [GameSpeedState.Slow] = slowButton
        };

        SetGameSpeedState(GameSpeedState.Normal);
    }

    /// <summary>
    /// Текущее состояние скорости игры
    /// </summary>
    public GameSpeedState CurrentState => _currentGameSpeed;

    /// <summary>
    /// Устанавливает скорость игры на <see cref="GameSpeedState.Pause"/>
    /// </summary>
    public void SetPause() => SetGameSpeedState(GameSpeedState.Pause);

    /// <summary>
    /// Устанавливает скорость игры на <see cref="GameSpeedState.Slow"/>
    /// </summary>
    public void SetSlow() => SetGameSpeedState(GameSpeedState.Slow);

    /// <summary>
    /// Устанавливает скорость игры на <see cref="GameSpeedState.Normal"/>
    /// </summary>
    public void SetNormal() => SetGameSpeedState(GameSpeedState.Normal);

    /// <summary>
    /// Устанавливает скорость игры на <see cref="GameSpeedState.Fast"/>
    /// </summary>
    public void SetFast() => SetGameSpeedState(GameSpeedState.Fast);

    /// <summary>
    /// Устанавливает переданную скорость игры
    /// </summary>
    private void SetGameSpeedState(GameSpeedState state)
    {
        if (_currentGameSpeed == state)
            return;

        var previousGameSpeedState = _currentGameSpeed;

        _currentGameSpeed = state;
        Time.timeScale = GetSpeedModificator();

        var previousGameSpeedButton = _buttonsDictionary[previousGameSpeedState];
        var currentGameSpeedButton = _buttonsDictionary[_currentGameSpeed];

        previousGameSpeedButton.SetDisabled();
        currentGameSpeedButton.SetEnabled();
    }

    private float GetSpeedModificator() => _currentGameSpeed switch
    {
        GameSpeedState.Slow => 0.5f,
        GameSpeedState.Normal => 1f,
        GameSpeedState.Fast => 1.5f,
        _ => 0f
    };
}
