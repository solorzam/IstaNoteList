using System;
using System.Linq;
using IstaNoteClient.IstaNoteService;

namespace IstaNote
{
    class Program
    {
        static void Main(string[] args)
        {
                string result;
                int customerId = 532416;

                try
                {
                    var client = new NoteSoapClient();

                    client.ClientCredentials.UserName.UserName = "39084BFB-9663-4B10-ADB3-6D3B09F7C94A";
                    client.ClientCredentials.UserName.Password = "39084BFB-9663-4B10-ADB3-6D3B09F7C94A";
                    //client.ClientCredentials.IssuedToken = "UsernameToken-A55FC9B553A2C46D4414507229815442";

                var noteListResponse = client.List(customerId, "");

                    //GetPurchaseOrderResponse: WSAClient.WSAWebService.clsPurchaseOrder
                    if (noteListResponse == null 
                    )
                    {
                        result = String.Format("List of notes is empry for customerId = {0}", customerId);
                    }
                    else
                    {
                        result = String.Format("Response:  Success\n");
                        noteListResponse.ToList().ForEach(
                            n => n.Details.ToList().ForEach(
                                d => Console.WriteLine(d.NoteDetailText)));

                }
                }
                catch (Exception e)
                {
                    result = String.Format("Exception occured for customerId = {0}, \nMessage:\n{1}", customerId, e.Message);
                }

                Console.Write(result);
                Console.Write("\nHit Enter=> ");
                var opt = Console.ReadLine();
                Console.WriteLine();
            
        }
    }
}
