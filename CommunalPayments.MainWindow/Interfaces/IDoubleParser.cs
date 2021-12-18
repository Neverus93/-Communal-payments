namespace CommunalPayments.MainWindow.Interfaces
{
    interface IDoubleParser<T>
    {
        T DoubleParse(params string[] parameters);
    }
}
