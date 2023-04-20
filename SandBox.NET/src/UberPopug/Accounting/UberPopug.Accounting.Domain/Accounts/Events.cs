namespace UberPopug.Accounting.Domain.Accounts;

/// <summary>
/// События
/// </summary>
public static class Events
{
    /// <summary>
    /// Событие "Счет открыт"
    /// </summary>
    public class AccountOpened
    {
    }

    /// <summary>
    /// Событие "Средства списаны"
    /// </summary>
    public class FundsDebited
    {
        /// <summary>
        /// Конструктор <see cref="FundsDebited"/>
        /// </summary>
        /// <param name="sum"><see cref="Sum"/></param>
        /// <param name="purpose"><see cref="Purpose"/></param>
        public FundsDebited(decimal sum, string purpose)
        {
            Sum = sum;
            Purpose = purpose;
        }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Sum { get; }

        /// <summary>
        /// Назначение платежа
        /// </summary>
        public string Purpose { get; }
    }

    /// <summary>
    /// Событие "Средства зачислены"
    /// </summary>
    public class FundsCredited
    {
        /// <summary>
        /// Конструктор <see cref="FundsCredited"/>
        /// </summary>
        /// <param name="sum"><see cref="Sum"/></param>
        /// <param name="purpose"><see cref="Purpose"/></param>
        public FundsCredited(decimal sum, string purpose)
        {
            Sum = sum;
            Purpose = purpose;
        }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Sum { get; }

        /// <summary>
        /// Назначение платежа
        /// </summary>
        public string Purpose { get; }
    }

    /// <summary>
    /// Событие "Счет закрыт"
    /// </summary>
    public class AccountClosed
    {
    }
}