using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsuleUI
{
    public class Application : IApplication
    {
        IBusinessLogic _businessLogic;

        public Application(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        //this is all we need to call from Program.cs
        public void Run()
        {
            _businessLogic.ProcessData();
        }
    }
}
