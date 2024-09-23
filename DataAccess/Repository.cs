using System.Data;
using System.Data.SqlClient;
using ContosoShoe.models;
namespace ContosoShoe.DataAccess
{
    public abstract class Repository
    {
        bool returnValue = false;
        private SqlConnection _connection;
        protected SqlConnection Connection { get { return _connection; } }
        public string ConnectionString {  
            get { return connectionstring; } 
            set { connectionstring = value; }
        }
        private string connectionstring= String.Empty;
        public virtual bool Connect(string connectionstring)
        {
            if (_connection == null) {
                _connection = new SqlConnection();
            }
            if (connectionstring != String.Empty) { 
                _connection.ConnectionString = connectionstring;
            }
            try
            {
            _connection.Open();
                returnValue = true;
            }
            catch (Exception ex) {
                returnValue = false;
            }
            return returnValue;
        }

        public abstract IList<ProductViewModel> getAll();
        public abstract ProductViewModel getById(int ID);

        public abstract int Insert(ProductViewModel data);
        public abstract int Update(int id, ProductViewModel data);
        public abstract int Delete(int ID);
    }
}
