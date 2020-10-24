using Contracts;
using DrawnigContracts.DTO.MarkersDTO.markerDataDto;
using DrawnigContracts.Interface;
using Newtonsoft.Json;
using System.Data;

namespace DBConvertor
{
    [Register(Policy.Transient, typeof(IMarkerConvertor))]
    public class MarkerConvertor :BaseConvertor<MarkerData>, IMarkerConvertor
    {
        public override MarkerData Convert(DataRow dataRow)
        {
            var retval = new MarkerData
            {
                docId = dataRow.Field<string>("DOCID"),
                marker = new Marker
                {
                    markerColor = new MarkerColor
                    {
                        foreColor = dataRow.Field<string>("FCOLOR"),
                        backColor = dataRow.Field<string>("BCOLOR")
                    },

                    markerId = dataRow.Field<string>("MARKERID"),
                    markerLocation = JsonConvert.DeserializeObject<MarkerLocation>(dataRow.Field<string>("MARKERLOCATION")),

                    markerType = dataRow.Field<string>("MARKERTYPE"),
                    originScreen= JsonConvert.DeserializeObject<Point>(dataRow.Field<string>("ORIGINSCREEN"))

                },
                userId = dataRow.Field<string>("USERID")
            };


            return retval;
        }
    }

}
