using ProvaFinaleFaseB.Entities;

namespace ProvaFinaleFaseB.Repository
{
    public interface ILogsRepository
    {
        public Task<bool> PostLog(LogsEntity logE);

        public Task<LogsEntity> findLog(string url);
    }
}
