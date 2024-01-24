using Logistics_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Logistics_MVC.Controllers
{
    public class LogController : Controller
    {
        public IConfiguration Configuration { get; }

        public LogController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Index page
        public ActionResult Index()
        {
            List<Logistic> logs = new List<Logistic>();
            string connectionString = Configuration["ConnectionStrings:con_string"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string sql = "select * from Logistics";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        Logistic obj = new Logistic();
                        obj.Id = Convert.ToInt32(sdr["Id"]);
                        obj.ProductName = Convert.ToString(sdr["Product_name"]);
                        obj.Quantity = Convert.ToInt32(sdr["Quantity"]);
                        obj.Ownername = Convert.ToString(sdr["Ownername"]);
                        obj.PackageId = Convert.ToInt32(sdr["Package_id"]);
                        obj.PackedDate = Convert.ToDateTime(sdr["Packed_date"]);
                        obj.ExpectedDate = Convert.ToDateTime(sdr["Expected_date"]);
                        obj.Price = Convert.ToDecimal(sdr["Price"]);
                        obj.DeliveryStatus = Convert.ToString(sdr["Delivery_status"]);
                        obj.FromLocation = Convert.ToString(sdr["From_location"]);
                        obj.ToLocation = Convert.ToString(sdr["To_location"]);

                        logs.Add(obj);
                    }
                    con.Close();
                }
            }
            return View(logs);
        }
       [HttpGet]
        public ActionResult Create()
       {
        return View();
       }
      

    //Creating new record 
    public IActionResult Create(Logistic Item)

        {

            string connectionString = Configuration["ConnectionStrings:con_string"];

            using (var con = new SqlConnection(connectionString))

            {

                using (var cmd = new SqlCommand("insert_details", con))

                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_name", Item.ProductName);

                    cmd.Parameters.AddWithValue("@quan", Item.Quantity);

                    cmd.Parameters.AddWithValue("@own", Item.Ownername);

                    cmd.Parameters.AddWithValue("@packid", Item.PackageId);

                    cmd.Parameters.AddWithValue("@packdate", Item.PackedDate);

                    cmd.Parameters.AddWithValue("@expdate", Item.ExpectedDate);

                    cmd.Parameters.AddWithValue("@price", Item.Price);

                    cmd.Parameters.AddWithValue("@status", Item.DeliveryStatus);

                    cmd.Parameters.AddWithValue("@from", Item.FromLocation);

                    cmd.Parameters.AddWithValue("@to", Item.ToLocation);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();




                }

            }

            ViewBag.Result = "Success";

            return RedirectToAction("Index");

        }


        //Updating the exixting records
        [HttpGet]
        public IActionResult Update(int id)
        {
            Logistic obj = new Logistic();
            string connectionString = Configuration["ConnectionStrings:con_string"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from Logistics where Id='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        obj.Id = Convert.ToInt32(sdr["Id"]);
                        obj.ProductName = Convert.ToString(sdr["Product_name"]);
                        obj.Quantity = Convert.ToInt32(sdr["Quantity"]);
                        obj.Ownername = Convert.ToString(sdr["Ownername"]);
                        obj.PackageId = Convert.ToInt32(sdr["Package_id"]);
                        obj.PackedDate = Convert.ToDateTime(sdr["Packed_date"]);
                        obj.ExpectedDate = Convert.ToDateTime(sdr["Expected_date"]);
                        obj.Price = Convert.ToDecimal(sdr["Price"]);
                        obj.DeliveryStatus = Convert.ToString(sdr["Delivery_status"]);
                        obj.FromLocation = Convert.ToString(sdr["From_location"]);
                        obj.ToLocation = Convert.ToString(sdr["To_location"]);

                    }
                    connection.Close();
                }

            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Logistic item, int id)
        {
            string connectionString = Configuration["ConnectionStrings:con_string"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Update Logistics SET Product_name='{item.ProductName}',Quantity='{item.Quantity}',Ownername='{item.Ownername}',Package_id='{item.PackageId}',Packed_date='{item.PackedDate}',Expected_date='{item.ExpectedDate}',Price='{item.Price}',Delivery_status='{item.DeliveryStatus}',From_location='{item.FromLocation}',To_location='{item.ToLocation}' where Id='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {


                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return RedirectToAction("Index");
        }

        //Deleting the records
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Logistic obj = new Logistic();
            string connectionString = Configuration["ConnectionStrings:con_string"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from Logistics where Id='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        obj.Id = Convert.ToInt32(sdr["Id"]);
                        obj.ProductName = Convert.ToString(sdr["Product_name"]);
                        obj.Quantity = Convert.ToInt32(sdr["Quantity"]);
                        obj.Ownername = Convert.ToString(sdr["Ownername"]);
                        obj.PackageId = Convert.ToInt32(sdr["Package_id"]);
                        obj.PackedDate = Convert.ToDateTime(sdr["Packed_date"]);
                        obj.ExpectedDate = Convert.ToDateTime(sdr["Expected_date"]);
                        obj.Price = Convert.ToDecimal(sdr["Price"]);
                        obj.DeliveryStatus = Convert.ToString(sdr["Delivery_status"]);
                        obj.FromLocation = Convert.ToString(sdr["From_location"]);
                        obj.ToLocation = Convert.ToString(sdr["To_location"]);

                    }
                    connection.Close();
                }

            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(Logistic item,int id)
        {
            string connectionString = Configuration["ConnectionStrings:con_string"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Delete from Logistics where Id='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {


                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return RedirectToAction("Index");
            }
        }


        //Displaying the records by id
        [HttpGet]
        public IActionResult Details(int id)
        {
            Logistic obj = new Logistic();
            string connectionString = Configuration["ConnectionStrings:con_string"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from Logistics where Id='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        obj.Id = Convert.ToInt32(sdr["Id"]);
                        obj.ProductName = Convert.ToString(sdr["Product_name"]);
                        obj.Quantity = Convert.ToInt32(sdr["Quantity"]);
                        obj.Ownername = Convert.ToString(sdr["Ownername"]);
                        obj.PackageId = Convert.ToInt32(sdr["Package_id"]);
                        obj.PackedDate = Convert.ToDateTime(sdr["Packed_date"]);
                        obj.ExpectedDate = Convert.ToDateTime(sdr["Expected_date"]);
                        obj.Price = Convert.ToDecimal(sdr["Price"]);
                        obj.DeliveryStatus = Convert.ToString(sdr["Delivery_status"]);
                        obj.FromLocation = Convert.ToString(sdr["From_location"]);
                        obj.ToLocation = Convert.ToString(sdr["To_location"]);

                    }
                    connection.Close();
                }

            }
            return View(obj);
        }
    }
}

