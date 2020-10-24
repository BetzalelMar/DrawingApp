using DrawnigContracts.DTO.MarkersDTO.MarkersRequest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DrawnigContracts.Interface
{
    public interface IMarkersDal
    {
        public DataSet CraeteNarker(string markerId,AddMarkerRequest request);
        public DataSet RemoveMarker(string markerId);
        public DataSet GetMarkersByDoc(string docId);
        public DataSet RemoveAllMarkersByDoc(string docId);

    }
}
