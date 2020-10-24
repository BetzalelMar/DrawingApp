using Contracts;
using DALContracts;
using DrawnigContracts.DTO.MarkersDTO.MarkersRequest;
using DrawnigContracts.Interface;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace MarkersDal
{
    [Register(Policy.Transient,typeof(IMarkersDal))]
    public class MarkersDalImpl : IMarkersDal
    {
        IDrawingDalService _dalService;
        public MarkersDalImpl(IDrawingDalService dalService)
        {
            _dalService = dalService;
        }

        public DataSet CraeteNarker(string markerId, AddMarkerRequest request)
        {
            IDBParameter[] parm =
             {
                _dalService.DalInfra.getParameter("P_DOCID", OracleDbType.Varchar2, request.markerData.docId),
                _dalService.DalInfra.getParameter("P_MARKERID", OracleDbType.Varchar2, markerId),
                _dalService.DalInfra.getParameter("P_MARKERTYPE", OracleDbType.Varchar2, request.markerData.marker.markerType),
                _dalService.DalInfra.getParameter("P_MARKERLOCATION", OracleDbType.Varchar2, request.markerData.marker.markerLocation.ToString()),
                _dalService.DalInfra.getParameter("P_F_COLOR", OracleDbType.Varchar2, request.markerData.marker.markerColor.foreColor),
                _dalService.DalInfra.getParameter("P_B_COLOR", OracleDbType.Varchar2, request.markerData.marker.markerColor.backColor),
                _dalService.DalInfra.getParameter("P_USERID", OracleDbType.Varchar2, request.markerData.userId),
                _dalService.DalInfra.getParameter("P_ORIGINSCREEN", OracleDbType.Varchar2, request.markerData.marker.originScreen.ToString()),
            };
   
            return _dalService.ESPQ("CREATE_MARKER", parm);
        }

        public DataSet GetMarkersByDoc(string docId)
        {
            var p1 = _dalService.DalInfra.getParameter("P_DOCID", OracleDbType.Varchar2, docId);
            return _dalService.ESPQ("GET_MARKERS_BY_DOC", p1);
        }

        public DataSet RemoveMarker(string markerId)
        {
            var p1 = _dalService.DalInfra.getParameter("P_MARKERID", OracleDbType.Varchar2, markerId);
            return _dalService.ESPQ("REMOVE_MARKER", p1);
        }
        public DataSet RemoveAllMarkersByDoc(string docId)
        {
            var p1 = _dalService.DalInfra.getParameter("P_DOCID", OracleDbType.Varchar2, docId);
            return _dalService.ESPQ("REMOVE_ALL_MARKERS_BY_DOCID", p1);
        }

    }
}
