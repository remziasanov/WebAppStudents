using Domain.Data.Repositories.Base;
using Domain.DataContext;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Domain.Data.Repositories
{
    public class DocumentRepository : BaseRepository<Document, int, StudentDataContext>, IDocumentRepository
    {
        public DocumentRepository(StudentDataContext context) : base(context)
        {
        }
    }
}
