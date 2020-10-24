using Contracts;
using DrawnigContracts.DTO.documentsDTO.DocData;
using DrawnigContracts.Interface;
using System.Data;

namespace DBConvertor
{
    [Register(Policy.Transient, typeof(IDocConvertor))]
    public class DocConvertor:BaseConvertor<DocInfra> , IDocConvertor
    {
        public override DocInfra Convert(DataRow dataRow)
        {
            var docInfra = new DocInfra
            {
                ownerId = dataRow.Field<string>("OWNERID"),
                docId = dataRow.Field<string>("DOCID"),
                docName = dataRow.Field<string>("DOCNAME"),
                docUrl =dataRow.Field<string>("DOCURL")
            };
            return docInfra;
        }
    }
}
