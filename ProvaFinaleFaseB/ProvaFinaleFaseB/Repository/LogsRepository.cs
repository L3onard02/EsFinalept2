using Microsoft.EntityFrameworkCore;
using ProvaFinaleFaseB.DataSource;
using ProvaFinaleFaseB.Entities;

namespace ProvaFinaleFaseB.Repository
{
    public class LogsRepository : ILogsRepository
    {
        private ApplicationLogContext _context;
        public LogsRepository(ApplicationLogContext context) => _context = context;

        public async Task<LogsEntity> findLog(string url)
        {

            using (_context)
            {
                try
                {
                    var logs=_context.loggers.Where(l=>l.EndpointUrl==url).FirstOrDefault();
                    if (logs == null) throw new NullReferenceException("log non trovato");
                    return logs;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<bool> PostLog(LogsEntity logE)
        {
            using (_context)
            {
                try
                {
                    _context.Entry(logE).State=EntityState.Added;
                    int numeroInseriti = await _context.SaveChangesAsync();
                    if (numeroInseriti != 1)
                    {
                        string messaggioErrore = "Operazione di inserimento non effettuata";
                        throw new Exception(messaggioErrore);
                    }
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
