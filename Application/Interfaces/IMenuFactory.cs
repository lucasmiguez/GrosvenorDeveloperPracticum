using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IMenuFactory
    {
        IMenu CreateMenu(string period);
    }
}
