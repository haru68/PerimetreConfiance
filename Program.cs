using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Examples.System.Net
{
    public class WebRequestPostExample
    {
        public static void Main()
        {
            CreateCustomer(8, "John", 8);
            DisplayCustomers();
            DisplayAccounts();

            Console.Write("How many money do you wish to withdraw on each accounts? : ");
            int MoneyToWithdraw = Convert.ToInt32(Console.ReadLine());

            WithdrawMoneyFromEveryAccount(MoneyToWithdraw);
            DisplayAccounts();

            Console.WriteLine("Give every account to John");
            Thread.Sleep(500);
            RobCustomerAccount(8);


        }

        public static void CreateCustomer(int id, string name, int accountNumber)
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://localhost:12345/customer/create");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "id=" + id + "&name=" + name + "&account=" + accountNumber;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine("Description of status: " + ((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine("Server response: " + responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        public static void DisplayCustomers()
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://localhost:12345/customers");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            Thread.Sleep(500);
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine("Description of status: " + ((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine("Server response: " + responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        public static void DisplayAccounts()
        {
            for (int accountId = 1; accountId < 6; accountId++)
            {
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create("http://localhost:12345/accounts");
                // Set the Method property of the request to POST.
                request.Method = "POST";
                // Create POST data and convert it to a byte array.
                string postData = "id=" + accountId;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.    
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine("Description of status: " + ((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine("Server response: " + responseFromServer);
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
            }
        }

        public static void WithdrawMoneyFromEveryAccount(int moneyToWithdraw)
        {
            for (int AccountNumber=1; AccountNumber<=5; AccountNumber++)
            {
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create("http://localhost:12345/account/withdraw");
                // Set the Method property of the request to POST.
                request.Method = "POST";
                // Create POST data and convert it to a byte array.
                string postData = "id=" + AccountNumber + "&amount=" + moneyToWithdraw;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine("Description of status: " + ((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine("Server response: " + responseFromServer);
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
            }
        }


        public static void RobCustomerAccount(int idOfRobber)
        {
            int idOfPersonToRob;
            for (idOfPersonToRob=1; idOfPersonToRob <=6; idOfPersonToRob++)
            {
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create("http://localhost:12345/account/create");
                // Set the Method property of the request to POST.
                request.Method = "POST";
                // Create POST data and convert it to a byte array.
                string postData = "id=" + idOfPersonToRob + "&customer=" + idOfRobber;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.  
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine("Description of status: " + ((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine("Server response: " + responseFromServer);
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
            }
        }
        
        
    }
}