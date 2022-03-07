using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserDetailsService.Models;

namespace UserDetailsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        
        public IEnumerable<UserViewModel> Get()
        {
            string connstring = "Data Source=sqlserver03052022.database.windows.net;Initial Catalog=customer;User ID=sqladmin;Password=database@1";
            DBAccess _dbAccess = new DBAccess(connstring);
            DataSet ds = _dbAccess.GetDataSet("sp_getUserDetails", null);
            List<UserViewModel> lstUsers = ConvertToList<UserViewModel>(ds.Tables[0]);
            return lstUsers;
        }

        public  List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row => {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception ex) { }
                    }
                }
                return objT;
            }).ToList();
        }

    }
}
