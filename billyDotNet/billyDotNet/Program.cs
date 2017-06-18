using billyDotNet.Repository;
using billyDotNet.Utils;
using System;
using System.Net;

namespace billyDotNet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RequesterHelper rHelper = new RequesterHelper();

            BillyRepository repository = new BillyRepository(rHelper);
            BillyService service = new BillyService(repository);

            //First registry
            string id = "3fadd6a2-cee7-4b93-8763-f5402ce70d30";
            Console.WriteLine($"id: {id}");
            Console.WriteLine($"Facturas: {service.GetBillsByYear(2017, id)}");

            do
            {
                //Ask for another id or an enter
                Console.WriteLine("Ingresa otro id para buscar de nuevo, presiona enter para salir.");
                id = Console.ReadLine();

                if (!string.IsNullOrEmpty(id))
                {
                    try
                    {
                        int count = service.GetBillsByYear(2017, id);

                        Console.WriteLine($"id: {id}");
                        Console.WriteLine($"Facturas: {count}");
                    }
                    catch (WebException we)
                    {
                        HttpWebResponse response = we.Response as HttpWebResponse;

                        if (response != null)
                        {
                            if (response.StatusCode == HttpStatusCode.BadRequest)
                            {
                                Console.WriteLine("Es posible que el id que ingresó no exista. Por favor intente de nuevo.");
                            }
                            else
                            {
                                Console.WriteLine($"No se pudieron obtener los datos del servicio. Status: {response.StatusCode}, {response.StatusDescription}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Una excepción ocurrió!{we.Message}");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Una excepción ocurrió!{e.Message}");
                    }
                }
            } while (!string.IsNullOrEmpty(id));
        }
    }
}