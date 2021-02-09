using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsuleUI
{
    public static class ContainerConfig
    {
        //using Autofac
        //this is basically a Factory for creating interface instances
        public static IContainer Configure()
        {
            //this only has one method that we can use (Build())
            var builder = new ContainerBuilder();

            //Tell the builder to register different pieces (simplest version of a registration) that
            //basically says that whenever we look for BusinessLogic, respond with an instance of IBusinessLogic
            //builder.RegisterType<BusinessLogic>().As<IBusinessLogic>(); //this is a SINGLE-shot way to register
            builder.RegisterType<BetterBusinessLogic>().As<IBusinessLogic>(); //this is one line change that
            builder.RegisterType<Application>().As<IApplication>(); //Registering the IApplication

            //Give me all the classes from the Utilities folder and then register and link them with the matching Interface
            //"nameOf" DemoLibrary makes it smart so we can change auto-magically if it's changed elsewhere
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary))) //this is a MULTI-shot way to register
                .Where(t => t.Namespace.Contains("Utilities"))
                //get the interface where the name of the interface (i.Name) = the name of the class (t.Name))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
                //another way of doing this is looking for NameSpace that ends with a certain word (i.e. -processor or -controller) (t.Name.EndsWith("processor"))

            //this will build the container 
            //(place to store the definitions of all the different classes we want to instantiate)
            return builder.Build();
        }
    }
}
