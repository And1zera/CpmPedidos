namespace CpmPedidos.Repository
{
    public class BaseRepository
    {
        protected const int tamanhoPagina = 5;

        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
