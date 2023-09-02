using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент, отвечающий за фичу атаки волн врагов
/// </summary>
public class EnemyAttackCycleComponent : MonoBehaviour
{
    [SerializeField] private Timer enemyAttackTimer;
    [SerializeField] private LogComponent logComponent;
    [SerializeField] private UnitManagerComponent unitManager;
    [SerializeField] private GameStatisticsComponent statisticsComponent;

    [SerializeField] private Text nextWaveCountText;

    [SerializeField] private int emptyAttackLeft;
    [SerializeField] private int initialAttackEnemies;

    [SerializeField] private int attacksToWin = 20;

    private int _attacksPassedCount = 0;

    private int _nextWaveEnemies = 0;

    public event GameResultDelegate OnGameEnded;

    private void Start()
    {
        enemyAttackTimer.OnTimerEnded += EnemyAttackTimer_OnTimerEnded;
    }

    private void EnemyAttackTimer_OnTimerEnded()
    {
        if (emptyAttackLeft > 0)
        {
            emptyAttackLeft--;

            if (emptyAttackLeft == 0)
            {
                _nextWaveEnemies = initialAttackEnemies;
                UpdateNextWaveCountText();
            }

            return;
        }

        unitManager.DecreaseWarriorsCount(_nextWaveEnemies);

        _attacksPassedCount++;
        _nextWaveEnemies = GetNextWave();

        statisticsComponent.TotalAttacks++;

        if (_attacksPassedCount >= attacksToWin)
        {
            OnGameEnded?.Invoke(GameResults.BattleWin);
            return;
        }

        UpdateNextWaveCountText();
    }

    /// <summary>
    /// Определяет число, на которое увеличивается кол-во врагов в следующей волне на основании кол-ва пережитых волн атак
    /// </summary>
    private int GetNextWave() => _attacksPassedCount switch
    {
        <= 3 => 1,
        <= 6 => 2,
        <= 10 => 3,
        _  => 4
    };

    private void UpdateNextWaveCountText()
    {
        nextWaveCountText.text = _nextWaveEnemies.ToString();
    }
}
