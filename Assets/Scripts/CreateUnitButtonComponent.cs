using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// Базовый компонент создания юнита
    /// </summary>
    public class CreateUnitButtonComponent : MonoBehaviour
    {
        private enum UnitType { None, Peasant, Warrior }

        [SerializeField] private ResourcesManagerComponent resources;
        [SerializeField] private UnitManagerComponent unitManager;
        [SerializeField] private DeferredTimer createUnitTimer;
        [SerializeField] private int unitCost;
        [SerializeField] private Image timerImage;
        [SerializeField] private UnitType unitType;
 
        private Button _button;
        private bool _isTimerStarted;

        private void Start()
        {
            _button = GetComponent<Button>();

            createUnitTimer.OnTick += CreateUnitTimer_OnTick;
            createUnitTimer.OnTimerEnded += CreateUnitTimer_OnTimerEnded;

            if (unitType == UnitType.None)
                throw new ArgumentException("Unit type cannot be None");
                
        }

        private void Update()
        {
            SetButtonInteractable();
        }

        /// <summary>
        /// Запуск таймера создания юнита
        /// </summary>
        public void CreateUnit()
        {
            Debug.Log("Start create unit");

            resources.DecreaseWheat(unitCost);

            _isTimerStarted = true;
            createUnitTimer.TimerStart();
        }

        private void SetButtonInteractable()
        {
            if (_isTimerStarted)
            {
                _button.interactable = false;
                return;
            }

            if (resources.WheatCount >= unitCost)
                _button.interactable = true;
            else
                _button.interactable = false;
        }

        private void CreateUnitTimer_OnTick(float leftTime)
        {
            timerImage.fillAmount = leftTime;
        }

        private void CreateUnitTimer_OnTimerEnded()
        {
            _isTimerStarted = false;
            IncreaseUnitsCount();
        }

        private void IncreaseUnitsCount()
        {
            switch (unitType)
            {
                case UnitType.Peasant:
                    unitManager.IncreasePeasantCount();
                    break;
                case UnitType.Warrior:
                    unitManager.IncreaseWarriorsCount();
                    break;
                default: throw new InvalidOperationException("Unit type should not be None");
            }
        }
    }
}
