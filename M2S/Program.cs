using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using Proj4Net;

namespace M2S
{
    class Program
    {
        private static List<string> Building = new List<string>(); //<bldg:Building gml:id="id_7e2939fb-eda4-4ee2-8453-69e2aeaeaeca">
        private static List<string> BuildingValue = new List<string>(); //<gen:value>DC00014466</gen:value>

        static bool first = false;

        private static int Count = 10;

        static String this_gen_Value = "";//記錄目前位置的編號
        static String this_bldg_Building = "";

        static void Main(string[] args)
        {

            Building.Clear();
            BuildingValue.Clear();
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("======================================================================================================");
            if (args.Length > 0)
            {
                first = true;
                // Read the file and display it line by line.  
                //System.IO.StreamReader file =
                //    new System.IO.StreamReader(args[0]);
                //while ((line = file.ReadLine()) != null)
                //{
                //    System.Console.WriteLine(line);
                //    counter++;
                //}

                //file.Close();
                //System.Console.WriteLine("There were {0} lines.", counter);
                //// Suspend the screen.  
                //System.Console.ReadLine();
                ReadXml_File(args[0]);
            }
            //Console.WriteLine("======================================================================================================");
            //Console.WriteLine("======================================================================================================");
            //Console.WriteLine("======================================================================================================");
            //Console.WriteLine("======================================================================================================");
            //Console.WriteLine("======================================================================================================");

            //Console.WriteLine("Building Count : " + Building.Count);
            //for (int i = 0; i < Building.Count; i++)
            //{
            //    Console.WriteLine("Building=" + Building[i]);

            //}
            //Console.WriteLine("======================================================================================================");
            //Console.WriteLine("======================================================================================================");
            //for (int i = 0; i < BuildingValue.Count; i++)
            //{
            //    Console.WriteLine("BuildingValue=" + BuildingValue[i]);

            //}

            //Console.WriteLine("======================================================================================================");
            //Console.WriteLine("======================================================================================================");

            //在本地建立資料夾
            //for (int i = 0; i < Building.Count; i++)
            //{
            //    //參考資料 https://docs.microsoft.com/zh-tw/dotnet/api/system.io.directory.createdirectory?redirectedfrom=MSDN&view=netframework-4.7.2#System_IO_Directory_CreateDirectory_System_String_
            //    if (Directory.Exists(Building[i]))
            //    {
            //       // return;
            //    }else
            //    {
            //        // Try to create the directory.
            //        DirectoryInfo di = Directory.CreateDirectory(Building[i]);//建立資料夾
            //    }


            //}

            //Console.WriteLine("======================================================================================================");
            //在建立 e3d
            //for (int i = 0; i < BuildingValue.Count; i++)
            //{
            //    //string path = @"D:\iProject\107_專案\Testbed14\Much2SingleBuilding\M2S\M2S\bin\Debug\" +;
            //    //參考資料 https://docs.microsoft.com/zh-tw/dotnet/api/system.io.file.create?redirectedfrom=MSDN&view=netframework-4.7.2#System_IO_File_Create_System_String_
            //    Console.WriteLine(Building[i] + "\\" + BuildingValue[i] + ".e3d");
            //    // Create the file.
            //    if(!File.Exists(Building[i] + "\\" + BuildingValue[i] + ".e3d"))
            //    {
            //        File.Create(Building[i] + "\\" + BuildingValue[i] + ".e3d");
            //    }

            //}
            //Console.WriteLine("======================================================================================================");
            //Console.WriteLine("======================================================================================================");

            //建位 e3d 資料
            //for (int i = 0; i < Building.Count; i++)
            //{
            //    try
            //    {
            //        String PATH = System.Windows.Forms.Application.StartupPath;
            //        //String p1 = PATH + @"\" + Building[i] + @"\" + BuildingValue[i].ToUpper() + ".txt";
            //        //String p2 = PATH + @"\" + Building[i] + @"\" + BuildingValue[i].ToUpper() + ".e3d";
            //        String p1 = PATH + @"\e3d\" + BuildingValue[i].ToUpper() + ".txt";
            //        String p2 = PATH + @"\e3d\" + BuildingValue[i].ToUpper() + ".e3d";
            //        //String url = PATH + @"\trasfer\c2e.exe";
            //        String url = @"D:\Samples\Debug\trasfer\c2e.exe";//測試
            //        ProcessStartInfo startInfo = new ProcessStartInfo();
            //        startInfo.FileName = url;
            //        startInfo.Arguments = p1 + " " + p2;
            //        startInfo.CreateNoWindow = false;

            //        Process.Start(startInfo);

            //        double[][] latlng = CalculationBBox(PATH + @"\e3d\" + BuildingValue[i].ToUpper() + ".txt");
            //        //坐標轉換
            //        double[] x = { latlng[0][0] };//long
            //        double[] y = { latlng[0][1] };//lat
            //        double[] z = new double[x.Length];//
            //        double[] latlng_even = CoordinateSystemsTransformations(x, y, z);

            //        String sql = @"INSERT INTO city_table
            //                    (
            //                        id,
            //                        value,
            //                        point
            //                    )
            //                    VALUES
            //                    (
            //                     @id,
            //                     @value,
            //                     ST_GeomFromText(@point,4326)
            //                    )";
            //        string id = Building[i];
            //        string value = BuildingValue[i].ToUpper();
            //        string point = "POINT(" + latlng_even[0] + " " + latlng_even[1] + ")";
            //        bool success = Npgsql_Data(sql, id, value, point);
            //        if (success)
            //        {
            //            Console.WriteLine("id : " + Building[i] + " 寫入成功！");
            //        }
            //        else
            //        {
            //            Console.WriteLine("id : " + Building[i] + " 寫入失敗！");
            //        }

            //        //Console.WriteLine("Process : " + p1);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}

            //建立完 e3d 後，算出每棟建築物的 BBox
            //for (int i = 0; i < Building.Count; i++)
            //{
            //    String PATH = System.Windows.Forms.Application.StartupPath;
            //    //double[][] latlng = CalculationBBox(PATH + @"\" + Building[i] + @"\" + BuildingValue[i].ToUpper() + ".txt");
            //    double[][] latlng = CalculationBBox(PATH + @"\e3d\" + BuildingValue[i].ToUpper() + ".txt");
            //    //坐標轉換
            //    double[] x = { latlng[0][0] };//long
            //    double[] y = { latlng[0][1] };//lat
            //    double[] z = new double[x.Length];//
            //    double[] latlng_even = CoordinateSystemsTransformations(x, y, z);

            //    String sql = @"INSERT INTO city_table
            //                    (
            //                        id,
            //                        value,
            //                        point
            //                    )
            //                    VALUES
            //                    (
            //                     @id,
            //                     @value,
            //                     ST_GeomFromText(@point,4326)
            //                    )";
            //    string id = Building[i];
            //    string value = BuildingValue[i].ToUpper();
            //    string point = "POINT(" + latlng_even[0] + " " + latlng_even[1] + ")";
            //    bool success = Npgsql_Data(sql,id,value,point);
            //    if (success)
            //    {
            //        Console.WriteLine("id : " + Building[i] + " 寫入成功！");
            //    }
            //    else
            //    {
            //        Console.WriteLine("id : " + Building[i] + " 寫入失敗！");
            //    }
            //}

            //try
            //{
            //    String p1 = @" ""D:\Samples\pp\SingleCity2E3D\c2e\obj\debug.win32\DC00010332.txt"" ";
            //    String p2 = @" ""D:\Samples\pp\DC00010332.e3d"" ";
            //    String url = @"D:\Samples\pp\SingleCity2E3D\c2e\obj\debug.win32\c2e.exe";

            //    ProcessStartInfo startInfo = new ProcessStartInfo();
            //    startInfo.FileName = url;
            //    startInfo.Arguments = p1 + " " + p2;

            //    Process.Start(startInfo);
            //    //myProcess.StartInfo.CreateNoWindow = true;
            //    //myProcess.Start("");
            //    // This code assumes the process you are starting will terminate itself.
            //    // Given that is is started without a window so you cannot terminate it
            //    // on the desktop, it must terminate itself or you can do it programmatically
            //    // from this application using the Kill method.

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            StayMessage("結束工作 3秒後將自動關閉", 3);
        }

        private static void StayMessage(string Message, int Second)
        {
            Console.WriteLine(string.Format("<<{0}>>", Message));
            Thread.Sleep(Second * 1000);
        }




        static bool bldg_Building = false;//是否加入 Building 清單裡面
        static bool gen_Value = false;//是否加入 BuildingValue 清單裡面

        static bool bldg_WallSurface = false;//讀到 WallSurface 
        static bool gml_posList = false;//讀到 posList



        /// <summary>
        /// 參考BoundingBox >> bbox 
        /// https://pythonhosted.org/planar/bbox.html
        /// http://spatialreference.org/ref/epsg/wgs-84/
        /// </summary>
        /// <param name="file_path"></param>
        public static double[][] CalculationBBox(String file_path)
        {
            //double[,] latlng = new double[,]{ { 0.0, 0.0 }, { 0.0, 0.0 } };
            double[][] latlng = new double[2][];
            latlng[0] = new double[] { 0.0, 0.0 };
            latlng[1] = new double[] { 0.0, 0.0 };
            //讀取所有Line
            //參考資料 https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/file-system/how-to-read-from-a-text-file
            string[] lines = System.IO.File.ReadAllLines(file_path);
            //double min_lat = 0.0, min_lng = 0.0, max_lat = 0.0, max_lng = 0.0;
            bool first = true;
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                //Console.WriteLine("\t CalculationBBox :" + line);
                String[] latlng_elevation = line.Split(' ');
                // Console.WriteLine("\t file_path : " + file_path);
                //Console.WriteLine("\t latlng_elevation.Length : " + latlng_elevation.Length );
                for (int i = 0; i < latlng_elevation.Length - 1; i += 3)
                {
                    // Console.WriteLine("\t i : " + i  
                    //     + ",latlng_elevation[i]:" + latlng_elevation[i]
                    //     + ",latlng_elevation[i+1]:" + latlng_elevation[i + 1]);
                    if (first)
                    {
                        //記錄第一次得到的 緯度、經度
                        first = false;
                        latlng[0][0] = double.Parse(latlng_elevation[i]);
                        latlng[1][0] = double.Parse(latlng_elevation[i + 1]);
                        latlng[0][1] = double.Parse(latlng_elevation[i]);
                        latlng[1][1] = double.Parse(latlng_elevation[i + 1]);
                    }
                    else
                    {

                        if (double.Parse(latlng_elevation[i]) > latlng[1][0])//右上 x
                        {
                            latlng[1][0] = double.Parse(latlng_elevation[i]);
                        }
                        else if (double.Parse(latlng_elevation[i]) < latlng[0][0])//左下 x
                        {
                            latlng[0][0] = double.Parse(latlng_elevation[i]);
                        }

                        if (double.Parse(latlng_elevation[i + 1]) > latlng[1][1])//右上 y
                        {
                            latlng[1][1] = double.Parse(latlng_elevation[i + 1]);
                        }
                        else if (double.Parse(latlng_elevation[i + 1]) < latlng[0][1])//左上y
                        {
                            latlng[0][1] = double.Parse(latlng_elevation[i + 1]);
                        }
                    }
                }

            }

            Console.WriteLine("\t BBox : latlng[0][0] : "
                + latlng[0][0]
                + ",latlng[0][1]:" + latlng[0][1]
                + "  ---  latlng[1][0] :" + latlng[1][0]
                + ",latlng[1][1] :" + latlng[1][1]);



            return latlng;
        }



        public static DataTable Npgsql_Data(String sql)
        {
            //參考資料
            //https://www.npgsql.org/doc/index.html
            String connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            DataTable dt = new DataTable();
            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connstr))
            {
                conn.Open();
                using (var cmd = new Npgsql.NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    //執行不Query的方式
                    //cmd.ExecuteNonQuery();
                    Npgsql.NpgsqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                }
            }

            return dt;

        }

        public static bool Npgsql_Data(String sql, string id, string value, string point)
        {

            bool success = false;
            try
            {

                //https://www.npgsql.org/doc/index.html
                String connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                DataTable dt = new DataTable();
                using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connstr))
                {
                    conn.Open();
                    using (var cmd = new Npgsql.NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.Parameters.AddWithValue("value", value);
                        cmd.Parameters.AddWithValue("point", point);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            success = true;
                        }
                        else
                        {
                            success = false;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return success;
        }

        /// <summary>
        /// 坐標系統轉換 
        /// 參考資料 https://www.nuget.org/packages/Proj4Net
        /// https://www.codeproject.com/Tips/1072197/Coordinate-Transformation-Using-Proj-in-NET
        /// http://spatialreference.org/ref/epsg/
        /// </summary>
        /// <returns></returns>
        public static double[] CoordinateSystemsTransformations(double[] x, double[] y, double[] z)
        {
            double[] latlng = { 0.0, 0.0, 0.0 };

            //    double[] x = {5.85000007,4.61923914,3.3873273,2.5413302,
            //2.74920293,3.38005007,5.10171662,6.03675746,6.83078962,6.77138124};
            //    double[] y = {50.84999997,51.51226471,51.43806765,
            //51.89076392,54.36940251,55.77197661,54.81463907,54.1912587,53.29330013,51.9500853};
            //    double[] z = new double[x.Length];

            for (int i = 0; i <= z.Length - 1; i++)
            {
                Console.WriteLine("input geographic ED50 p{0} = {1} {2}", i + 1, x[i], y[i]);
            }

            //rewrite xy array for input into Proj4
            double[] xy = new double[2 * x.Length];
            int ixy = 0;
            for (int i = 0; i <= x.Length - 1; i++)
            {
                xy[ixy] = x[i];
                xy[ixy + 1] = y[i];
                z[i] = 0;
                ixy += 2;
            }

            string proj4_26985 = @"+proj=lcc +lat_1=39.45 +lat_2=38.3 +lat_0=37.66666666666666 +lon_0=-77 +x_0=400000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs";
            string proj4_4326 = @"+proj=longlat +ellps=WGS84 +datum=WGS84 +no_defs";

            DotSpatial.Projections.ProjectionInfo src =
                DotSpatial.Projections.ProjectionInfo.FromProj4String(proj4_26985);
            DotSpatial.Projections.ProjectionInfo trg =
                DotSpatial.Projections.ProjectionInfo.FromProj4String(proj4_4326);

            DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, src, trg, 0, x.Length);

            ixy = 0;
            for (int i = 0; i <= x.Length - 1; i++)
            {
                Console.WriteLine("output RD New p{0} = {1} {2}", i + 1, xy[ixy], xy[ixy + 1]);
                latlng[0] = xy[ixy];
                latlng[1] = xy[ixy + 1];
                ixy += 2;

            }


            return latlng;
        }

        public static void ReadXml_File(String XML_FILE)
        {
            FileStream file = new FileStream(XML_FILE, FileMode.OpenOrCreate);
            BufferedStream stream = new BufferedStream(file);
            //XmlTextReader reader = new XmlTextReader("XMLFile2.xml");
            XmlTextReader reader = new XmlTextReader(stream);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        //Console.Write("<" + reader.Name);
                        //Console.WriteLine(">");

                        if (reader.Name.Equals("gen:value"))
                        {
                            gen_Value = true;
                        }
                        else if (reader.Name.Equals("gml:posList"))
                        {
                            gml_posList = true;
                        }

                        if (reader.AttributeCount > 0)
                        {
                            WriteReaderAttributes(reader);
                        }
                        //Debug.Indent();
                        break;

                    case XmlNodeType.Text: //Display the text in each element.

                        if (gen_Value && bldg_Building)
                        {
                            bldg_Building = false;
                            gen_Value = false;
                            BuildingValue.Add(reader.Value.ToString());

                            #region ---e3d

                            String PATH = System.Windows.Forms.Application.StartupPath;
                            //DataTable dt = Npgsql_Data("SELECT * From city_table WHERE city_table.value = '" + reader.Value.ToString().ToUpper() + "'");

                            if (!System.IO.File.Exists(PATH + @"\wgs84\" + reader.Value.ToString().ToUpper() + ".e3d"))
                            {
                                Console.WriteLine(PATH + @"\wgs84\" + reader.Value.ToString().ToUpper() + ".e3d");
                                try
                                {

                                    String p1 = PATH + @"\" + Building[i] + @"\" + BuildingValue[i].ToUpper() + ".txt";
                                    String p2 = PATH + @"\" + Building[i] + @"\" + BuildingValue[i].ToUpper() + ".e3d";
                                    //String p1 = PATH + @"\wgs84\" + reader.Value.ToString().ToUpper() + ".txt";
                                    //String p2 = PATH + @"\wgs84\" + reader.Value.ToString().ToUpper() + ".e3d";
                                    String url = PATH + @"\trasfer\c2e.exe";
                                    //String url = @"D:\Samples\Debug\trasfer\c2e.exe";//測試
                                    Process startInfo = new Process();
                                    startInfo.StartInfo.FileName = url;
                                    startInfo.StartInfo.Arguments = p1 + " " + p2;
                                    startInfo.StartInfo.CreateNoWindow = false;
                                    startInfo.Start();


                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                            #endregion



                        }
                        else if (gen_Value && bldg_WallSurface && !gml_posList)//如果是 gen_Value && Wall
                        {
                            this_gen_Value = reader.Value.ToString();

                            int index = BuildingValue.IndexOf(this_gen_Value);
                            if (index > -1)
                            {
                                this_bldg_Building = Building[index];
                            }



                        }
                        else if (gen_Value && bldg_WallSurface && gml_posList)
                        {
                            gen_Value = false;
                            bldg_WallSurface = false;
                            gml_posList = false;

                            #region 寫入 text 資料夾
                            WriteTxt(this_bldg_Building + @"\wgs84\" + this_gen_Value.ToUpper() + ".txt", reader.Value.ToString());

                            #region 經緯度轉換
                            //String gml_posList_st = reader.Value.ToString();
                            //CoodinateTransformation(ref gml_posList_st);
                            #endregion
                           // WriteTxt(@"wgs84\" + this_gen_Value.ToUpper() + ".txt", gml_posList_st);//測試本機寫入 wgs 84

                            #endregion

                            Count++;
                            this_gen_Value = "";
                            //Console.WriteLine("XmlNodeType.Text : " + reader.Value.ToString());
                        }

                        break;

                    case XmlNodeType.EndElement: //Display the end of the element.
                        //Debug.Unindent();
                        //Console.Write("</" + reader.Name);
                        //Console.WriteLine(">");
                        break;

                    case XmlNodeType.Attribute:
                        //Console.Write("  Attribute ");
                        //Console.Write("</" + reader.Name + " = " + reader.Value.ToString());
                        //Console.WriteLine(">");



                        break;
                }
            }

            //Console.ReadLine();
            return;

        }

        private static void CoodinateTransformation(ref String gml_posList_st)
        {
            //gml_posList = @"392561.2249145508 137676.09832763672 40.66950000000361 392561.2249145508 137676.09832763672 30.95879999999306 392561.79510498047 137675.83709716797 30.95879999999306 392561.79510498047 137675.83709716797 40.658599999995204 392561.2249145508 137676.09832763672 40.66950000000361"


            String[] arr = gml_posList_st.Split(' ');

            //參考資料 https://www.codeproject.com/Tips/1072197/Coordinate-Transformation-Using-Proj-in-NET
            //Console.WriteLine("C#: Test coordinate conversion from ED50 to RD New");

            double[] x = new double[arr.Length / 3];
            double[] y = new double[arr.Length / 3];
            double[] z = new double[arr.Length / 3];

            for (int i = 0; i < arr.Length / 3; i++)
            {
                x[i] = double.Parse(arr[(i * 3)]);
                y[i] = double.Parse(arr[(i * 3) + 1]);
                z[i] = double.Parse(arr[(i * 3) + 2]);
            }

            //for (int i = 0; i <= z.Length - 1; i++)
            //{
            //    Console.WriteLine("input geographic ED50 p{0} = {1} {2} {3}", i + 1, x[i], y[i], z[i]);
            //}

            //rewrite xy array for input into Proj4
            double[] xy = new double[2 * x.Length];
            int ixy = 0;
            for (int i = 0; i <= x.Length - 1; i++)
            {
                xy[ixy] = x[i];
                xy[ixy + 1] = y[i];
                //z[i] = z[i];
                ixy += 2;
            }

            string proj4_ed50 = @"+proj=lcc +lat_1=39.45 +lat_2=38.3 +lat_0=37.66666666666666 +lon_0=-77 +x_0=400000 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs";
            string proj4_rdnew = @"+proj=longlat +ellps=WGS84 +datum=WGS84 +no_defs";

            DotSpatial.Projections.ProjectionInfo src =
                DotSpatial.Projections.ProjectionInfo.FromProj4String(proj4_ed50);
            DotSpatial.Projections.ProjectionInfo trg =
                DotSpatial.Projections.ProjectionInfo.FromProj4String(proj4_rdnew);

            DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, src, trg, 0, x.Length);

            string tramsfer = "";
            ixy = 0;
            for (int i = 0; i <= x.Length - 1; i++)
            {
                // Console.WriteLine("output RD New p{0} = {1} {2} {3}", i + 1, xy[ixy], xy[ixy + 1], z[i]);
                if (!tramsfer.Equals(""))
                {
                    tramsfer += " ";
                }
                tramsfer += "" + xy[ixy + 1] + " " + xy[ixy] + " " + z[i];
                ixy += 2;
            }

            gml_posList_st = tramsfer;

        }

        private static void WriteReaderAttributes(XmlTextReader reader)
        {
            int attributeCount = reader.AttributeCount;
            bool bool_bldg_Building = false;//是否記錄繼續記錄這個函數的建築物ID

            if (reader.Name.Equals("bldg:Building"))
            {
                bldg_Building = true;
                bool_bldg_Building = true;
            }
            else if (reader.Name.Equals("bldg:WallSurface"))
            {
                bldg_WallSurface = true;
            }
            else if (reader.Name.Equals("gml:posList"))
            {

            }


            for (int i = 0; i < attributeCount; i++)
            {
                reader.MoveToAttribute(i);
                //Console.Write(" WriteReaderAttributes Attribute ");
                //Console.Write("</" + reader.Name + " = " + reader.Value.ToString());
                //Console.WriteLine(">");
                if (bldg_Building && bool_bldg_Building)//取得建築物的 ID 
                {
                    bool_bldg_Building = false;
                    Building.Add(reader.Value.ToString().Replace("id_", ""));//因為要存 uuid 的資料，必須把 id_ 拿掉
                    this_bldg_Building = reader.Value.ToString().Replace("id_", "");
                }

            }

        }

        /// <summary>
        /// 將取得的資料寫入指定路徑的資料夾中，先 删除資料夾 >> 再建新新的資料夾 和 資料
        /// </summary>
        /// <param name="path"></param>
        /// <param name="gml_posList"></param>
        private static void WriteTxt(String path, String gml_posList)
        {

            if (first)//如果是第一個進入的話，代表，資料重來跑過，需要先刪掉之前的資料夾
            {
                first = false;
                for (int i = 0; i < Building.Count; i++)
                {
                    //Directory.Delete(Building[i]);
                    try
                    {
                        //如果此路徑下的資料夾在的話。
                        if (Directory.Exists(Building[i]))
                        {
                            Directory.Delete(Building[i], true);//刪除此路徑下的資料
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            //Console.WriteLine(path);
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }


            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = gml_posList + Environment.NewLine;

                File.WriteAllText(path, createText);

            }
            else
            {
                using (StreamWriter w = File.AppendText(path))
                {
                    w.WriteLine(gml_posList);
                    w.Flush();
                }
            }

        }
    }
}
