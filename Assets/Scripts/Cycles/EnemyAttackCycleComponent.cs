using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент, отвечающий за фичу атаки волн врагов
/// </summary>
public class EnemyAttackCycleComponent : MonoBehaviour
{
    [SerializeField] Timer enemyAttackTimer;
    [SerializeField] LogComponent logComponent;
    [SerializeField] UnitManagerComponent unitManager;
    [SerializeField] Text nextWaveCountText;

    [SerializeField] int emptyAttackLeft;
    [SerializeField] int initialAttackEnemies;

    [SerializeField] GameStatisticsComponent statisticsComponent;

    private int _attacksPassedCount = 0;

    private int _nextWaveEnemies = 0;

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
        _nextWaveEnemies += GetIncreasment();

        statisticsComponent.TotalAttacks++;

        UpdateNextWaveCountText();
    }

    /// <summary>
    /// Определяет число, на которое увеличивается кол-во врагов в следующей волне на основании кол-ва пережитых волн атак
    /// </summary>
    private int GetIncreasment() => _attacksPassedCount switch
    {
        < 5 => 1,
        < 10 => 2,
        < 15 => 3,
        < 20 => 4,
        _  => 5
    };

    private void UpdateNextWaveCountText()
    {
        nextWaveCountText.text = _nextWaveEnemies.ToString();
    }
}
