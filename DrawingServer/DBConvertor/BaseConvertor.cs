using DrawnigContracts.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBConvertor
{
    public abstract class BaseConvertor<T>: IBaseConvertor<T>
    {

        public List<T> convertTableToList(DataTable tb)
        {
            return tb.AsEnumerable().Select(dataRow => Convert(dataRow)).ToList<T>();
        }

        abstract public T Convert(DataRow datarow);
    }
}
