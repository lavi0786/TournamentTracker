using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using Dapper;

namespace TrackerLibrary.DataAccess
{
 //   @PlaceNumber int,
	//@PlaceName nvarchar(50),
	//@PrizeAmount money,
 //   @PrizePercentage float,
	//@id int = 0 output
    public class SqlConnector : IDataConnection
    {   //TODO - Make the CretePrize method actually save tot he Database
        /// <summary>
        /// saves a new prize to the database
        /// </summary>
        /// <param name="model">The Prize information.</param>
        /// <returns>The prize information, including the unique identifier.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //model.Id = 1;

            //return model;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.cnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber) ;
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@Prizeamount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", p, commandType:CommandType.StoredProcedure);

                model.Id = p.Get<int>("id");

                return model;
            }
        }
    }
}
