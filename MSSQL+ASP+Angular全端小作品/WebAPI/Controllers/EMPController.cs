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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EMPController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment  _WebHost;

        public EMPController(IConfiguration configuration , IWebHostEnvironment webHost)
        {

            _config = configuration;
            _WebHost = webHost;
        }

        [HttpGet]
        public JsonResult GET()
        {   //全部資料

            string Query = "SELECT * FROM  EMPLOYEE";                                       //準備語法

            DataTable result = new DataTable();                                      //準備(空的)資料表

            string ConnStr = _config.GetConnectionString("EmployeeConn");           // 準備連線字串

            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {              //準備好連線管道

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
        public JsonResult POST(EMP new_emp)
        {     //新增單筆資料

            string Query = "INSERT INTO EMPLOYEE(NAME,DEP,HRD,PHOTO_FILE) VALUES (@Para0 , @Para1 , @Para2 , @Para3 )";                 //這邊的寫法與上述不同          

            DataTable result = new DataTable();

            string ConnStr = _config.GetConnectionString("EmployeeConn");

            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {

                Conn.Open();

                SqlCommand command = new SqlCommand(Query, Conn);

                command.Parameters.AddWithValue("@Para0", new_emp.NAME);                //多加了此行
                command.Parameters.AddWithValue("@Para1", new_emp.DEP);                //多加了此行
                command.Parameters.AddWithValue("@Para2", new_emp.HRD);                //多加了此行
                command.Parameters.AddWithValue("@Para3", new_emp.PHOTO_FILE);         //多加了此行


                SqlDataReader dr = command.ExecuteReader();

                result.Load(dr);

                Conn.Close();
                dr.Close();

            }

            return new JsonResult("成功加入到資料庫中(*´∀`)~♥");

        }

        [HttpPut]
        public JsonResult PUT(EMP new_emp)    //更新單筆資料
        {
            string Query = "UPDATE EMPLOYEE SET NAME=@Para0, DEP=@Para1, HRD=@Para2, PHOTO_FILE=@Para3  WHERE ID = @Para4";                             //這邊的寫法與上述不同          

            DataTable result = new DataTable();

            string ConnStr = _config.GetConnectionString("EmployeeConn");

            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {

                Conn.Open();

                SqlCommand command = new SqlCommand(Query, Conn);

                command.Parameters.AddWithValue("@Para0", new_emp.NAME);               //多加了此行
                command.Parameters.AddWithValue("@Para1", new_emp.DEP);                //多加了此行
                command.Parameters.AddWithValue("@Para2", new_emp.HRD);                //多加了此行
                command.Parameters.AddWithValue("@Para3", new_emp.PHOTO_FILE);         //多加了此行
                command.Parameters.AddWithValue("@Para4", new_emp.ID);                  //多加了此行


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
            string Query = "DELETE  FROM EMPLOYEE WHERE ID = @Para0 ";                             //這邊的寫法與上述不同          

            DataTable result = new DataTable();

            string ConnStr = _config.GetConnectionString("EmployeeConn");

            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {

                Conn.Open();

                SqlCommand command = new SqlCommand(Query, Conn);

                command.Parameters.AddWithValue("@Para0", id);                //此行參數型態改變


                SqlDataReader dr = command.ExecuteReader();

                result.Load(dr);

                Conn.Close();
                dr.Close();

            }

            return new JsonResult("資料上天堂了。･ﾟ･(つд`ﾟ)･ﾟ･");

        }


        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile() {

            try{

                var httpRequest = Request.Form;                         //表單送出資料後，我們可以在controller中使用Request.Form來接收參數
                var PostFile = httpRequest.Files[0];                    //取得用戶端所上傳的檔案圖片(集合)，其格式為多重 MIME
                string filename = PostFile.FileName;                    //從前端傳來的form檔中，拿取fileName檔案名稱(含副檔名)字段
                var PhysicalPath = _WebHost.ContentRootPath + "/Photos/" + filename;    //組合字段，_WebHost.ContentRootPath代表此檔在畚箕的絕對路徑

                using (var stream = new FileStream(PhysicalPath, FileMode.Create)) {          //建立檔案

                    PostFile.CopyTo(stream);                                                  // 再將圖片存進stream中
                
                }

                return new JsonResult(filename);                                            //回傳檔名

            }
            catch(Exception){

                return new JsonResult("anonymous.svg");

            }
        
        }

        [Route("GetTotalDepName")]
        [HttpGet]
        public JsonResult AllDep()
        {   //全部資料

            string Query = "SELECT DEP_NAME FROM  DEP";                                      

            DataTable result = new DataTable();                                     
            string ConnStr = _config.GetConnectionString("EmployeeConn");           

            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {            

                Conn.Open();                                                      

                SqlCommand command = new SqlCommand(Query, Conn);                 

                SqlDataReader dr = command.ExecuteReader();                     

                result.Load(dr);                                              

                Conn.Close();                                                   
                dr.Close();                                               

            }

            return new JsonResult(result);

        }

    }
}
