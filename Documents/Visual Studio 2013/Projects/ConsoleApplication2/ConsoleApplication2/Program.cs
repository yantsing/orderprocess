using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.Threading;
using System.IO; 

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = log4net.LogManager.GetLogger
    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            logger.Info("Order process starts!");
             //立刻开始运行，接着每隔5分钟调用Tick方法
            Timer tmr = new Timer(Tick, "tick...", 0, 1000);
            Console.ReadLine();
            tmr.Dispose();
        }
        static void Tick(object data)
        {
            var logger = log4net.LogManager.GetLogger
           (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            logger.Info("5 minutes have passed!");
            processOrderFile();
        }

        static void processOrderFile()
        {
            string strLine;
            FileStream fs = null;
            StreamReader sr = null;
            var logger = log4net.LogManager.GetLogger
           (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string orderPath = @".\order.txt";
            if (File.Exists(orderPath))
            {

                try
                {
                    fs = new FileStream(orderPath, FileMode.Open);
                    sr = new StreamReader(fs);
                    while ((strLine = sr.ReadLine()) != null)
                    {
                        logger.Info(strLine);
                        string[] aStr = System.Text.RegularExpressions.Regex.Split(strLine, @"[\s\t]{1,}"); 
                        logger.Info(aStr);
                        if (aStr[0].Equals("add"))
                            addOrder();
                        else if (aStr[0].Equals("del"))
                            delOrder();
                        else if (aStr[0].Equals("modify"))
                            modifyOrder();
                        else
                            logger.Warn("Not valid type!");
                    }
                    sr.Close();
                    fs.Close();
                    File.Delete(orderPath);
                }
                catch (Exception e)
                {

                    logger.Error(e);
                }
                finally
                {
                    fs.Close();
                }
            }
        }
        static private void addOrder()
        {
            var logger = log4net.LogManager.GetLogger
           (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            logger.Info("Enter addOder function!");
        }

        static private void modifyOrder()
        {
            var logger = log4net.LogManager.GetLogger
           (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            logger.Info("Enter modifyOder function!");
        }

        static private void delOrder()
        {
            var logger = log4net.LogManager.GetLogger
           (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            logger.Info("Enter delOder function!");
        }
    }
}
