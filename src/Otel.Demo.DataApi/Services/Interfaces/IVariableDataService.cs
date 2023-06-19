namespace Otel.Demo.DataApi.Services.Interfaces
{
    public interface IVariableDataService
    {
        Task<double> GetVariableValue(string variableName);
    }
}
