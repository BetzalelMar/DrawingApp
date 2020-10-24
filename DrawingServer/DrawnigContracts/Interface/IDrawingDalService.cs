
using DALContracts;
using System.Data;

namespace DrawnigContracts.Interface
{
    public  interface IDrawingDalService
    {
        public IDBConnection Connection { get; }
        public string StrConnection {  set; }
        public IDALinfra DalInfra { get; set; }
        public void Connect();
        public DataSet ESPQ(string spName, params IDBParameter[] parametrs);
        
    }
}
