using PurchaseOrderModule.Repository.Contracts;
using PurchaseOrderModule.Repository.Models;

namespace PurchaseOrderModule.Services
{
    public class RepositoryBase
    {
        internal IDapperRepository _dapperRepository;
        internal DbConnection _connection { get; set; } = new DbConnection();

        public RepositoryBase(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
            _connection.ConnectionString = "Data Source=Saaramsha;Initial Catalog=PurchaseOrders;Integrated Security=True";
        }
    }
}
