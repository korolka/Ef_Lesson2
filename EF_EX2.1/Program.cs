using Microsoft.EntityFrameworkCore;

namespace EF_EX2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = Values.Insert();

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {

                    context.Products.AddRange(products);
                    context.SaveChanges();
                    Console.WriteLine("Values saves");

                    context.Errors.Add(new Error()
                    {
                        AlterId = -1,
                    });

                    context.SaveChanges();

                    //foreach (var list in context.Products)
                    //{
                    //    Console.WriteLine(list.Name[-5]);
                    //}
                }
            }
            catch (Exception ex)
            {
                var error = new List<Error>()
                {
                    new Error()
                    {
                    Message = ex.Message,
                    Request = ex.HResult.ToString(),
                    Status = StatusCode.Server,
                    Time = DateTime.Now
                    }
                };
                foreach (var item in error)
                {
                    Console.WriteLine($"Message: " + item.Message);
                    Console.WriteLine($"HResult: " + item.Request);
                    Console.WriteLine($"Status: " + item.Status);
                    Console.WriteLine($"Time: " + item.Time);
                }
            };
        }


    }

}

