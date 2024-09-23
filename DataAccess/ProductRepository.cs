using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Xml.Linq;
using ContosoShoe.models;
using Joota_House.Models;
using Microsoft.AspNetCore.Mvc;
namespace ContosoShoe.DataAccess
{
    public class ProductRepository : Repository
    {
        public ProductRepository()
        {
            ConnectionString = "Server=G1-5CD40140QD-L\\SQLEXPRESS;Database=ShoeStore;Integrated Security= true;";
            Connect(ConnectionString);
        }
        public override int Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var query = "DELETE FROM Shoes WHERE ProductID = @Id"; // Use @Id in the query

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }


        //public override IList getAll()
        //{
        //    IList<ProductViewModel> products = new List<ProductViewModel>();
        //    SqlCommand command = new SqlCommand();
        //    command.Connection = Connection;
        //    command.CommandType = CommandType.Text;
        //    command.CommandText = "SELECT * FROM Shoes";


        //    if (Connection.State != ConnectionState.Open)
        //    {
        //        Connection.Open();
        //    }

        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader != null)
        //    {
        //        while (reader.Read())
        //        {
        //            products.Add(new ProductViewModel
        //            {
        //                ProductID = reader["ProductID"] != DBNull.Value ? Convert.ToInt32(reader["ProductID"]) : 0,
        //                ProductName = reader["ProductName"] != DBNull.Value ? Convert.ToString(reader["ProductName"]) : string.Empty,
        //                ProductCategoryID = reader["ProductCategoryID"] != DBNull.Value ? Convert.ToInt32(reader["ProductCategoryID"]) : 0,
        //                ProductColor = reader["ProductColor"] != DBNull.Value ? Convert.ToString(reader["ProductColor"]) : string.Empty,
        //                ProductPrice = reader["ProductPrice"] != DBNull.Value ? Convert.ToInt32(reader["ProductPrice"]) : 0,
        //                ProductQuantityInStock = reader["ProductQuantityInStock"] != DBNull.Value ? Convert.ToInt32(reader["ProductQuantityInStock"]) : 0,
        //                ProductSize = reader["ProductSize"] != DBNull.Value ? Convert.ToInt32(reader["ProductSize"]) : 0,
        //                GenderCategory = reader["GenderCategory"] != DBNull.Value ? Convert.ToString(reader["GenderCategory"]) : string.Empty,
        //                ProductImageUrl = reader["ProductImageUrl"] != DBNull.Value ? Convert.ToString(reader["ProductImageUrl"]) : string.Empty,
        //                ProductImage = reader["ProductImage"] != DBNull.Value ? (byte[])reader["ProductImage"] : null,
        //                ProductSubCategoryID = reader["ProductSubCategoryID"] != DBNull.Value ? Convert.ToInt32(reader["ProductSubCategoryID"]) : 0,
        //                ProductQuantityAdded = reader["ProductQuantityAdded"] != DBNull.Value ? Convert.ToInt32(reader["ProductQuantityAdded"]) : 0
        //            });
        //        }
        //        return products.ToList();

        //    }
        //    return null;
        //}

        //public override ProductViewModel getById(int Id)
        //{
        //    ProductViewModel product=null;
        //    SqlCommand command = new SqlCommand();
        //    command.Connection = Connection;
        //    command.CommandType = CommandType.Text;
        //    command.CommandText = "SELECT * FROM Shoes WHERE Id = @Id";

        //    command.Parameters.AddWithValue("@Id", Id);

        //    if (Connection.State != ConnectionState.Open)
        //    {
        //        Connection.Open();
        //    }

        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader != null)
        //    {
        //        while (reader.Read())
        //        {
        //            product = (new ProductViewModel
        //            {
        //                Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
        //                Price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]):0,
        //                Name = reader["Name"] != DBNull.Value ? Convert.ToString(reader["Name"]) : string.Empty,
        //                Description = reader["Description"] != DBNull.Value ? Convert.ToString(reader["Description"]) : string.Empty,
        //                ImageUrl = reader["ImageUrl"] != DBNull.Value ? Convert.ToString(reader["ImageUrl"]) : string.Empty

        //            });
        //        }
        //        return product;
        //    }
        //    return product;
        //}

        //public override int Insert(ProductViewModel data)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandType = CommandType.Text;
        //            command.CommandText = @"
        //        INSERT INTO shoes ( Name, Price, Description, ImageUrl)
        //        VALUES ( @Name, @Price, @Description, @ImageUrl)";


        //            //command.Parameters.AddWithValue("@Id", data.Id);
        //            command.Parameters.AddWithValue("@Name", data.Name);
        //            command.Parameters.AddWithValue("@Price", data.Price);
        //            command.Parameters.AddWithValue("@Description", data.Description);
        //            command.Parameters.AddWithValue("@ImageUrl", data.ImageUrl);


        //            connection.Open();
        //            int affectedRows = command.ExecuteNonQuery();

        //            return affectedRows;
        //        }
        //    }
        //}

        //public override IList<ProductViewModel> getAll()
        //{
        //    IList<ProductViewModel> products = new List<ProductViewModel>();
        //    SqlCommand command = new SqlCommand();
        //    command.Connection = Connection;
        //    command.CommandType = CommandType.Text;
        //    command.CommandText = "SELECT * FROM Shoes"; // Use the correct table name

        //    if (Connection.State != ConnectionState.Open)
        //    {
        //        Connection.Open();
        //    }

        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader != null)
        //    {
        //        while (reader.Read())
        //        {
        //            products.Add(new ProductViewModel
        //            {
        //                ProductID = reader["ProductID"] != DBNull.Value ? Convert.ToInt32(reader["ProductID"]) : 0,
        //                ProducName = reader["ProducName"] != DBNull.Value ? Convert.ToString(reader["ProducName"]) : string.Empty,
        //                ProductCategoryID = reader["ProductCategoryID"] != DBNull.Value ? Convert.ToInt32(reader["ProductCategoryID"]) : 0,
        //                ProductColor = reader["ProductColor"] != DBNull.Value ? Convert.ToString(reader["ProductColor"]) : string.Empty,
        //                ProducPrice = reader["ProducPrice"] != DBNull.Value ? Convert.ToDecimal(reader["ProducPrice"]) : 0,
        //                ProducQuantityInStock = reader["ProducQuantityInStock"] != DBNull.Value ? Convert.ToInt32(reader["ProducQuantityInStock"]) : 0,
        //                ProducSize = reader["ProducSize"] != DBNull.Value ? Convert.ToString(reader["ProducSize"]) : string.Empty,
        //                GenderCategory = reader["GenderCategory"] != DBNull.Value ? Convert.ToString(reader["GenderCategory"]) : string.Empty,
        //                ProducImageUrl = reader["ProducImageUrl"] != DBNull.Value ? Convert.ToString(reader["ProducImageUrl"]) : string.Empty,
        //                ProductImage = reader["ProductImage"] != DBNull.Value ? (byte[])reader["ProductImage"] : null,  // Assuming the image is binary
        //                ProductSubCategoryID = reader["ProductSubCategoryID"] != DBNull.Value ? Convert.ToInt32(reader["ProductSubCategoryID"]) : 0,
        //                ProductQuantityAdded = reader["ProductQuantityAdded"] != DBNull.Value ? Convert.ToInt32(reader["ProductQuantityAdded"]) : 0
        //            });
        //        }
        //        return products.ToList();
        //    }

        //    return null;
        //}


        //public override ProductViewModel getById(int Id)
        //{
        //    ProductViewModel product = null;
        //    SqlCommand command = new SqlCommand();
        //    command.Connection = Connection;
        //    command.CommandType = CommandType.Text;
        //    command.CommandText = "SELECT * FROM Shoes WHERE ProductID = @ProductID";

        //    command.Parameters.AddWithValue("@ProductID", Id);

        //    if (Connection.State != ConnectionState.Open)
        //    {
        //        Connection.Open();
        //    }

        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader != null)
        //    {
        //        while (reader.Read())
        //        {
        //            product = new ProductViewModel
        //            {
        //                ProductID = reader["ProductID"] != DBNull.Value ? Convert.ToInt32(reader["ProductID"]) : 0,
        //                ProductName = reader["ProductName"] != DBNull.Value ? Convert.ToString(reader["ProductName"]) : string.Empty,
        //                ProductPrice = reader["ProductPrice"] != DBNull.Value ? Convert.ToInt32(reader["ProductPrice"]) : 0,
        //                ProductQuantityInStock = reader["ProductQuantityInStock"] != DBNull.Value ? Convert.ToInt32(reader["ProductQuantityInStock"]) : 0,
        //                ProductImageUrl = reader["ProductImageUrl"] != DBNull.Value ? Convert.ToString(reader["ProductImageUrl"]) : string.Empty,
        //                ProductSize = reader["ProductSize"] != DBNull.Value ? Convert.ToInt32(reader["ProductSize"]) : 0,
        //                GenderCategory = reader["GenderCategory"] != DBNull.Value ? Convert.ToString(reader["GenderCategory"]) : string.Empty,
        //                ProductImage = reader["ProductImage"] != DBNull.Value ? (byte[])reader["ProductImage"] : null,
        //                ProductSubCategoryID = reader["ProductSubCategoryID"] != DBNull.Value ? Convert.ToInt32(reader["ProductSubCategoryID"]) : 0,
        //                ProductCategoryID = reader["ProductCategoryID"] != DBNull.Value ? Convert.ToInt32(reader["ProductCategoryID"]) : 0,
        //                ProductColor = reader["ProductColor"] != DBNull.Value ? Convert.ToString(reader["ProductColor"]) : string.Empty,
        //                ProductQuantityAdded = reader["ProductQuantityAdded"] != DBNull.Value ? Convert.ToInt32(reader["ProductQuantityAdded"]) : 0
        //            };
        //        }
        //    }

        //    reader.Close();
        //    Connection.Close();

        //    return product;
        //}

        public override IList<ProductViewModel> getAll()
        {
            IList<ProductViewModel> products = new List<ProductViewModel>();
            SqlCommand command = new SqlCommand();
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM Shoes";

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        products.Add(new ProductViewModel
                        {
                            ProductID = reader["ProductID"] != DBNull.Value ? Convert.ToInt32(reader["ProductID"]) : 0,
                            ProductName = reader["ProductName"] != DBNull.Value ? Convert.ToString(reader["ProductName"]) : string.Empty,
                            ProductCategoryID = reader["ProductCategoryID"] != DBNull.Value ? Convert.ToInt32(reader["ProductCategoryID"]) : 0,
                            ProductColor = reader["ProductColor"] != DBNull.Value ? Convert.ToString(reader["ProductColor"]) : string.Empty,
                            ProductPrice = reader["ProductPrice"] != DBNull.Value ? Convert.ToInt32(reader["ProductPrice"]) : 0,
                            ProductQuantityInStock = reader["ProductQuantityInStock"] != DBNull.Value ? Convert.ToInt32(reader["ProductQuantityInStock"]) : 0,
                            ProductSize = reader["ProductSize"] != DBNull.Value ? Convert.ToInt32(reader["ProductSize"]) : 0,
                            GenderCategory = reader["GenderCategory"] != DBNull.Value ? Convert.ToString(reader["GenderCategory"]) : string.Empty,
                            ProductImageUrl = reader["ProductImageUrl"] != DBNull.Value ? Convert.ToString(reader["ProductImageUrl"]) : string.Empty,
                            ProductImage = reader["ProductImage"] != DBNull.Value ? (byte[])reader["ProductImage"] : null,
                            ProductSubCategoryID = reader["ProductSubCategoryID"] != DBNull.Value ? Convert.ToInt32(reader["ProductSubCategoryID"]) : 0,
                            ProductQuantityAdded = reader["ProductQuantityAdded"] != DBNull.Value ? Convert.ToInt32(reader["ProductQuantityAdded"]) : 0
                        });
                    }
                }
            }

            return products; 
        }


        public override ProductViewModel getById(int Id)
        {
            ProductViewModel product = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Shoes WHERE ProductID = @ProductID", connection))
                {
                    command.Parameters.AddWithValue("@ProductID", Id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) // Check if there are any rows
                        {
                            while (reader.Read())
                            {
                                product = new ProductViewModel
                                {
                                    ProductID = reader["ProductID"] != DBNull.Value ? Convert.ToInt32(reader["ProductID"]) : 0,
                                    ProductName = reader["ProductName"] != DBNull.Value ? Convert.ToString(reader["ProductName"]) : string.Empty,
                                    ProductPrice = reader["ProductPrice"] != DBNull.Value ? Convert.ToInt32(reader["ProductPrice"]) : 0, 
                                    ProductQuantityInStock = reader["ProductQuantityInStock"] != DBNull.Value ? Convert.ToInt32(reader["ProductQuantityInStock"]) : 0,
                                    ProductImageUrl = reader["ProductImageUrl"] != DBNull.Value ? Convert.ToString(reader["ProductImageUrl"]) : string.Empty,
                                    ProductSize = reader["ProductSize"] != DBNull.Value ? Convert.ToInt32(reader["ProductSize"]) : 0,
                                    GenderCategory = reader["GenderCategory"] != DBNull.Value ? Convert.ToString(reader["GenderCategory"]) : string.Empty,
                                    ProductSubCategoryID = reader["ProductSubCategoryID"] != DBNull.Value ? Convert.ToInt32(reader["ProductSubCategoryID"]) : 0,
                                    ProductCategoryID = reader["ProductCategoryID"] != DBNull.Value ? Convert.ToInt32(reader["ProductCategoryID"]) : 0,
                                    ProductColor = reader["ProductColor"] != DBNull.Value ? Convert.ToString(reader["ProductColor"]) : string.Empty,
                                };
                            }
                        }
                    }
                }
            }

            return product;
        }

        public override int Insert(ProductViewModel data)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    // Updated SQL query to insert all the new columns
                    command.CommandText = @"
            INSERT INTO Shoes 
            (ProductName, ProductPrice, ProductQuantityInStock, ProductImageUrl, ProductSize, GenderCategory, ProductSubCategoryID, ProductCategoryID, ProductColor)
            VALUES 
            (@ProductName, @ProductPrice, @ProductQuantityInStock, @ProductImageUrl, @ProductSize, @GenderCategory, @ProductSubCategoryID, @ProductCategoryID, @ProductColor)";

                    command.Parameters.AddWithValue("@ProductName", data.ProductName);
                    command.Parameters.AddWithValue("@ProductPrice", data.ProductPrice);
                    command.Parameters.AddWithValue("@ProductQuantityInStock", data.ProductQuantityInStock);
                    command.Parameters.AddWithValue("@ProductImageUrl", data.ProductImageUrl);
                    command.Parameters.AddWithValue("@ProductSize", data.ProductSize);
                    command.Parameters.AddWithValue("@GenderCategory", data.GenderCategory);
                    command.Parameters.AddWithValue("@ProductSubCategoryID", data.ProductSubCategoryID);
                    command.Parameters.AddWithValue("@ProductCategoryID", data.ProductCategoryID);
                    command.Parameters.AddWithValue("@ProductColor", data.ProductColor);

                    connection.Open();
                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows;
                }
            }
        }

        //public override int Update(int id,ProductViewModel model)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        var query = @"UPDATE Shoes 
        //              SET Name = @Name, 
        //                  Price = @Price, 
        //                  Description = @Description, 
        //                  ImageUrl = @ImageUrl
        //              WHERE Id = @id";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Name", model.Name);
        //            command.Parameters.AddWithValue("@Price", model.Price);
        //            command.Parameters.AddWithValue("@Description", model.Description);
        //            command.Parameters.AddWithValue("@ImageUrl", model.ImageUrl);
        //            command.Parameters.AddWithValue("@Id", id);

        //            connection.Open();
        //            return command.ExecuteNonQuery();
        //        }
        //        return 0;
        //    }
        //}
        public override int Update(int id, ProductViewModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                    var query = @"
                    UPDATE Shoes 
                    SET 
                        ProductName = @ProductName, 
                        ProductPrice = @ProductPrice, 
                        ProductQuantityInStock = @ProductQuantityInStock, 
                        ProductImageUrl = @ProductImageUrl, 
                        ProductSize = @ProductSize, 
                        GenderCategory = @GenderCategory, 
                        ProductSubCategoryID = @ProductSubCategoryID, 
                        ProductCategoryID = @ProductCategoryID, 
                        ProductColor = @ProductColor 
                    WHERE ProductID = @ProductID"; 

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters for the updated fields
                    command.Parameters.AddWithValue("@ProductName", model.ProductName);
                    command.Parameters.AddWithValue("@ProductPrice", model.ProductPrice);
                    command.Parameters.AddWithValue("@ProductQuantityInStock", model.ProductQuantityInStock);
                    command.Parameters.AddWithValue("@ProductImageUrl", model.ProductImageUrl);
                    command.Parameters.AddWithValue("@ProductSize", model.ProductSize);
                    command.Parameters.AddWithValue("@GenderCategory", model.GenderCategory);
                    command.Parameters.AddWithValue("@ProductSubCategoryID", model.ProductSubCategoryID);
                    command.Parameters.AddWithValue("@ProductCategoryID", model.ProductCategoryID);
                    command.Parameters.AddWithValue("@ProductColor", model.ProductColor);
                    command.Parameters.AddWithValue("@ProductID", id);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }


        public IList<CategoryCount> getbyCategory()
        {
            IList<CategoryCount> categoryCount = new List<CategoryCount>();
            SqlCommand command = new SqlCommand();
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            command.CommandText = @"
        SELECT c.ProductCategoryName, COUNT(p.ProductCategoryID) AS ProductCount
        FROM Category c
        LEFT JOIN Shoes p ON c.ProductCategoryID = p.ProductCategoryID
        GROUP BY c.ProductCategoryName;
    ";

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            SqlDataReader reader = command.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    categoryCount.Add(new CategoryCount
                    {
                        ProductCategoryName = reader["ProductCategoryName"] != DBNull.Value ? Convert.ToString(reader["ProductCategoryName"]) : string.Empty,
                        ProductCategoryCount = reader["ProductCount"] != DBNull.Value ? Convert.ToInt32(reader["ProductCount"]) : 0 // Changed to match the SQL query alias
                    });
                }
                return categoryCount.ToList();
            }
            return null;
        }

        public IList<ProductCategory> GetCategory()
        {
            IList<ProductCategory> categories = new List<ProductCategory>();
            SqlCommand command = new SqlCommand();
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM Category";

            try
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            categories.Add(new ProductCategory
                            {
                                ProductCategoryID = reader["ProductCategoryID"] != DBNull.Value ? Convert.ToInt32(reader["ProductCategoryID"]) : 0,
                                ProductCategoryName = reader["ProductCategoryName"] != DBNull.Value ? Convert.ToString(reader["ProductCategoryName"]) : string.Empty
                            });
                        }
                    }
                }
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return categories; 
        }

        public IList<ProductSubCategory> GetSubCategory()
        {
            IList<ProductSubCategory> subcategories = new List<ProductSubCategory>();
            SqlCommand command = new SqlCommand();
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM SubCategory";

            try
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            subcategories.Add(new ProductSubCategory
                            {
                                ProductSubCategoryID = reader["ProductSubCategoryID"] != DBNull.Value ? Convert.ToInt32(reader["ProductSubCategoryID"]) : 0,
                                ProductSubCategoryName = reader["ProductSubCategoryName"] != DBNull.Value ? Convert.ToString(reader["ProductSubCategoryName"]) : string.Empty
                            });
                        }
                    }
                }
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return subcategories;
        }

        public async Task<IList<PastOrderViewModel>> PastOrders()
        {
            var orders = new List<PastOrderViewModel>();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"
            SELECT o.OrderID, o.CustomerID, o.OrderDate, o.TotalAmount, o.ShippingAddress, o.PaymentStatus, o.OrderStatus, 
                   od.ProductID, od.ProductCount, od.ProductAmount 
            FROM Orders o 
            JOIN OrderDetails od ON o.OrderID = od.OrderID 
            ORDER BY o.OrderDate DESC";

                if (Connection.State != ConnectionState.Open)
                {
                    await Connection.OpenAsync();
                }

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var orderID = reader.GetInt32(0);
                        var existingOrder = orders.FirstOrDefault(o => o.OrderID == orderID);

                        if (existingOrder == null)
                        {
                            existingOrder = new PastOrderViewModel
                            {
                                OrderID = orderID,
                                CustomerID = reader.GetInt32(1),
                                OrderDate = reader.GetDateTime(2),
                                TotalAmount = reader.GetInt32(3),  
                                ShippingAddress = reader.GetString(4),
                                PaymentStatus = reader.GetString(5),
                                OrderStatus = reader.GetString(6),
                                OrderDetails = new List<OrderDetailViewModel>()
                            };
                            orders.Add(existingOrder);
                        }

                        existingOrder.OrderDetails.Add(new OrderDetailViewModel
                        {
                            ProductID = reader.GetInt32(7),
                            ProductCount = reader.GetInt32(8),
                            ProductAmount = reader.GetInt32(9)
                        });
                    }
                }

                if (Connection.State == ConnectionState.Open)
                {
                    await Connection.CloseAsync();
                }
            }

            return orders;
        }

    }
}



