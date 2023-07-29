using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент, отвечающий за результат игры
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
        [GameResults.BattleLose] = ("Боевое поражение", "Противники смогли преодолеть ваши защитные бастионы и захватить вашу деревню. Все жители посягнули на верность новому сюзерену."),
        [GameResults.BattleWin] = ("Боевая победа!", "Вы отбили все возможные атаки, армия вашего противника бежала в ужасе! Вам не остается ничего иного, кроме как с триумфом войти в деревню противника!"),
        [GameResults.PeasantsWin] = ("Победа пролетариата!", "Вы наняли вообще всех крестьян. Вы забрали крестьян даже у противника, и тому нечем кормить свою армию. Пусть узнает силу пролетариата!"),
        [GameResults.WheatLose] = ("Голодное поражение", "У вас закончилась пшеница! Ваш народ и армия дезертировали, чтобы найти хотя бы кусочек хлеба. Противник зашел в вашу деревню без малейшего сопротивления"),
        [GameResults.WheatWin] = ("Продовольственная победа!", "Ваши закрома ломятся от пшеницы. Ее настолько много, что вы решили кормить ей даже солдат противника. Они, увидев вашу доброту и щедрость, перешли на вашу сторону!")
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

    private string GetStatistics() => $"Всего пшеницы добыто - {statisticsComponent.TotalWheat}\n" +
                                      $"Всего воинов обучено - {statisticsComponent.TotalWarriors}\n" +
                                      $"Всего крестьян нанято - {statisticsComponent.TotalPeasants}\n" +
                                      $"Всего атак отражено - {statisticsComponent.TotalAttacks}";

}

public delegate void GameResultDelegate(GameResults result);
