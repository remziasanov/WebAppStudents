using Domain.Entities;
using Domain.RepositoryInterfaces.Base;
namespace Domain.RepositoryInterfaces
{
    /// <summary>
    /// Репозиторий для документов
    /// </summary>
    public interface IDocumentRepository : IRepositoryBase<Document, int>
    {
        // можно добавить дополнительные методы для работы с документами
    }
}
