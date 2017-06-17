using billyDotNet.Repository;
using billyDotNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billyDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            RequesterHelper rHelper = new RequesterHelper();

            BillyRepository repository = new BillyRepository(rHelper);
            BillyService service = new BillyService(repository);


            string id = "3fadd6a2-cee7-4b93-8763-f5402ce70d30";
            Console.WriteLine(service.GetBillsByYear(2017, id));


            Console.ReadLine();
        }
    }
}
