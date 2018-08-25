using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace HamLifeLog
{
    public struct LogElementStruct
    {
        public DateTime ts;
        public string call;
        public double freq;
        public string mode;
        public string sendRST;
        public string receivedRST;
        public string stationPrefix;
        public string qth;
        public string name;
        public string comment;
        public double band;
        public string operatorName;
    }

    class ManipulateDataBaseClass
    {
        private readonly string _startup_path;
        private string _fname;
        private string _sql_version = "Version=3";

        private LogElementStruct loggingData;

        public ManipulateDataBaseClass(string assemblyPath)
        {
            _startup_path = System.IO.Path.Combine(assemblyPath, "DataBase");
            _fname = "default.sqlite";
            if(!System.IO.Directory.Exists(_startup_path))
            {
                // make DataBase directory
                System.IO.Directory.CreateDirectory(_startup_path);
            }
        }

        public string FileName
        {
            get { return _fname; }
            set { _fname = value; }
        }

        private string SQLVersion
        {
            get { return _sql_version; }
            set { _sql_version = value; }
        }

        public string File_path => System.IO.Path.Combine(_startup_path, FileName);

        public string Startup_path { get => _startup_path; }

        private Boolean NewCreate()
        {
            // try to create an sqlite file if it doesn't exists.
            if (System.IO.File.Exists(File_path))
            {
                return false;
            }
            SQLiteConnection.CreateFile(File_path);
            return true;
        }

        private SQLiteConnection NewConnection()
        {
            try
            {
                var connection = new SQLiteConnection("Data Source=" + File_path + ";" + SQLVersion);
                connection.Open();
                return connection;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        private void CloseConnection(SQLiteConnection connection)
        {
            connection.Close();
        }

        public void NewCreateTable(string fname)
        {
            _fname = fname;
            NewCreate();
            
            var connection = NewConnection();
            try
            {
                string sql = @"CREATE TABLE IF NOT EXISTS DXLOG ( 
                    TS datetime, 
                    Call varchar(15), 
                    Freq real, 
                    QSXFreq real,
                    Mode varchar(6),
                    ContestName varchar(10), SNT varchar(10), RCV varchar(15),
                    CountryPrefix varchar(8), StationPrefix varchar(15), QTH varchar(25),
                    Name varchar(20), Comment varchar(60), NR integer,
                    Sect varchar(8), Prec varchar(1), CK integer, ZN integer,
                    SentNR integer, Points integer, IsMultiplier1 integer, IsMultiplier2 integer,
                    Power real, Band real, WPXPrefix varchar(8), Exchange1 varchar(20), RadioNR integer,
                    ContestNR integer, isMultiplier3 integer, MiscText varchar(20), 
                    IsRunQSO integer, ContactType varchar(1), Run1Run2 integer, 
                    GridSquare varchar(6), Operator varchar(20), Continent varchar(2),
                    RoverLocation varchar(10), RadioInterfaced integer, NetworkedCompNr integer,
                    NetBiosName varchar(255), IsOriginal boolean
                    );";
                SQLiteCommand com = new SQLiteCommand(sql, connection);
                com.ExecuteNonQuery();

                sql = @"CREATE TABLE IF NOT EXISTS Station (
                    Call varchar(20), 
                    Name varchar(50), 
                    Street1 varchar(50), 
                    Street2 varchar(50), 
                    City varchar(30),
                    State varchar(8), 
                    Zip varchar(25), Country varchar(30), GridSquare varchar(8), LicenseClass varchar(10),
                    Latitude real, Logitude real, PacketNode varchar(10), ARRLSection varchar(4), Club varchar(50), 
                    IARUZone integer, CQZone integer, STXeq varchar(50), SPowe varchar(20), SAnte varchar(30),
                    SAntH1 varchar(15), SAntH2 varchar(15), RoverQTH varchar(10)
                    );";
                com = new SQLiteCommand(sql, connection);
                com.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection(connection);
            }
        }

        public void AddLog()
        {
            var connection = NewConnection();
            var command = connection.CreateCommand();
            try
            {
                command.CommandText = @"INSERT INTO DXLOG ( TS, Call, Freq, Mode, SNT, RCV, StationPrefix, QTH, Name, Comment, Band, Operator, IsOriginal) VALUES ( @TS, @Call, @Freq, @Mode, @SNT, @RCV, @StationPrefix, @QTH, @Name, @Comment, @Band, @Operator, @IsOriginal)";
                command.Parameters.Add(new SQLiteParameter("@IsOriginal", true));
                command.Parameters.Add(new SQLiteParameter("@TS", loggingData.ts));
                command.Parameters.Add(new SQLiteParameter("@Call", loggingData.call));
                command.Parameters.Add(new SQLiteParameter("@Freq", loggingData.freq));
                command.Parameters.Add(new SQLiteParameter("@Mode", loggingData.mode));
                command.Parameters.Add(new SQLiteParameter("@SNT", loggingData.sendRST));
                command.Parameters.Add(new SQLiteParameter("@RCV", loggingData.receivedRST));
                command.Parameters.Add(new SQLiteParameter("@StationPrefix", loggingData.stationPrefix));
                command.Parameters.Add(new SQLiteParameter("@QTH", loggingData.qth));
                command.Parameters.Add(new SQLiteParameter("@Name", loggingData.name));
                command.Parameters.Add(new SQLiteParameter("@Comment", loggingData.comment));
                command.Parameters.Add(new SQLiteParameter("@Band", loggingData.band));
                command.Parameters.Add(new SQLiteParameter("@Operator", loggingData.operatorName));

                command.ExecuteNonQuery();
            }
            catch (SQLiteException exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
                System.Windows.Forms.MessageBox.Show("Fault to add Log: ", exc.Message);
            }
            finally
            {
                CloseConnection(connection);
            }

        }

        public void SetLoggingData(DateTime date, string call, double freq, string mode, string sendrst, string receivedrst,
            string stationPrefix, string myQTH, string name, string comment, double band, string operatorName)
        {
            loggingData.ts = date; loggingData.call = call; loggingData.freq = freq;
            loggingData.mode = mode; loggingData.sendRST = sendrst; loggingData.receivedRST = receivedrst;
            loggingData.stationPrefix = stationPrefix; loggingData.qth = myQTH; loggingData.name = name;
            loggingData.comment = comment; loggingData.operatorName = operatorName;
        }
    }
}
