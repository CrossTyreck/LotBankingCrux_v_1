using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace LotBankingCrux_v_1.Crux
{
    public class CruxDB
    {
        //Database connection constants
        private string server = "SERVER=" + "CBHLotBanking.db.5572879.hostedresource.com" + ";";
        private string database = "DATABASE=" + "CBHLotBanking" + ";";
        private string user = "UID=" + "CBHLotBanking" + ";";
        private string password = "PASSWORD=" + "Crux2014!" + ";";

        public static int dbID = 0;

        private MySqlConnection databaseConnection;

        public CruxDB()
        {
            databaseConnection = new MySqlConnection(server + database + user + password);
        }

        public int insertLogin(String login, String password, int user_class_id, int option_mask)
        {
            MySqlCommand insertNewLogin = new MySqlCommand("INSERT INTO Login " +
                                                              "(login,  password,  user_class_id, option_mask)" +
                                                       "VALUES(@login, @password, @userClassId,  @optionMask)",
                                                       databaseConnection);
            insertNewLogin.Parameters.Add("@login", MySqlDbType.VarChar, 30).Value = login;
            insertNewLogin.Parameters.Add("@password", MySqlDbType.VarChar, 30).Value = password;
            insertNewLogin.Parameters.Add("@userClassId", MySqlDbType.Int32).Value = user_class_id;
            insertNewLogin.Parameters.Add("@optionMask", MySqlDbType.Int32).Value = option_mask;

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = insertNewLogin.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            //return 1;
            return getUserId(login); //CHRIS
        }

        public int setPassword(int id, String password)
        {

            MySqlCommand updateLogin = new MySqlCommand("UPDATE Login " +
                                                       "SET password      = @password, " +
                                                          " last_modified = NOW() " +
                                                     "WHERE id            = @id",
                                                       databaseConnection);
            updateLogin.Parameters.Add("@password", MySqlDbType.VarChar, 30).Value = password;
            updateLogin.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = updateLogin.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public int login(String login, String password)
        {


            MySqlCommand getLoginData = new MySqlCommand("SELECT id " +
                                                       "FROM Login " +
                                                      "WHERE login = @login" + Environment.NewLine +
                                                        "AND password = @password", databaseConnection);

            getLoginData.Parameters.Add("@login", MySqlDbType.VarChar, 30).Value = login;
            getLoginData.Parameters.Add("@password", MySqlDbType.VarChar, 30).Value = password;

            Debug.WriteLine(getLoginData.CommandText.ToString());

            databaseConnection.Open();
            dbID = -1;
            MySqlDataReader reader;
            try
            {
                reader = getLoginData.ExecuteReader(CommandBehavior.SequentialAccess);

                while (reader.Read())
                {
                    dbID = reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            if (dbID >= 0)
            {
                return dbID;
            }
            return -2;
        }

        public int getUserId(string name)
        {

            MySqlCommand getLoginData = new MySqlCommand("SELECT id " +
                                                           "FROM Login " +
                                                          "WHERE login = @login",
                                                      databaseConnection);
            getLoginData.Parameters.Add("@login", MySqlDbType.VarChar).Value = name;

            int returnValue = -2;

            try
            {
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = getLoginData.ExecuteReader(CommandBehavior.SequentialAccess);

                while (reader.Read())
                {
                    returnValue = reader.GetInt32(0);
                }
            }

            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }

            finally
            {

                if (databaseConnection.State.Equals(System.Data.ConnectionState.Open))
                {
                    databaseConnection.Close();
                }
            }
            return returnValue;

        }

        public int getUserClassId(int loginId)
        {

            MySqlDataReader reader = null;
            MySqlCommand getLoginData = new MySqlCommand("SELECT user_class_id " +
                                                           "FROM Login " +
                                                          "WHERE id = @id",
                                                      databaseConnection);
            getLoginData.Parameters.Add("@id", MySqlDbType.Int32).Value = loginId;

            try
            {
                databaseConnection.Open();
                reader = getLoginData.ExecuteReader(CommandBehavior.SingleResult);

                while (reader.Read())
                {

                    if (reader.GetInt32(0) >= 0)
                    {
                        return reader.GetInt32(0);
                    }
                }

                return -2;

            }

            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }

            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (databaseConnection.State.Equals(System.Data.ConnectionState.Open))
                {

                    databaseConnection.Close();
                }
            }


        }

        public int insertBuilder(int builder_id, String name)
        {
            MySqlCommand insertNewBuilder = new MySqlCommand("INSERT INTO Builder_Data " +
                                                                   "(builder_id, name) " +
                                                             "VALUES( @builderId, @name)",
                                                             databaseConnection);
            insertNewBuilder.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builder_id;
            insertNewBuilder.Parameters.Add("@name", MySqlDbType.VarChar, 30).Value = name;
            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = insertNewBuilder.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public int updateBuilderName(int builder_id, String name)
        {
            MySqlCommand updateBuilderName = new MySqlCommand("UPDATE Builder_Data " +
                                                                 "SET name = @name, " +
                                                                     "last_modified = NOW() " +
                                                               "WHERE bid = @builderId)",
                                                             databaseConnection);
            updateBuilderName.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builder_id;
            updateBuilderName.Parameters.Add("@name", MySqlDbType.VarChar, 30).Value = name;
            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = updateBuilderName.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public List<int> getBuilderId()
        {
            MySqlCommand getBuilderId = new MySqlCommand("SELECT builder_id " +
                                                           "FROM Builder_Data ",
                                                      databaseConnection);

            List<int> returnValue = null;
            try
            {
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = getBuilderId.ExecuteReader(CommandBehavior.SingleResult);

                returnValue = new List<int>();

                while (reader.Read())
                {
                    returnValue.Add(reader.GetInt32(0));
                }
            }

            catch (Exception e)
            {
                Debug.Print(e.Message);
            }

            finally
            {
                if (databaseConnection.State.Equals(System.Data.ConnectionState.Open))
                {
                    databaseConnection.Close();
                }
            }

            return returnValue;
        }

        public int getBuilderId(string name)
        {

            MySqlCommand getBuilderId = new MySqlCommand("SELECT builder_id " +
                                                           "FROM Builder_Data " +
                                                          "WHERE name = @name",
                                                      databaseConnection);
            getBuilderId.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;

            int returnValue = -2;

            try
            {
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = getBuilderId.ExecuteReader(CommandBehavior.SingleResult);

                while (reader.Read())
                {
                    returnValue =  reader.GetInt32(0);
                }
            }

            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }

            finally
            {

                if (databaseConnection.State.Equals(System.Data.ConnectionState.Open))
                {

                    databaseConnection.Close();
                }
            }

            return returnValue;
        }
        public String getBuilderName(int id)
        {
            MySqlCommand getBuildersName = new MySqlCommand("SELECT name" +
                                                              "FROM Builder_Data" +
                                                             "WHERE bid = @id",
                                                         databaseConnection);
            getBuildersName.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            MySqlDataReader reader;
            String name = "";
            try
            {
                reader = getBuildersName.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    name = reader.GetString(0);
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
            reader.Close();
            databaseConnection.Close();
            return name;
        }

        public DataTable getBuilderNames()
        {
            MySqlCommand getBuildersNames = new MySqlCommand("SELECT name, " +
                                                                    "builder_id " + 
                                                               "FROM Builder_Data",
                                                         databaseConnection);
            MySqlDataAdapter daNames = new MySqlDataAdapter(getBuildersNames);
            DataTable dtNames = new DataTable();
            try
            {
                daNames.Fill(dtNames);
            }
            catch (MySqlException e)
            {
                Debug.Print(e.Message);
                return null;
            }
            databaseConnection.Close();
            return dtNames;
        }

        public DataTable getBuilderProjects(int builderId)
        {
            MySqlCommand getBuilderProjects = new MySqlCommand("SELECT project_name, " +
                                                                      "id " +
                                                                "FROM Projects " +
                                                               "WHERE builder_id = @builderId",
                                                         databaseConnection);
            getBuilderProjects.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builderId;

            MySqlDataAdapter daNames = new MySqlDataAdapter(getBuilderProjects);
            DataTable dtNames = new DataTable();
            try
            {
                daNames.Fill(dtNames);
            }
            catch (MySqlException e)
            {
                Debug.Print(e.Message);
                return null;
            }
            databaseConnection.Close();
            return dtNames;
        }

        public int insertProjectDocument(int projectId, String docName, byte[] doc)
        {
            MySqlCommand insertNewProjectDocument = new MySqlCommand("INSERT INTO Project_Documents" +
                                                                           "(project_id, file_name, document)" +
                                                                     "VALUES( @projectId, @fileName, @document)",
                                                                     databaseConnection);

            insertNewProjectDocument.Parameters.Add("@projectId", MySqlDbType.Int32).Value = projectId;
            insertNewProjectDocument.Parameters.Add("@fileName", MySqlDbType.VarChar, 30).Value = docName;
            insertNewProjectDocument.Parameters.Add("@document", MySqlDbType.Binary, doc.Length).Value = doc;

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = insertNewProjectDocument.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public int insertBuilderDocument(int builderId, String docName, byte[] doc)
        {
            MySqlCommand insertNewBuilderDocument = new MySqlCommand("INSERT INTO Builder_Documents" +
                                                                           "( builder_id, document_name, document)" +
                                                                     "VALUES( @builderId, @documentName, @document)",
                                                                     databaseConnection);

            insertNewBuilderDocument.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builderId;
            insertNewBuilderDocument.Parameters.Add("@documentName", MySqlDbType.VarChar, 30);
            insertNewBuilderDocument.Parameters.Add("@document", MySqlDbType.Binary, doc.Length);

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = insertNewBuilderDocument.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }
        public int requestProjectDocument(int document_id)
        {
            MySqlCommand requestProjectDocument = new MySqlCommand("UPDATE Project_Documents " +
                                                                      "SET last_requested = NOW() " +
                                                                    "WHERE id = @documentId",
                                                                     databaseConnection);

            requestProjectDocument.Parameters.Add("@documentId", MySqlDbType.Int32).Value = document_id;

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = requestProjectDocument.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public int requestBuilderDocument(int document_id)
        {
            MySqlCommand requestBuilderDocument = new MySqlCommand("UPDATE Builder_Documents " +
                                                                      "SET last_requested = NOW() " +
                                                                    "WHERE id = @documentId",
                                                                     databaseConnection);

            requestBuilderDocument.Parameters.Add("@documentId", MySqlDbType.Int32).Value = document_id;

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = requestBuilderDocument.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public int updateProjectDocumentFile(int document_id, byte doc, String file_name)
        {
            MySqlCommand updateProjectDocument = new MySqlCommand("UPDATE Project_Documents " +
                                                                     "SET document      = @doc, " +
                                                                        " file_name = @fileName, " +
                                                                        " last_updated = NOW()" +
                                                                   "WHERE id = @documentId",
                                                                     databaseConnection);

            updateProjectDocument.Parameters.Add("@doc", MySqlDbType.Binary).Value = doc;
            updateProjectDocument.Parameters.Add("@fileName", MySqlDbType.VarChar, 30).Value = file_name;
            updateProjectDocument.Parameters.Add("@documentId", MySqlDbType.Int32).Value = document_id;

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = updateProjectDocument.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public int updateBuilderDocumentFile(int document_id, byte doc, String file_name)
        {
            MySqlCommand updateBuilderDocument = new MySqlCommand("UPDATE Builder_Documents " +
                                                                    "SET document      = @doc, " +
                                                                       " file_name = @fileName, " +
                                                                       " last_updated = NOW()" +
                                                                  "WHERE id = @documentId",
                                                                     databaseConnection);

            updateBuilderDocument.Parameters.Add("@doc", MySqlDbType.Binary).Value = doc;
            updateBuilderDocument.Parameters.Add("@fileName", MySqlDbType.VarChar, 30).Value = file_name;
            updateBuilderDocument.Parameters.Add("@documentId", MySqlDbType.Int32).Value = document_id;

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = updateBuilderDocument.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public DataTable getBuilderDocuments(int builder_id)
        {
            MySqlCommand getBuildersDocuments = new MySqlCommand("SELECT file_name, " +
                                                                        "id " +
                                                                   "FROM Builder_Documents " +
                                                                 "WHERE builder_id = @builderId",
                                                       databaseConnection);
            getBuildersDocuments.Parameters.Add("@builderid", MySqlDbType.Int32).Value = builder_id;
            MySqlDataAdapter daNames = new MySqlDataAdapter(getBuildersDocuments);
            DataTable dtDocuments = new DataTable();
            try
            {
                daNames.Fill(dtDocuments);
            }
            catch (MySqlException e)
            {
                Debug.Print(e.Message);
                return null;
            }
            //reader.Close();
            databaseConnection.Close();
            return dtDocuments;
        }

        public BuilderDocumentData[] getBuilderDocumentData(int builder_id)
        {
            MySqlCommand selectBuilderDocumentData = new MySqlCommand("SELECT id, builder_id, document_name, file_name, last_modified, last_requested " +
                                                                       "FROM Builder_Documents " +
                                                                      "WHERE buider_id = @builderId",
                                                                databaseConnection);
            selectBuilderDocumentData.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builder_id;

            List<BuilderDocumentData> doclist = new List<BuilderDocumentData>();
            BuilderDocumentData[] docs = new BuilderDocumentData[0];
            int docCount = 0;
            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = selectBuilderDocumentData.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    int i = reader.GetInt32(0);
                    int bid = reader.GetInt32(1);
                    String dn = reader.GetString(2);
                    String fn = reader.GetString(3);
                    DateTime lm = reader.GetDateTime(4);
                    DateTime lr = reader.GetDateTime(5);
                    docCount++;
                    BuilderDocumentData newDoc = new BuilderDocumentData(i, bid, dn, fn, lm, lr);
                    doclist.Add(newDoc);
                }
                docs = new BuilderDocumentData[docCount];
                List<BuilderDocumentData>.Enumerator docEnum = doclist.GetEnumerator();
                for (int i = 0; i < docCount; i++)
                {
                    docs[i] = docEnum.Current;
                    docEnum.MoveNext();
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
            reader.Close();
            databaseConnection.Close();

            return docs;
        }

        public byte[] getBuilderDocument(int id)
        {
            byte[] doc = new byte[0];

            MySqlCommand selectBuilderDocument = new MySqlCommand("SELECT document " +
                                                                    "FROM Builder_Documents " +
                                                                   "WHERE id = @id",
                                                                  databaseConnection);
            selectBuilderDocument.Parameters.Add("@id", MySqlDbType.Int32);

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = selectBuilderDocument.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    Stream stream = reader.GetStream(0);
                    BinaryReader streamReader = new BinaryReader(stream);
                    doc = streamReader.ReadBytes((int)stream.Length);
                    streamReader.Close();
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
            reader.Close();
            databaseConnection.Close();

            return doc;
        }

        public List<String> getProjectDocuments(int project_id)
        {
            MySqlCommand selectProjectDocuments = new MySqlCommand("SELECT file_name " +
                                                                       "FROM Project_Documents " +
                                                                      "WHERE project_id = @projectId",
                                                                databaseConnection);
            selectProjectDocuments.Parameters.Add("@projectId", MySqlDbType.Int32).Value = project_id;

         

           // BuilderDocumentData[] docs = new BuilderDocumentData[0];
            int docCount = 0;
            databaseConnection.Open();

            MySqlDataReader reader;
            List<String> listDocNames = new List<String>();

            try
            {
                reader = selectProjectDocuments.ExecuteReader(CommandBehavior.SequentialAccess);
                
                
                while (reader.Read())
                {
                    string i = reader.GetString(0);
                    //int bid = reader.GetInt32(1);
                    //String dn = reader.GetString(2);
                    //String fn = reader.GetString(3);
                    //DateTime lm = reader.GetDateTime(4);
                    //DateTime lr = reader.GetDateTime(5);
                    docCount++;
                    
                    listDocNames.Add(i);
                }
                //docs = new BuilderDocumentData[docCount];
                //List<BuilderDocumentData>.Enumerator docEnum = doclist.GetEnumerator();
                //for (int i = 0; i < docCount; i++)
                //{
                //    docs[i] = docEnum.Current;
                //    docEnum.MoveNext();
                //}
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
            reader.Close();
            databaseConnection.Close();

            return listDocNames;
        }
        
        public byte[] getProjectDocument(int id)
        {
            byte[] doc = new byte[0];

            MySqlCommand selectProjectDocument = new MySqlCommand("SELECT document " +
                                                                    "FROM Project_Documents " +
                                                                   "WHERE id = @id",
                                                                  databaseConnection);
            selectProjectDocument.Parameters.Add("@id", MySqlDbType.Int32);

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = selectProjectDocument.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    Stream stream = reader.GetStream(0);
                    BinaryReader streamReader = new BinaryReader(stream);
                    doc = streamReader.ReadBytes((int)stream.Length);
                    streamReader.Close();
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
            reader.Close();
            databaseConnection.Close();

            return doc;
        }

        public int insertPoject(int builder_id, String project_name, String first_crossroad, String second_crossroad, String cardinal, String location_notes, Decimal aquisition_price, Decimal improvement_cost, int total_lot_count)
        {
            MySqlCommand insertNewProject = new MySqlCommand("INSERT INTO Projects" +
                                                                   "( builder_id, project_name, first_crossroad, second_crossroad, cardinal,  location_notes, aquisition_price, improvement_cost)" + //total_lot_count)"
                                                             "VALUES( @builderId, @projectName, @firstCrossroad, @secondCrossroad, @cardinal, @locationNotes, @aquisitionPrice, @improvementCost)", //, @totalLotCount)",
                                                             databaseConnection);
            insertNewProject.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builder_id;
            insertNewProject.Parameters.Add("@projectName", MySqlDbType.VarChar).Value = project_name;
            insertNewProject.Parameters.Add("@firstCrossroad", MySqlDbType.VarChar, 30).Value = first_crossroad;
            insertNewProject.Parameters.Add("@secondCrossroad", MySqlDbType.VarChar, 30).Value = second_crossroad;
            insertNewProject.Parameters.Add("@cardinal", MySqlDbType.VarChar, 2).Value = cardinal;
            insertNewProject.Parameters.Add("@locationNotes", MySqlDbType.VarChar, 248).Value = location_notes;
            insertNewProject.Parameters.Add("@aquisitionPrice", MySqlDbType.Decimal).Value = aquisition_price;
            insertNewProject.Parameters.Add("@improvementCost", MySqlDbType.Decimal).Value = improvement_cost;
            //insertNewProject.Parameters.Add("@totalLotCount", MySqlDbType.Int32).Value = total_lot_count; not in the database

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = insertNewProject.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public DataTable getProjects(int builder_id, int? value)
        {

            MySqlCommand getProjects = new MySqlCommand("SELECT project_name " +
                                                        "FROM Projects " +
                                                        "WHERE builder_id = @builderId",
                                                      databaseConnection);
            getProjects.Parameters.Add("@builderid", MySqlDbType.Int32).Value = builder_id;
            MySqlDataAdapter daNames = new MySqlDataAdapter(getProjects);
            DataTable dtProjects = new DataTable();
            try
            {
                daNames.Fill(dtProjects);
            }
            catch (MySqlException e)
            {
                Debug.Print(e.Message);
                return null;
            }
            //reader.Close();
            databaseConnection.Close();
            return dtProjects;
        }

        public Project[] getProjects(int builder_id)
        {

            MySqlCommand selectBuilderProjects = new MySqlCommand("SELECT id, project_name, first_crossroad, second_crossroad, cardinal, location_notes, aquisition_price, improvement_cost, date_created" +  Environment.NewLine +// total_lot_count,
                                                                    "FROM Projects " +
                                                                   "WHERE builder_id = @builderId;",
                                                                databaseConnection);
            selectBuilderProjects.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builder_id;

            List<Project> projectList = new List<Project>();
            Project[] projects = new Project[0];
            int projectCount = 0;
            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = selectBuilderProjects.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    int i = reader.GetInt32(0);
                    String pn = reader.GetString(1);
                    String fcs = reader.GetString(2);
                    String scs = reader.GetString(3);
                    String c = reader.GetString(4);
                    String ln = reader.GetString(5);
                    Decimal aq = reader.GetDecimal(6);
                    Decimal ic = reader.GetDecimal(7);
                    // int tlc = reader.GetInt32(8); not in the db
                    DateTime lm = reader.GetDateTime(8);
                    projectCount++;
                    Project newProject = new Project(i, builder_id, pn, fcs, scs, c, ln, aq, ic, lm); // tlc,
                    projectList.Add(newProject);
                }
                projects = new Project[projectCount];
                List<Project>.Enumerator projectEnum = projectList.GetEnumerator();

                int j = 0;
                while (projectEnum.MoveNext())
                {
                    projects[j] = projectEnum.Current;
                    j++;

                }
                //for (int i = 0; i < projectCount; i++)
                //{
                //    projects[i] = projectEnum.Current;
                //    projectEnum.MoveNext();
                //}
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
            reader.Close();
            databaseConnection.Close();

            return projects;
           // return projectList.ToArray();
        }

        public int insertLotType(int project_id, int lot_width, int lot_length, int count, Double purchase_price, Decimal release_price, Decimal sale_price)
        {
            MySqlCommand insertNewLotType = new MySqlCommand("INSERT INTO Lot_Types" +
                                                                   "( project_id, lot_width, lot_length,  count, purchase_price, release_price, sale_price)" +
                                                             "VALUES( @projectId, @lotWidth, @lotLength, @count, @purchasePrice, @releasePrice, @salePrice)",
                                                             databaseConnection);
            insertNewLotType.Parameters.Add("@projectId", MySqlDbType.Int32).Value = project_id;
            insertNewLotType.Parameters.Add("@lotWidth", MySqlDbType.Int32).Value = lot_width;
            insertNewLotType.Parameters.Add("@lotLenght", MySqlDbType.Int32).Value = lot_length;
            insertNewLotType.Parameters.Add("@count", MySqlDbType.Int32).Value = count;
            insertNewLotType.Parameters.Add("@purchasePrice", MySqlDbType.Decimal).Value = purchase_price;
            insertNewLotType.Parameters.Add("@releasePrice", MySqlDbType.Decimal).Value = release_price;
            insertNewLotType.Parameters.Add("@salePrice", MySqlDbType.Decimal).Value = sale_price;
            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = insertNewLotType.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public LotType[] getLotTypes(int project_id)
        {
            MySqlCommand selectLotTypes = new MySqlCommand("SELECT id, lot_width, lot_length, lot_count, purchase_count, sold_count, purchase_price, release_price, sale_price" +
                                                                 "FROM Projects " +
                                                                "WHERE project_id = @projectId",
                                                                databaseConnection);
            selectLotTypes.Parameters.Add("@projectId", MySqlDbType.Int32).Value = project_id;

            List<LotType> lotTypeList = new List<LotType>();
            LotType[] lotTypes = new LotType[0];
            int lotTypeCount = 0;
            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = selectLotTypes.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    int i = reader.GetInt32(0);
                    int lw = reader.GetInt32(1);
                    int ll = reader.GetInt32(2);
                    int c = reader.GetInt32(3);
                    int pc = reader.GetInt32(4);
                    int sc = reader.GetInt32(5);
                    Decimal pp = reader.GetDecimal(6);
                    Decimal rp = reader.GetDecimal(7);
                    Decimal sp = reader.GetDecimal(8);
                    lotTypeCount++;
                    LotType newProject = new LotType(i, project_id, lw, ll, c, pc, sc, pp, rp, sp);
                    lotTypeList.Add(newProject);
                }
                lotTypes = new LotType[lotTypeCount];
                List<LotType>.Enumerator lotTypeEnum = lotTypeList.GetEnumerator();
                for (int i = 0; i < lotTypeCount; i++)
                {
                    lotTypes[i] = lotTypeEnum.Current;
                    lotTypeEnum.MoveNext();
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
            reader.Close();
            databaseConnection.Close();

            return lotTypes;
        }

        public int insertProjectSchedule(int project_id, int projected_lots_purchased, Decimal projected_value_purchased, DateTime schedule_date)
        {

            MySqlCommand insertNewProjectSchedule = new MySqlCommand("INSERT INTO Project_Schedule" +
                                                                           "( project_id, projected_lots_purchased, projected_value_purchased, schedule_date)" +
                                                                     "VALUES( @projectId, @projectedLotsPurchased,  @projectedValuePurchased,  @scheduleDate)",
                                                                 databaseConnection);
            insertNewProjectSchedule.Parameters.Add("@projectId", MySqlDbType.Int32).Value = project_id;
            insertNewProjectSchedule.Parameters.Add("@projectedLotsPurchased", MySqlDbType.Int32).Value = projected_lots_purchased;
            insertNewProjectSchedule.Parameters.Add("@projectedValuePurchased", MySqlDbType.Decimal).Value = projected_value_purchased;
            insertNewProjectSchedule.Parameters.Add("@scheduleDate", MySqlDbType.DateTime).Value = schedule_date;

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = insertNewProjectSchedule.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public int updateProjectSchedule(int id, int projected_lots_purchased, Decimal projected_value_purchased, DateTime schedule_date)
        {

            MySqlCommand updateNewProjectSchedule = new MySqlCommand("UPDATE Project_Schedule" +
                                                                      "( projected_lots_purchased, projected_value_purchased, schedule_date)" +
                                                                      "  @projectedLotsPurchased,  @projectedValuePurchased,  @scheduleDate " +
                                                                  "WHERE id = @id",
                                                                 databaseConnection);
            updateNewProjectSchedule.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            updateNewProjectSchedule.Parameters.Add("@projectedLotsPurchased", MySqlDbType.Int32).Value = projected_lots_purchased;
            updateNewProjectSchedule.Parameters.Add("@projectedValuePurchased", MySqlDbType.Decimal).Value = projected_value_purchased;
            updateNewProjectSchedule.Parameters.Add("@scheduleDate", MySqlDbType.DateTime).Value = schedule_date;

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = updateNewProjectSchedule.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public ProjectSchedule[] getProjectSchedule(int project_id)
        {
            MySqlCommand selectBuilderProjects = new MySqlCommand("SELECT id, project_id, projected_lots_purchased, actual_lots_purchased, lots_sold," +
                                                                     "projected_value_purchased, actual_value_purchased, value_sold, projected_draw," +
                                                                     "actual_draw, schedule_date, date_created, last_modified" +
                                                                 "FROM Project_Schedule " +
                                                                "WHERE project_id = @projectId",
                                                                databaseConnection);
            selectBuilderProjects.Parameters.Add("@projectId", MySqlDbType.Int32).Value = project_id;

            List<ProjectSchedule> projectScheduleList = new List<ProjectSchedule>();
            ProjectSchedule[] projectSchedule = new ProjectSchedule[0];
            int projectScheduleCount = 0;
            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = selectBuilderProjects.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    int i = reader.GetInt32(0);
                    int plp = reader.GetInt32(1);
                    int alp = reader.GetInt32(2);
                    int ls = reader.GetInt32(3);
                    Decimal pvp = reader.GetDecimal(4);
                    Decimal avp = reader.GetDecimal(5);
                    Decimal pvs = reader.GetDecimal(6);
                    Decimal avs = reader.GetDecimal(7);
                    Decimal pd = reader.GetDecimal(8);
                    Decimal ad = reader.GetDecimal(9);
                    DateTime sd = reader.GetDateTime(10);
                    DateTime dc = reader.GetDateTime(11);
                    DateTime lm = reader.GetDateTime(12);
                    projectScheduleCount++;
                    ProjectSchedule newProjectSchedule = new ProjectSchedule(i, project_id, plp, alp, ls, pvp, avp, pvs, avs, pd, ad, sd, dc, lm);
                    projectScheduleList.Add(newProjectSchedule);
                }
                projectSchedule = new ProjectSchedule[projectScheduleCount];
                List<ProjectSchedule>.Enumerator projectScheduleEnum = projectScheduleList.GetEnumerator();
                for (int i = 0; i < projectScheduleCount; i++)
                {
                    projectSchedule[i] = projectScheduleEnum.Current;
                    projectScheduleEnum.MoveNext();
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
            reader.Close();
            databaseConnection.Close();

            return projectSchedule;
        }

        public int insertStep1Comment(int project_id, String text)
        {
            MySqlCommand insertNewStep1Comment = new MySqlCommand("UPDATE Step_One_Comments" +
                                                                   "( project_id, text )" +
                                                                   "  @projectId, @text",
                                                                 databaseConnection);
            insertNewStep1Comment.Parameters.Add("@projectId", MySqlDbType.Int32).Value = project_id;
            insertNewStep1Comment.Parameters.Add("@text", MySqlDbType.VarChar, 1024).Value = text;


            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = insertNewStep1Comment.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public NoteComment[] getStep1Comments(int project_id)
        {
            MySqlCommand selectStep1Comments = new MySqlCommand("SELECT id, text, date_created" +
                                                                "FROM Step_One_Comments " +
                                                               "WHERE project_id = @projectId",
                                                                databaseConnection);
            selectStep1Comments.Parameters.Add("@projectId", MySqlDbType.Int32).Value = project_id;

            List<NoteComment> noteCommentList = new List<NoteComment>();
            NoteComment[] noteComments = new NoteComment[0];
            int noteCommentCount = 0;
            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = selectStep1Comments.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    int i = reader.GetInt32(0);
                    String t = reader.GetString(1);
                    DateTime cd = reader.GetDateTime(2);

                    noteCommentCount++;
                    NoteComment newNoteComment = new NoteComment(i, t, cd);
                    noteCommentList.Add(newNoteComment);
                }
                noteComments = new NoteComment[noteCommentCount];
                List<NoteComment>.Enumerator noteCommentEnum = noteCommentList.GetEnumerator();
                for (int i = 0; i < noteCommentCount; i++)
                {
                    noteComments[i] = noteCommentEnum.Current;
                    noteCommentEnum.MoveNext();
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
            reader.Close();
            databaseConnection.Close();
            return noteComments;
        }

        public int insertStep1Note(int project_id, String text)
        {
            MySqlCommand insertNewStep1Note = new MySqlCommand("UPDATE Step_One_Notes" +
                                                    "( project_id, text )" +
                                                    "  @projectId, @text",
                                                     databaseConnection);
            insertNewStep1Note.Parameters.Add("@projectId", MySqlDbType.Int32).Value = project_id;
            insertNewStep1Note.Parameters.Add("@text", MySqlDbType.VarChar, 1024).Value = text;


            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = insertNewStep1Note.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public NoteComment[] getStep1Notes(int project_id)
        {
            MySqlCommand selectStep1Notes = new MySqlCommand("SELECT id, text, date_created" +
                                                                "FROM Step_One_Notes " +
                                                               "WHERE project_id = @projectId",
                                                                databaseConnection);
            selectStep1Notes.Parameters.Add("@projectId", MySqlDbType.Int32).Value = project_id;

            List<NoteComment> noteCommentList = new List<NoteComment>();
            NoteComment[] noteComments = new NoteComment[0];
            int noteCommentCount = 0;
            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = selectStep1Notes.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    int i = reader.GetInt32(0);
                    String t = reader.GetString(1);
                    DateTime cd = reader.GetDateTime(2);

                    noteCommentCount++;
                    NoteComment newNoteComment = new NoteComment(i, t, cd);
                    noteCommentList.Add(newNoteComment);
                }
                noteComments = new NoteComment[noteCommentCount];
                List<NoteComment>.Enumerator noteCommentEnum = noteCommentList.GetEnumerator();
                for (int i = 0; i < noteCommentCount; i++)
                {
                    noteComments[i] = noteCommentEnum.Current;
                    noteCommentEnum.MoveNext();
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
            reader.Close();
            databaseConnection.Close();
            return noteComments;
        }
    }

    public class BuilderDocumentData
    {
        private int id;
        private int builderId;
        private String docName;
        private String fileName;
        private DateTime last_modified;
        private DateTime last_requested;
        public BuilderDocumentData(int i, int bid, String dn, String fn, DateTime lm, DateTime lr)
        {
            id = i;
            builderId = bid;
            docName = dn;
            fileName = fn;
            last_modified = lm;
            last_requested = lr;
        }
        public int getBuilderId()
        {
            return builderId;
        }
        public String getDocumentName()
        {
            return docName;
        }
        public String getFileName()
        {
            return fileName;
        }
        public DateTime getLastModifiedTime()
        {
            return last_modified;
        }
        public DateTime getLastRequestedTime()
        {
            return last_requested;
        }
        public Boolean isUpToDate()
        {
            return DateTime.Compare(last_modified, last_requested) >= 0;
        }
    }

    public class Project
    {
        private int id;
        private int builderId;
        private String projectName;
        private String firstCrossStreet;
        private String secondCrossStreet;
        private String cardinal;
        private String location_notes;
        private Decimal aquisitionPrice;
        private Decimal improvementCost;
        //private int totalLotCount; not in db
        private DateTime lastModified;

        public Project(int i, int bid, String pn, String fcs, String scs, String card, String ln, Decimal aq, Decimal ic, DateTime lm) //int tlc,
        {
            id = i;
            builderId = bid;
            projectName = pn;
            firstCrossStreet = fcs;
            secondCrossStreet = scs;
            cardinal = card;
            location_notes = ln;
            improvementCost = ic;
            // totalLotCount = tlc;
            lastModified = lm;
            aquisitionPrice = 0;
        }

        public int getId()
        {
            return id;
        }

        public int getBuilderId()
        {
            return builderId;
        }

        public string getProjectName()
        {
            return projectName;
        }

        public Coordinates getCoordinates()
        {
            return new Coordinates(firstCrossStreet, secondCrossStreet, cardinal, location_notes);
        }

        public Decimal getAquisitionPrice()
        {
            return aquisitionPrice;
        }

        public Decimal getImprovementCost()
        {
            return improvementCost;
        }

        //public int getLotCount()
        //{
        //    return totalLotCount;
        //}

        public DateTime getLastModified()
        {
            return lastModified;
        }
    }

    public class Coordinates
    {
        public String firstCrossStreet;
        public String secondCrossStreet;
        public String cardinal;
        public String location_notes;
        public Coordinates(String fcs, String scs, String c, String ln)
        {
            firstCrossStreet = fcs;
            secondCrossStreet = scs;
            cardinal = c;
            location_notes = ln;
        }
    }

    public class ProjectSchedule
    {
        private int id;
        private int projectId;
        private int projectedLotsPurchased;
        private int actualLotsPurchased;
        private int lotsSold;
        private Decimal projectedValuePurchased;
        private Decimal actualValuePurchased;
        private Decimal projectedValueSold;
        private Decimal actualValueSold;
        private Decimal projectedDraw;
        private Decimal actualDraw;
        private DateTime scheduelDate;
        private DateTime dateCreated;
        private DateTime lastModified;

        public ProjectSchedule(int i, int pid, int plp, int alp, int ls, Decimal pvp, Decimal avp,
            Decimal pvs, Decimal avs, Decimal pd, Decimal ad, DateTime sd, DateTime dc, DateTime lm)
        {
            id = i;
            projectId = pid;
            projectedLotsPurchased = plp;
            actualLotsPurchased = alp;
            lotsSold = ls;
            projectedValuePurchased = pvp;
            actualValuePurchased = avp;
            projectedValueSold = pvs;
            actualValueSold = avs;
            projectedDraw = pd;
            actualDraw = ad;
            scheduelDate = sd;
            dateCreated = dc;
            lastModified = lm;
        }

        public int getId()
        {
            return id;
        }
        public int getProjectId()
        {
            return projectId;
        }
        public int getProjectedLotsPurchased()
        {
            return projectedLotsPurchased;
        }
        public int getActualLotsPurchased()
        {
            return actualLotsPurchased;
        }
        public int getLotsSold()
        {
            return lotsSold;
        }
        public Decimal getProjectedValuePurchased()
        {
            return projectedValuePurchased;
        }
        public Decimal getActualValuePurchased()
        {
            return actualValueSold;
        }
        public Decimal getValueSold()
        {
            return projectedValueSold;
        }
        public Decimal getProjectedDraw()
        {
            return projectedDraw;
        }
        public Decimal getActualDraw()
        {
            return actualDraw;
        }
        private DateTime getScheduelDate()
        {
            return scheduelDate;
        }
    }

    public class LotType
    {
        private int id;
        private int projectId;
        private int lotWidth;
        private int lotLength;
        private int lotTypeCount;
        private int purchasedCount;
        private int soldCount;
        private Decimal purchasePrice;
        private Decimal releasePrice;
        private Decimal salePrice;

        public LotType(int i, int pid, int lw, int ll, int c, int pc, int sc, Decimal pp, Decimal rp, Decimal sp)
        {
            id = i;
            projectId = pid;
            lotWidth = lw;
            lotLength = ll;
            lotTypeCount = c;
            purchasedCount = pc;
            soldCount = sc;
            purchasePrice = pp;
            releasePrice = rp;
            salePrice = sp;
        }

        public int getId()
        {
            return id;
        }
        public int getProjectId()
        {
            return projectId;
        }
        public lotDimensions getLotDimensions()
        {
            return new lotDimensions(lotWidth, lotLength);
        }
        public int getLotTypeCount()
        {
            return lotTypeCount;
        }
        public int getPurchasedCount()
        {
            return purchasedCount;
        }
        public int getSoldCount()
        {
            return soldCount;
        }
        public Decimal getPurchasePrice()
        {
            return purchasePrice;
        }
        public Decimal getReleasePrice()
        {
            return releasePrice;
        }
        public Decimal getSalePrice()
        {
            return salePrice;
        }
    }
    public class lotDimensions
    {
        public int width;
        public int length;
        public lotDimensions(int w, int l)
        {
            width = w;
            length = l;
        }
    }

    public class NoteComment
    {
        private int id;
        private String text;
        private DateTime creationDate;
        public NoteComment(int i, String t, DateTime cd)
        {
            id = i;
            text = t;
            creationDate = cd;
        }

        public int getId()
        {
            return id;
        }

        public String getText()
        {
            return text;
        }

        public DateTime getDate()
        {
            return creationDate;
        }
    }
}