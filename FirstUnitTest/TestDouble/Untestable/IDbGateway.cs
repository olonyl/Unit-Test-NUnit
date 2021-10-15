public interface IDbGateway
{
    WorkingStatistics GetWorkingStatistics(int id);
    bool Connected { get; }
}