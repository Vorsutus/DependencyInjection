using System;
using DemoLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace ConsuleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            /*This VIOLATES D.I.P. (could make a factory to do the work) but we will use AutoFac which is our dependency injector.
            We want to get our instances from a contain, but can't do that from static class because we will
            get the instances through our constructor in BusinessLogic. We will make a new Class "Application" that will be the start of the App.
            */
            //BusinessLogic businessLogic = new BusinessLogic(); 
            //businessLogic.ProcessData();
            

            //build and get a ref to the container from the Autofac 
            //This registers all our dependencies at the top of the APP (high level) instead of the bottom (VIOLATES D.I.P.)
            var container = ContainerConfig.Configure();

            //this sets up a new scope for the container instances being passed out
            //typically you should only have to do this once at the start of the application
            using (var scope = container.BeginLifetimeScope())
            {
                //Give me an IApplication, which gives an instance of Application, which give you the Run() method
                /*Resolve<IApplication> looks into the instance it will create and checks if constructors requires any objects (i.e. IBusinessLogic),
                 * and then does that object require any objects (i.e. ILogger, IDataAccess),
                 * and then do those objects require any objects?
                 */ 
                var app = scope.Resolve<IApplication>(); //app becomes an instance of Application
                app.Run(); //calls the _businesslogic to ProcessData()
            }

                Console.ReadLine();
        }
    }
}
