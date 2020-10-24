using Contracts;
using DALContracts;
using DrawnigContracts.Interface;
using System;
using System.Data;

namespace DrawingDalService
{
    [Register(Policy.Transient,typeof(IDrawingDalService))]
    public class DrawingDalServiceImpl : IDrawingDalService
    {
        protected IDBConnection _connection;
        protected string _strConnection = "DATA SOURCE=localhost:1521/XE;PASSWORD=1234;USER ID=C##BETZALEL";
        protected IDALinfra _dalInfra;

        public DrawingDalServiceImpl(IDALinfra dal)
        {
            _dalInfra = dal;
            Connect();
        }
        public IDBConnection Connection { get => _connection;}
        public string StrConnection { set => _strConnection = value; }
        public IDALinfra DalInfra { get => _dalInfra; set => _dalInfra=value; }

        public void Connect()
        {
            _connection = _dalInfra.Connect(_strConnection);
        }

        public DataSet ESPQ(string spName, params IDBParameter[] parametrs)
        {
            return DalInfra.ExecuteSPQuery(Connection, spName, parametrs);
        }
    }
}
