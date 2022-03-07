using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UserDetailsService.Models;

namespace UserDetailsService.middleware
{
    public class BLayer
    {
        public enum ConnectionType { 
            SQLCLIENT,
            ORM
        }
        customerContext dbContext = new customerContext();
        public List<UserViewModel> GetUsers(ConnectionType connectionType) {
            string connstring = "Data Source=sqlserver03052022.database.windows.net;Initial Catalog=customer;User ID=sqladmin;Password=database@1";
            List<UserViewModel> lstUsers = new List<UserViewModel>();
            switch (connectionType) {
                case ConnectionType.SQLCLIENT:
                    DBAccess _dbAccess = new DBAccess(connstring);
                    DataSet ds = _dbAccess.GetDataSet("sp_getUserDetails", null);
                    lstUsers = ConvertToList<UserViewModel>(ds.Tables[0]);
                    break;
                case ConnectionType.ORM:
                    var v = from u in dbContext.User
                            join a in dbContext.UserAddress
                            on u.UserId equals a.UserId
                            join t in dbContext.UserType
                            on u.UserId equals t.UserId
                            select new UserViewModel
                            {
                                UserId = u.UserId,
                                fname = u.Fname,
                                mname = u.Mname,
                                lname = u.Lname,
                                DOB = u.Dob,
                                city = a.City,
                                state = a.State,
                                country = a.Country,
                                UserType = t.UserType1

                            };
                    lstUsers = v.ToList();
                    break;
            }
            return lstUsers;
        }

        public List<T> ConvertToList<T>(DataTable dt)
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
