using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������, ���������� �� ��������� ����
/// </summary>
public class GameResultComponent : MonoBehaviour
{
    [SerializeField] GameObject gameResultPanel;

    [SerializeField] Text resultText;
    [SerializeField] Text resultDescription;
    [SerializeField] Text statisticsText;

    [SerializeField] UnitManagerComponent unitManager;
    [SerializeField] ResourcesManagerComponent resourceManager;
    [SerializeField] EnemyAttackCycleComponent enemyAttacks;
    [SerializeField] GameStatisticsComponent statisticsComponent;

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
        Time.timeScale = 0;

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
