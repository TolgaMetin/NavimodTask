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
                            quote.Zip = Convert.ToInt32(dataReader["Zip"] != DBNull.Value ? dataReader["Zip"] :0);
                            quote.PackageType = dataReader["PackageType"].ToString();
                            quote.Quantity = Convert.ToInt32(dataReader["Quantity"] != DBNull.Value ? dataReader["Quantity"] : 0);
                            quote.Lenght = Convert.ToInt32(dataReader["Lenght"] != DBNull.Value ? dataReader["Lenght"] : 0);
                            quote.Width = Convert.ToInt32(dataReader["Width"] != DBNull.Value ? dataReader["Width"] : 0);
                            quote.Height = Convert.ToInt32(dataReader["Height"] != DBNull.Value ? dataReader["Height"] : 0);
                            quote.UnitHeight = dataReader["UnitHeight"].ToString();
                            quote.Weight = Convert.ToInt32(dataReader["Weight"] != DBNull.Value ? dataReader["Weight"] : 0);
                            quote.UnitWeight = dataReader["UnitWeight"].ToString();
                            quote.CargoDescription = dataReader["CargoDescription"].ToString();
                            quote.IsHazardous = Convert.ToBoolean(dataReader["IsHazardous"] != DBNull.Value ? dataReader["IsHazardous"] : 0);
                            quote.IsEventCargo = Convert.ToBoolean(dataReader["IsEventCargo"] != DBNull.Value ? dataReader["IsEventCargo"] : 0);
                            quote.IsPersonalGoods = Convert.ToBoolean(dataReader["IsPersonalGoods"] != DBNull.Value ? dataReader["IsPersonalGoods"] : 0);
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
                    command.Parameters.AddWithValue("@DestinationCity", quote.DestinationCity != null ? quote.DestinationCity : DBNull.Value);

                    SqlParameter sqlParameterZip = new SqlParameter();
                    command.Parameters.AddWithValue("@Zip", quote.Zip != 0 ? quote.Zip : 0);

                    SqlParameter sqlParameterPackageType = new SqlParameter();
                    sqlParameterPackageType.ParameterName = "@PackageType";
                    sqlParameterPackageType.Value = quote.PackageType != null ? quote.PackageType : DBNull.Value;
                    command.Parameters.Add(sqlParameterPackageType);

                    SqlParameter sqlParameterQuantity = new SqlParameter();
                    command.Parameters.AddWithValue("@Quantity", quote.Quantity != 0 ? quote.Quantity : 0);

                    SqlParameter sqlParameterLenght = new SqlParameter();
                    command.Parameters.AddWithValue("@Lenght", quote.Lenght != 0 ? quote.Lenght : 0);

                    SqlParameter sqlParameterWidth = new SqlParameter();
                    command.Parameters.AddWithValue("@Width", quote.Width != 0 ? quote.Width : 0);

                    SqlParameter sqlParameterHeight = new SqlParameter();
                    command.Parameters.AddWithValue("@Height", quote.Height != 0 ? quote.Height : 0);

                    SqlParameter sqlParameterUnitHeight = new SqlParameter();
                    sqlParameterUnitHeight.ParameterName = "@UnitHeight";
                    sqlParameterUnitHeight.Value = quote.UnitHeight != null ? quote.UnitHeight : DBNull.Value;
                    command.Parameters.Add(sqlParameterUnitHeight);

                    SqlParameter sqlParameterWeight = new SqlParameter();
                    command.Parameters.AddWithValue("@Weight", quote.Weight != 0 ? quote.Weight : 0);

                    SqlParameter sqlParameterUnitWeight = new SqlParameter();
                    sqlParameterUnitWeight.ParameterName = "@UnitWeight";
                    sqlParameterUnitWeight.Value = quote.UnitWeight != null ? quote.UnitWeight : DBNull.Value; ;
                    command.Parameters.Add(sqlParameterUnitWeight);

                    SqlParameter sqlParameterCargoDescription = new SqlParameter();
                    sqlParameterCargoDescription.ParameterName = "@CargoDescription";
                    sqlParameterCargoDescription.Value = quote.CargoDescription != null ? quote.CargoDescription : DBNull.Value;
                    command.Parameters.Add(sqlParameterCargoDescription);

                    SqlParameter sqlParameterIsHazardous= new SqlParameter();
                    sqlParameterIsHazardous.ParameterName = "@IsHazardous";
                    sqlParameterIsHazardous.Value = quote.IsHazardous;
                    command.Parameters.Add(sqlParameterIsHazardous);

                    SqlParameter sqlParameterIsEventCargo = new SqlParameter();
                    sqlParameterIsEventCargo.ParameterName = "@IsEventCargo";
                    sqlParameterIsEventCargo.Value = quote.IsEventCargo;
                    command.Parameters.Add(sqlParameterIsEventCargo);

                    SqlParameter sqlParameterIsPersonalGoods = new SqlParameter();
                    sqlParameterIsPersonalGoods.ParameterName = "@IsPersonalGoods";
                    sqlParameterIsPersonalGoods.Value = quote.IsPersonalGoods;
                    command.Parameters.Add(sqlParameterIsPersonalGoods);

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
