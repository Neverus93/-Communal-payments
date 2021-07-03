using System;

namespace CommunalPayments.BL.Model
{
    /// <summary>
    /// Показатель счётчика холодной воды
    /// </summary>
    [Serializable]
    class ColdWaterIndicator
    {
        /// <summary>
        /// Показатель счётчика холодной воды
        /// </summary>
        public double ColdWaterIndicatorValue { get; set; }

        /// <summary>
        /// Создать новое показание счётчика холодной воды
        /// </summary>
        /// <param name="coldWaterIndicatorValue">Показатель счётчика холодной воды</param>
        public ColdWaterIndicator(double coldWaterIndicatorValue)
        {
            #region Проверка условий
            if (coldWaterIndicatorValue < 0)
            {
                throw new ArgumentException("Значение показателя счётчика холодной воды не может быть отрицательным числом");
            }
            #endregion

            ColdWaterIndicatorValue = coldWaterIndicatorValue;
        }
    }
}
