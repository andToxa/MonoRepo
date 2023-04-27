using Common.Domain.ValueObjects;

namespace UberPopug.Accounting.Domain.Accounts;

/// <summary>
/// Расчетный счет
/// </summary>
public class Account
{
    /// <summary>
    /// Идентификатор счета
    /// </summary>
    public Id<Account> AccountId { get; }

    /// <summary>
    /// <see cref="AccountStatus"/>
    /// </summary>
    public AccountStatus Status { get; private set; }

    /// <summary>
    /// Баланс счета
    /// </summary>
    public decimal Balance { get; private set; }

    /// <summary>
    /// Открытие счета
    /// </summary>
    public void Open()
    {
        Status = AccountStatus.Opened;
        var @event = new Events.AccountOpened();
    }

    /// <summary>
    /// Зачисление средств
    /// </summary>
    /// <param name="sum">Сумма</param>
    /// <param name="purpose">Назначение платежа</param>
    public void DebitFunds(decimal sum, string purpose)
    {
        Balance += sum;
        var @event = new Events.FundsDebited(sum, purpose);
    }

    /// <summary>
    /// Списание средств
    /// </summary>
    /// <param name="sum">Сумма</param>
    /// <param name="purpose">Назначение платежа</param>
    public void CreditFunds(decimal sum, string purpose)
    {
        Balance -= sum;
        var @event = new Events.FundsCredited(sum, purpose);
    }

    /// <summary>
    /// Закрытие счета
    /// </summary>
    public void Close()
    {
        Status = AccountStatus.Closed;
        var @event = new Events.AccountClosed();
    }
}