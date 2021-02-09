using DemoLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    //Class to swap with old business logic
    public class BetterBusinessLogic : IBusinessLogic
    {
        //Interface vars to hold the Interface constructed items
        ILogger _logger;
        IDataAccess _dataAccess;

        //pass in our instances from the interface
        public BetterBusinessLogic(ILogger logger, IDataAccess dataAcess)
        {
            _logger = logger;
            _dataAccess = dataAcess;
        }

        public void ProcessData()
        {
            //"Newing up" two different instances
            //Logger logger = new Logger(); //This VIOLATES D.I.P. (can take out when we have method that brings in Interface version)
            //DataAccess dataAccess = new DataAccess(); //This VIOLATES D.I.P. (can take out when we have method that brings in Interface version)

            //logger.Log("Starting the processing of data."); //log that we are starting the log process
            _logger.Log("Starting the processing of data.");
            Console.WriteLine("..................................");
            Console.WriteLine("Processing the data."); //simulating the data log process
            Console.WriteLine("..................................");
            //dataAccess.LoadData(); //load the data
            _dataAccess.LoadData();
            //dataAccess.SaveData("ProcessedInfo"); //save the data
            _dataAccess.SaveData("ProcessedInfo");
            //logger.Log("Finished processing of the data."); //log that we are finishing the log process
            _logger.Log("Finished processing of the data.");
            Console.WriteLine("..................................");
        }
    }
}
