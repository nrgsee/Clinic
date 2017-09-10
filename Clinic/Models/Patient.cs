using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.Models
{
    public interface IModel
    {
        int Id { get; set; }
    }
    class Patient:IModel
    {
        public int Id { get; set; }
    }
}
