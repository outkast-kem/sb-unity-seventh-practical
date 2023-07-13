using UnityEngine;

/// <summary>
/// ���������, ���������� �� ���� ����� ���� ������
/// </summary>
public class EnemyAttackCycleComponent : MonoBehaviour
{
    [SerializeField] Timer enemyAttackTimer;
    [SerializeField] LogComponent logComponent;
    [SerializeField] UnitManagerComponent unitManager;

    [SerializeField] int emptyAttackLeft;
    [SerializeField] int initialAttackEnemies;

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
                _nextWaveEnemies = initialAttackEnemies;

            return;
        }

        unitManager.DecreaseWarriorsCount(_nextWaveEnemies);

        _attacksPassedCount++;
        _nextWaveEnemies += GetIncreasment();
    }

    /// <summary>
    /// ���������� �����, �� ������� ������������� ���-�� ������ � ��������� ����� �� ��������� ���-�� ��������� ���� ����
    /// </summary>
    private int GetIncreasment() => _attacksPassedCount switch
    {
        < 5 => 1,
        < 10 => 2,
        < 15 => 3,
        < 20 => 4,
        _  => 5
    };
}
