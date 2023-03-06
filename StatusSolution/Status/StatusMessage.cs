using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Status
{
    //"Models"

    public record StatusMessage(Guid Id, string Message, DateTimeOffset When);
    public record StatusChangeRequest(string Message);

}
