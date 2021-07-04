using System;

namespace CommunalPayments.BL.Model
{
    /// <summary>
    /// Показатель счётчика электроэнергии
    /// </summary>
    [Serializable]
    class ElectricityIndicator
    {
        /// <summary>
        /// Значение показателя счётчика электроэнергии
        /// </summary>
        public double ElectricityIndicatorValue { get; set; }

        /// <summary>
        /// Создать новое показание счётчика электроэнергии
        /// </summary>
        /// <param name="elecricityIndicatorValue">Значение показателя счётчика электроэнергии</param>
        public ElectricityIndicator(double elecricityIndicatorValue)
        {
            #region Проверка условий
            if (elecricityIndicatorValue < 0)
            {
                throw new ArgumentException("Значение показателя счётчика электричества не может быть отрицательным числом");
            }
            #endregion

            ElectricityIndicatorValue = elecricityIndicatorValue;
        }
    }
}
