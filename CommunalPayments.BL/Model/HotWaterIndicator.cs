using System;

namespace CommunalPayments.BL.Model
{
    /// <summary>
    /// Показатель счётчика горячей воды
    /// </summary>
    [Serializable]
    class HotWaterIndicator
    {
        /// <summary>
        /// Показатель счётчика горячей воды
        /// </summary>
        public double HotWaterIndicatorValue { get; set; }

        /// <summary>
        /// Создать новое показание счётчика горячей воды
        /// </summary>
        /// <param name="hotWaterIndicatorValue">Показатель счётчика горячей воды</param>
        public HotWaterIndicator(double hotWaterIndicatorValue)
        {
            #region Проверка условий
            if (hotWaterIndicatorValue < 0)
            {
                throw new ArgumentException("Значение показателя счётчика горячей воды не может быть отрицательным числом");
            }
            #endregion

            HotWaterIndicatorValue = hotWaterIndicatorValue;
        }
    }
}
