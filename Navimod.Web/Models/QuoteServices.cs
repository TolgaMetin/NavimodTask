using Navimod.Web.Models.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Navimod.Web.Models
{
    public class QuoteServices
    {
        private SqlCommand command;
        private SqlDataReader dataReader;

        public IEnumerable<Quote> Quotes
        {
            get
            {
                List<Quote> quotes = new List<Quote>();
                using (SqlConnection connection = new SqlConnection(DbContext.navimodConnection))
                {
                    using (command = new SqlCommand("getQuote", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            Quote quote = new Quote();
                            quote.Id = Convert.ToInt32(dataReader["Id"]);
                            quote.Mode = dataReader["Mode"].ToString();
                            quote.MovementType = dataReader["MovementType"].ToString();
                            quote.Incoterm = dataReader["Incoterm"].ToString();
                            quote.OriginCountry = dataReader["OriginCountry"].ToString();
                            quote.OriginCity = dataReader["OriginCity"].ToString();
                            quote.DestinationCountry = dataReader["DestinationCountry"].ToString();
                            quote.DestinationCity = dataReader["DestinationCity"].ToString();
                            quote.Zip = Convert.ToInt32(dataReader["Zip"]);
                            quote.PackageType = dataReader["PackageType"].ToString();
                            quote.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                            quote.Lenght = Convert.ToInt32(dataReader["Lenght"]);
                            quote.Width = Convert.ToInt32(dataReader["Width"]);
                            quote.Height = Convert.ToInt32(dataReader["Height"]);
                            quote.UnitHeight = dataReader["UnitHeight"].ToString();
                            quote.Weight = Convert.ToInt32(dataReader["Weight"]);
                            quote.UnitWeight = dataReader["UnitWeight"].ToString();
                            quote.CargoDescription = dataReader["CargoDescription"].ToString();
                            quote.Currency = dataReader["Currency"].ToString();

                            quotes.Add(quote);
                        }
                    }
                    connection.Close();
                }
                return quotes;
            }

        }
        public string SaveQuote(Quote quote)
        {
            string message = string.Empty;
            int rowAfected;
            using (SqlConnection connection = new SqlConnection(DbContext.navimodConnection))
            {
                using (command = new SqlCommand("SaveQuote", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter sqlParameterMode = new SqlParameter();
                    sqlParameterMode.ParameterName = "@Mode";
                    sqlParameterMode.Value = quote.Mode != null ? quote.Mode : DBNull.Value;
                    command.Parameters.Add(sqlParameterMode);

                    SqlParameter sqlParameterMovementType = new SqlParameter();
                    sqlParameterMovementType.ParameterName = "@MovementType";
                    sqlParameterMovementType.Value = quote.MovementType != null ? quote.MovementType : DBNull.Value;
                    command.Parameters.Add(sqlParameterMovementType);

                    SqlParameter sqlParameterIncoterm = new SqlParameter();
                    sqlParameterIncoterm.ParameterName = "@Incoterm";
                    sqlParameterIncoterm.Value = quote.Incoterm != null ? quote.Incoterm : DBNull.Value;
                    command.Parameters.Add(sqlParameterIncoterm);

                    SqlParameter sqlParameterOriginCountry= new SqlParameter();
                    sqlParameterOriginCountry.ParameterName = "@OriginCountry";
                    sqlParameterOriginCountry.Value = quote.OriginCountry != null ? quote.OriginCountry : DBNull.Value;
                    command.Parameters.Add(sqlParameterOriginCountry);

                    SqlParameter sqlParameterOriginCity = new SqlParameter();
                    sqlParameterOriginCity.ParameterName = "@OriginCity";
                    sqlParameterOriginCity.Value = quote.OriginCity != null ? quote.OriginCity : DBNull.Value;
                    command.Parameters.Add(sqlParameterOriginCity);

                    SqlParameter sqlParameterDestinationCountry = new SqlParameter();
                    sqlParameterDestinationCountry.ParameterName = "@DestinationCountry";
                    sqlParameterDestinationCountry.Value = quote.DestinationCountry != null ? quote.DestinationCountry : DBNull.Value;
                    command.Parameters.Add(sqlParameterDestinationCountry);

                    SqlParameter sqlParameterDestinationCity = new SqlParameter();
                    sqlParameterDestinationCity.ParameterName = "@DestinationCity";
                    sqlParameterDestinationCity.Value = quote.DestinationCity != null ? quote.DestinationCity : DBNull.Value;
                    command.Parameters.Add(sqlParameterDestinationCity);

                    SqlParameter sqlParameterZip = new SqlParameter();
                    sqlParameterZip.ParameterName = "@Zip";
                    sqlParameterZip.Value = quote.Zip != 0 ? quote.Zip : 0;
                    command.Parameters.Add(sqlParameterZip);

                    SqlParameter sqlParameterPackageType = new SqlParameter();
                    sqlParameterPackageType.ParameterName = "@PackageType";
                    sqlParameterPackageType.Value = quote.PackageType != null ? quote.PackageType : DBNull.Value;
                    command.Parameters.Add(sqlParameterPackageType);

                    SqlParameter sqlParameterQuantity = new SqlParameter();
                    sqlParameterQuantity.ParameterName = "@Quantity";
                    sqlParameterQuantity.Value = quote.Quantity != 0 ? quote.Quantity : 0;
                    command.Parameters.Add(sqlParameterQuantity);

                    SqlParameter sqlParameterLenght = new SqlParameter();
                    sqlParameterLenght.ParameterName = "@Lenght";
                    sqlParameterLenght.Value = quote.Lenght != 0 ? quote.Lenght : 0;
                    command.Parameters.Add(sqlParameterLenght);

                    SqlParameter sqlParameterWidth = new SqlParameter();
                    sqlParameterWidth.ParameterName = "@Width";
                    sqlParameterWidth.Value = quote.Width != 0 ? quote.Width : 0;
                    command.Parameters.Add(sqlParameterWidth);

                    SqlParameter sqlParameterHeight = new SqlParameter();
                    sqlParameterHeight.ParameterName = "@Height";
                    sqlParameterHeight.Value = quote.Height != 0 ? quote.Height : 0;
                    command.Parameters.Add(sqlParameterHeight);

                    SqlParameter sqlParameterUnitHeight = new SqlParameter();
                    sqlParameterUnitHeight.ParameterName = "@UnitHeight";
                    sqlParameterUnitHeight.Value = quote.UnitHeight != null ? quote.UnitHeight : DBNull.Value;
                    command.Parameters.Add(sqlParameterUnitHeight);

                    SqlParameter sqlParameterWeight = new SqlParameter();
                    sqlParameterWeight.ParameterName = "@Weight";
                    sqlParameterWeight.Value = quote.Weight != 0 ? quote.Weight : 0;
                    command.Parameters.Add(sqlParameterWeight);

                    SqlParameter sqlParameterUnitWeight = new SqlParameter();
                    sqlParameterUnitWeight.ParameterName = "@UnitWeight";
                    sqlParameterUnitWeight.Value = quote.UnitWeight != null ? quote.UnitWeight : DBNull.Value; ;
                    command.Parameters.Add(sqlParameterUnitWeight);

                    SqlParameter sqlParameterCargoDescription = new SqlParameter();
                    sqlParameterCargoDescription.ParameterName = "@CargoDescription";
                    sqlParameterCargoDescription.Value = quote.CargoDescription != null ? quote.CargoDescription : DBNull.Value;
                    command.Parameters.Add(sqlParameterCargoDescription);

                    SqlParameter sqlParameterCurrency= new SqlParameter();
                    sqlParameterCurrency.ParameterName = "@Currency";
                    sqlParameterCurrency.Value = quote.Currency != null ? quote.Currency : DBNull.Value;
                    command.Parameters.Add(sqlParameterCurrency);

                    connection.Open();
                    rowAfected = command.ExecuteNonQuery();
                    connection.Close();
                    if (rowAfected > 0)
                    {
                        message = "Data save succesfully";
                    }
                    else
                    {
                        message = "Data save faild!";
                    }
                }
            }
            return message;
        }
        public void DeleteQuote(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbContext.navimodConnection))
            {
                using (command = new SqlCommand("DeleteQuote", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@Id";
                    sqlParameter.Value = id;
                    command.Parameters.Add(sqlParameter);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
