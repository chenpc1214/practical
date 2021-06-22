using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DEPController : ControllerBase
    {
        private readonly IConfiguration  _config;

        public DEPController(IConfiguration configuration) {

            _config = configuration;
        }

        [HttpGet]
        public JsonResult GET() {   //全部資料

            string Query = "SELECT * FROM  DEP";                                       //準備語法

            DataTable result = new DataTable();                                      //準備(空的)資料表

            string ConnStr = _config.GetConnectionString("EmployeeConn");           // 準備連線字串

            using (SqlConnection Conn = new SqlConnection(ConnStr)) {              //準備好連線管道

                Conn.Open();                                                       //開啟通道

                SqlCommand command = new SqlCommand(Query, Conn);                 //針對這個管道，下指令

                SqlDataReader dr = command.ExecuteReader();                      //執行SQL指令，拿到資料

                result.Load(dr);                                                 //將資料載入到空的資料表中

                Conn.Close();                                                   //先關通道
                dr.Close();                                                     //在關拿資料的語法

            }

            return new JsonResult(result);
        
        }

        [HttpPost]
        public JsonResult POST(DEP new_dep) {     //新增單筆資料

            string Query = "INSERT INTO DEP VALUES ( @Para0 )";                             //這邊的寫法與上述不同          

            DataTable result = new DataTable();                                      

            string ConnStr = _config.GetConnectionString("EmployeeConn");           

            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {              

                Conn.Open();                                                       

                SqlCommand command = new SqlCommand(Query, Conn);

                command.Parameters.AddWithValue("@Para0", new_dep.DEP_NAME);                //多加了此行



                /*上述寫法等同於：
                 * 
                 * command.Parameters.Add("@Paa0", SqlDbType.VarChar,new_dep.DEP_NAME);
                 * 或
                 * command.Parameters["@Para0"].Value = new_dep.DEP_NAME
                 */

                SqlDataReader dr = command.ExecuteReader();                      

                result.Load(dr);                                                 

                Conn.Close();                                                   
                dr.Close();                                                     

            }

            return new JsonResult("成功加入到資料庫中(*´∀`)~♥");

        }

        [HttpPut]
        public JsonResult PUT(DEP new_dep)    //更新單筆資料
        {     
            string Query = "UPDATE DEP SET DEP_NAME = @Para0 WHERE DEP_ID = @Para1";                             //這邊的寫法與上述不同          

            DataTable result = new DataTable();

            string ConnStr = _config.GetConnectionString("EmployeeConn");

            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {

                Conn.Open();

                SqlCommand command = new SqlCommand(Query, Conn);

                command.Parameters.AddWithValue("@Para0", new_dep.DEP_NAME);               
                command.Parameters.AddWithValue("@Para1", new_dep.DEP_ID);                //多加了此行


                /*上述寫法等同於：
                 * 
                 * command.Parameters.Add("@Paa0", SqlDbType.VarChar,new_dep.DEP_NAME);
                 * command.Parameters.Add("@Paa1", SqlDbType.Int,new_dep.DEP_ID);
                 * 或
                 * command.Parameters["@Para0"].Value = new_dep.DEP_NAME
                 * command.Parameters["@Para1"].Value = new_dep.DEP_ID
                 */

                SqlDataReader dr = command.ExecuteReader();

                result.Load(dr);

                Conn.Close();
                dr.Close();

            }

            return new JsonResult("成功更新資料~~(｡◕∀◕｡)");

        }

        [HttpDelete("{id}")]                 //QueryString方式刪除
        public JsonResult Delete(int id)    //刪除單筆資料
        {
            string Query = "DELETE  FROM DEP WHERE DEP_ID = @Para0 ";                             //這邊的寫法與上述不同          

            DataTable result = new DataTable();

            string ConnStr = _config.GetConnectionString("EmployeeConn");

            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {

                Conn.Open();

                SqlCommand command = new SqlCommand(Query, Conn);

                command.Parameters.AddWithValue("@Para0", id);                //此行參數型態改變


                /*上述寫法等同於：
                 * 
                 * command.Parameters.Add("@Para0", SqlDbType.Int,new_dep.DEP_ID);
                 * 或
                 * command.Parameters["@Para0"].Value = new_dep.DEP_ID;
                 */

                SqlDataReader dr = command.ExecuteReader();

                result.Load(dr);

                Conn.Close();
                dr.Close();

            }

            return new JsonResult("資料上天堂了。･ﾟ･(つд`ﾟ)･ﾟ･");

        }

    }
}
