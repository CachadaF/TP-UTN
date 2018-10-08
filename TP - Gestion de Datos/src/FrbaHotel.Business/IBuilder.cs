using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaHotel.Business
{
    public interface IBuilder<T>
    {
        T Build(DataRow row);
    }
}
