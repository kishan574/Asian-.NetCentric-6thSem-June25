using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1LanguagePreliminaries2
{
    public interface IPerson
    {
        string Name { get; set; }
        void DisplayDetails();
    }
}
