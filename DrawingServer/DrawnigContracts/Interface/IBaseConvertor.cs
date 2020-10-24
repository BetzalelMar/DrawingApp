using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DrawnigContracts.Interface
{
    public interface IBaseConvertor<T>
    {
        public List<T> convertTableToList(DataTable tb);
        abstract public T Convert(DataRow datarow);

    }
}
