using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������, ���������� �� ��������� ����
/// </summary>
public class GameResultComponent : MonoBehaviour
{
    [SerializeField] private GameObject gameResultPanel;

    [SerializeField] private Text resultText;
    [SerializeField] private Text resultDescription;
    [SerializeField] private Text statisticsText;

    [SerializeField] private UnitManagerComponent unitManager;
    [SerializeField] private ResourcesManagerComponent resourceManager;
    [SerializeField] private EnemyAttackCycleComponent enemyAttacks;
    [SerializeField] private GameStatisticsComponent statisticsComponent;
    [SerializeField] private GameSpeedComponent gameSpeedComponent;

    [SerializeField] SoundComponent soundManager;

    private Dictionary<GameResults, (string header, string description)> _gameResultsText = new()
    {
        [GameResults.BattleLose] = ("������ ���������", "���������� ������ ���������� ���� �������� �������� � ��������� ���� �������. ��� ������ ��������� �� �������� ������ ��������."),
        [GameResults.BattleWin] = ("������ ������!", "�� ������ ��� ��������� �����, ����� ������ ���������� ������ � �����! ��� �� �������� ������ �����, ����� ��� � �������� ����� � ������� ����������!"),
        [GameResults.PeasantsWin] = ("������ ������������!", "�� ������ ������ ���� ��������. �� ������� �������� ���� � ����������, � ���� ����� ������� ���� �����. ����� ������ ���� ������������!"),
        [GameResults.WheatLose] = ("�������� ���������", "� ��� ����������� �������! ��� ����� � ����� �������������, ����� ����� ���� �� ������� �����. ��������� ����� � ���� ������� ��� ��������� �������������"),
        [GameResults.WheatWin] = ("����������������� ������!", "���� ������� ������� �� �������. �� ��������� �����, ��� �� ������ ������� �� ���� ������ ����������. ���, ������ ���� ������� � ��������, ������� �� ���� �������!")
    };

    private void Start()
    {
        gameResultPanel.SetActive(false);

        enemyAttacks.OnGameEnded += EnemyAttacks_SetGameResult;
        resourceManager.OnGameEnded += ResourceManager_OnGameEnded;
        unitManager.OnGameEnded += UnitManager_OnGameEnded;
    }

    private void UnitManager_OnGameEnded(GameResults result) => SetResult(result);

    private void ResourceManager_OnGameEnded(GameResults result) => SetResult(result);

    private void EnemyAttacks_SetGameResult(GameResults result) => SetResult(result);

    private void SetResult(GameResults result)
    {
        gameSpeedComponent.SetPause();

        soundManager.ChangeAudioEnable();
        switch (result)
        {
            case GameResults.BattleWin:
            case GameResults.WheatWin:
            case GameResults.PeasantsWin:
                soundManager.PlayWin();
                break;
            case GameResults.BattleLose:
            case GameResults.WheatLose:
                soundManager.PlayLose();
                break;
        }

        gameResultPanel.SetActive(true);

        var (header, description) = _gameResultsText[result];

        resultText.text = header;
        resultDescription.text = description;

        statisticsText.text = GetStatistics();
    }

    private string GetStatistics() => $"����� ������� ������ - {statisticsComponent.TotalWheat}\n" +
                                      $"����� ������ ������� - {statisticsComponent.TotalWarriors}\n" +
                                      $"����� �������� ������ - {statisticsComponent.TotalPeasants}\n" +
                                      $"����� ���� �������� - {statisticsComponent.TotalAttacks}";

}

public delegate void GameResultDelegate(GameResults result);
