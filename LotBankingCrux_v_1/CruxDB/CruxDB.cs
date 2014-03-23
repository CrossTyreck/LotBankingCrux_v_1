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

        public enum itemStatus{DECLINED = -1, NEEDSUPDATE = 0, NEEDSAPPROVAL = 1, APPROVED = 2};

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
            return getUserId(login);
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

        public string getBuilderContactName(int builder_id)
        {
            MySqlCommand getBuilderContact = new MySqlCommand("Select contact_name " +
                                                             "FROM Builder_Data " +
                                                             "WHERE builder_id = @builderId ",
                                                             databaseConnection);
            getBuilderContact.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builder_id;

            string returnValue = "";
            try
            {
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = getBuilderContact.ExecuteReader(CommandBehavior.SequentialAccess);

                while (reader.Read())
                {
                    returnValue = reader.GetString(0);
                }

                return returnValue;
            }

            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            finally
            {
                databaseConnection.Close();
            }
            return returnValue;

        }

        public string getBuilderContactNumber(int builder_id)
        {
            MySqlCommand getBuilderContact = new MySqlCommand("Select contact_number " +
                                                             "FROM Builder_Data " +
                                                             "WHERE builder_id = @builderId ",
                                                             databaseConnection);
            getBuilderContact.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builder_id;

            string returnValue = "";
            try
            {
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = getBuilderContact.ExecuteReader(CommandBehavior.SequentialAccess);

                while (reader.Read())
                {
                    returnValue = reader.GetString(0);
                }

                return returnValue;
            }

            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            finally
            {
                databaseConnection.Close();
            }
            return returnValue;

        }

        public int insertBuilderContact(int builder_id, String contactName, String contactNumber)
        {
            MySqlCommand insertNewBuilder = new MySqlCommand("Update Builder_Data " +
                                                            "Set contact_name = @contactName, contact_number = @contactNumber " +
                                                             "WHERE builder_id = @builderId ",
                                                             databaseConnection);
            insertNewBuilder.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builder_id;
            insertNewBuilder.Parameters.Add("@contactName", MySqlDbType.VarChar, 30).Value = contactName;
            insertNewBuilder.Parameters.Add("@contactNumber", MySqlDbType.VarChar, 20).Value = contactNumber;
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

        public Dictionary<int, String> getBuilderIds()
        {
            MySqlCommand getBuilderIds = new MySqlCommand("SELECT builder_id, " +
                                                                 "name " +
                                                            "FROM Builder_Data ",
                                                      databaseConnection);
            databaseConnection.Open();
            Dictionary<int, String> returnValue = null;
            try
            {
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = getBuilderIds.ExecuteReader(CommandBehavior.SequentialAccess);

                returnValue = new Dictionary<int, String>();

                while (reader.Read())
                {
                    returnValue.Add(reader.GetInt32(0), reader.GetString(1));
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

        public int getBuilderId(String name)
        {

            MySqlCommand getBuilderId = new MySqlCommand("SELECT builder_id " +
                                                           "FROM Builder_Data " +
                                                          "WHERE name = @name",
                                                      databaseConnection);
            getBuilderId.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            databaseConnection.Open();
            int returnValue = -2;

            try
            {
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = getBuilderId.ExecuteReader(CommandBehavior.SequentialAccess);

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
        public String getBuilderName(int id)
        {
            MySqlCommand getBuildersNameQuery = new MySqlCommand("SELECT name" +
                                                              "FROM Builder_Data" +
                                                             "WHERE bid = @id",
                                                         databaseConnection);
            getBuildersNameQuery.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            databaseConnection.Open();
            MySqlDataReader reader;
            String name = "";
            try
            {
                reader = getBuildersNameQuery.ExecuteReader(CommandBehavior.SequentialAccess);
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

        public DataTable getBuilderNameID()
        {
            DataTable builders = new DataTable();
            builders.Columns.Add("Builder Name", typeof(String));
            builders.Columns.Add("Builder ID", typeof(int));

            MySqlCommand getBuildersNamesQuery = new MySqlCommand("SELECT name, builder_id " +
                                                              "FROM Builder_Data " +
                                                              "ORDER BY name ASC ",
                                                         databaseConnection);
            MySqlDataReader reader;
            databaseConnection.Open();
            try
            {
                reader = getBuildersNamesQuery.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    DataRow row = builders.NewRow();
                    row[0] = reader.GetString(0);
                    row[1] = reader.GetInt32(1);
                    builders.Rows.Add(row);
                    
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
            reader.Close();
            databaseConnection.Close();
            return builders;
        }

        public Dictionary<int, String> getBuilderNames()
        {
            MySqlCommand getBuildersNamesQuery = new MySqlCommand("SELECT builder_id, " +
                                                                    "name " +
                                                               "FROM Builder_Data " +
                                                               "SORT BY name ASC",
                                                         databaseConnection);
            Dictionary<int, String> returnValues = new Dictionary<int, string>();
            MySqlDataReader reader;
            try
            {
                reader = getBuildersNamesQuery.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    returnValues.Add(reader.GetInt32(0), reader.GetString(1));
                }
            }
            catch (MySqlException e)
            {
                Debug.Print(e.Message);
                return null;
            }
            databaseConnection.Close();
            return returnValues;
        }

        public Dictionary<int, String[]> getBuilderProjects(List<int> builderIds)
        {
            String idParams = "";
            int i = builderIds.Count;
            for(int j = 0; j < i; j++)
            {
                idParams += "@bid" + j +", ";
            }
            MySqlCommand getBuilderProjects = new MySqlCommand("SELECT id, " +
                                                                      "project_name, " +
                                                                      "last_modified_timestamp " +
                                                                 "FROM Projects " +
                                                                "WHERE builder_id IN( " + idParams +")",
                                                         databaseConnection);

            int[] bids = builderIds.ToArray();
            for (int j = 0; j < i; j++)
            {
                getBuilderProjects.Parameters.Add("@bid" + j, MySqlDbType.Int32).Value = bids[j];
            }
            Dictionary<int, String[]> returnValues = new Dictionary<int, String[]>();
            MySqlDataReader reader;
            databaseConnection.Open();
            try
            {
                reader = getBuilderProjects.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    returnValues.Add(reader.GetInt32(0), new String[] {reader.GetString(1), reader.GetDateTime(2).ToString()});
                }
            }
            catch (MySqlException e)
            {
                Debug.Print(e.Message);
                return null;
            }
            databaseConnection.Close();
            return returnValues;
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

        public Dictionary<int, String[]> getBuilderDocumentsByBID(int builder_id, String orderBy)
        {
            String order = "";
            if (orderBy.Equals("Project Name"))
            {
                order = "ORDER BY project_name ASC ";
            }
            else if (orderBy.Equals("Submission Date"))
            {
                order = "ORDER BY date_created DESC ";
            }
            else if (orderBy.Equals("Approval Date"))
            {
                order = "ORDER BY approval_timestamp DESC ";
            }
            else if (orderBy.Equals("Last Requested Date"))
            {
                order = "ORDER BY last_requested DESC ";
            }



            MySqlCommand getBuilderProjects = new MySqlCommand("SELECT id, " +
                                                                      "file_name, " +
                                                                      "date_created, " +
                                                                      "approval_timestamp, " +
                                                                      "last_modified " +
                                                                 "FROM Builder_Documents " +
                                                                "WHERE builder_id = @builderId " +
                                                                order,
                                              databaseConnection);
            getBuilderProjects.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builder_id;

            Dictionary<int, String[]> returnValues = new Dictionary<int, String[]>();
            databaseConnection.Open();
            MySqlDataReader reader;
            try
            {
                reader = getBuilderProjects.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    returnValues.Add(reader.GetInt32(0), new String[] { reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4) });
                }
            }
            catch (MySqlException e)
            {
                Debug.Print(e.Message);
                return null;
            }
            finally
            {
                databaseConnection.Close();
            }
            return returnValues;
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
            MySqlCommand selectBuilderDocumentData = new MySqlCommand("SELECT id, builder_id, file_name, date_created, " +
                                                                             "last_modified, last_requested, approval_timestamp " +
                                                                       "FROM Builder_Documents " +
                                                                      "WHERE builder_id = @builderId",
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
                    DateTime dc = reader.GetDateTime(4);
                    DateTime lu = reader.GetDateTime(5);
                    DateTime lr = reader.GetDateTime(6);
                    DateTime a = reader.GetDateTime(7);
                    docCount++;
                    BuilderDocumentData newDoc = new BuilderDocumentData(i, bid, dn, fn, dc, lu, lr, a);
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

        public Dictionary<int, String[]> getProjectDocumentNames(int project_id)
        {
            MySqlCommand selectProjectDocuments = new MySqlCommand("SELECT id, " +
                                                                          "file_name, " +
                                                                          "last_modified " +
                                                                     "FROM Project_Documents " +
                                                                    "WHERE project_id = @projectId",
                                                                databaseConnection);
            selectProjectDocuments.Parameters.Add("@projectId", MySqlDbType.Int32).Value = project_id;



            databaseConnection.Open();

            MySqlDataReader reader;
            Dictionary<int, String[]> listDocNames = new Dictionary<int, String[]>();

            try
            {
                reader = selectProjectDocuments.ExecuteReader(CommandBehavior.SequentialAccess);

                while (reader.Read())
                {
                    listDocNames.Add(reader.GetInt32(0), new String[] { reader.GetString(1), reader.GetString(2) });
                }
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
            finally
            {
                databaseConnection.Close();
            }
            return doc;
        }

        public int insertProject(int builder_id, String project_name, String first_crossroad, String second_crossroad, String city, String state, String cardinal, String location_notes, Decimal aquisition_price, Decimal improvement_cost, int total_lot_count)
        {
            MySqlCommand insertNewProject = new MySqlCommand("INSERT INTO Projects" +
                                                                   "( builder_id, project_name, first_crossroad, second_crossroad, city, state, cardinal,  location_notes, aquisition_price, improvement_cost, total_lot_count)" +
                                                             "VALUES( @builderId, @projectName, @firstCrossroad, @secondCrossroad, @city, @state, @cardinal, @locationNotes, @aquisitionPrice, @improvementCost, @totalLotCount)",
                                                             databaseConnection);
            insertNewProject.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builder_id;
            insertNewProject.Parameters.Add("@projectName", MySqlDbType.VarChar).Value = project_name;
            insertNewProject.Parameters.Add("@firstCrossroad", MySqlDbType.VarChar, 30).Value = first_crossroad;
            insertNewProject.Parameters.Add("@secondCrossroad", MySqlDbType.VarChar, 30).Value = second_crossroad;
            insertNewProject.Parameters.Add("@city", MySqlDbType.VarChar, 30).Value = city;
            insertNewProject.Parameters.Add("@state", MySqlDbType.VarChar, 30).Value = state;
            insertNewProject.Parameters.Add("@cardinal", MySqlDbType.VarChar, 2).Value = cardinal;
            insertNewProject.Parameters.Add("@locationNotes", MySqlDbType.VarChar, 248).Value = location_notes;
            insertNewProject.Parameters.Add("@aquisitionPrice", MySqlDbType.Decimal).Value = aquisition_price;
            insertNewProject.Parameters.Add("@improvementCost", MySqlDbType.Decimal).Value = improvement_cost;
            insertNewProject.Parameters.Add("@totalLotCount", MySqlDbType.Int32).Value = total_lot_count;

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
            finally
            {
                databaseConnection.Close();
            }
            return 1;
        }

        public int updatePoject(int project_id, String project_name, String first_crossroad, String second_crossroad, String city, String state, String cardinal, String location_notes, Decimal aquisition_price, Decimal improvement_cost, int total_lot_count)
        {
            MySqlCommand insertNewProject = new MySqlCommand("UPDATE Projects" +
                                                                "SET last_modified = NOW(), " +
                                                                    "project_name = @projectName, " +
                                                                    "first_crossroad = @firstCrossroad, " +
                                                                    "second_crossroad = @secondCrossroad, " +
                                                                    "city = @city, " +
                                                                    "state = @state, " +
                                                                    "cardinal = @cardinal, " +
                                                                    "location_notes = @locationNotes, " +
                                                                    "aquisition_price = @aqusitionPrice, " +
                                                                    "improvement_cost = @improvementCost, " +
                                                                    "total_lot_count = @totalLotCount",
                                                              databaseConnection);
            insertNewProject.Parameters.Add("@projectId", MySqlDbType.Int32).Value = project_id;
            insertNewProject.Parameters.Add("@projectName", MySqlDbType.VarChar).Value = project_name;
            insertNewProject.Parameters.Add("@firstCrossroad", MySqlDbType.VarChar, 30).Value = first_crossroad;
            insertNewProject.Parameters.Add("@secondCrossroad", MySqlDbType.VarChar, 30).Value = second_crossroad;
            insertNewProject.Parameters.Add("@city", MySqlDbType.VarChar, 30).Value = city;
            insertNewProject.Parameters.Add("@state", MySqlDbType.VarChar, 30).Value = state;
            insertNewProject.Parameters.Add("@cardinal", MySqlDbType.VarChar, 2).Value = cardinal;
            insertNewProject.Parameters.Add("@locationNotes", MySqlDbType.VarChar, 248).Value = location_notes;
            insertNewProject.Parameters.Add("@aquisitionPrice", MySqlDbType.Decimal).Value = aquisition_price;
            insertNewProject.Parameters.Add("@improvementCost", MySqlDbType.Decimal).Value = improvement_cost;
            insertNewProject.Parameters.Add("@totalLotCount", MySqlDbType.Int32).Value = total_lot_count;

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
            finally
            {
                databaseConnection.Close();
            }
            return 1;
        }

        public Dictionary<int, String> getProjectsNames(int builder_id, int value)
        {

            MySqlCommand getProjectNamesQuery = new MySqlCommand("SELECT id, " +
                                                                        "project_name " +
                                                                   "FROM Projects " +
                                                                  "WHERE builder_id = @builderId",
                                                                  databaseConnection);
            getProjectNamesQuery.Parameters.Add("@builderid", MySqlDbType.Int32).Value = builder_id;
            Dictionary<int, String> returnValues = new Dictionary<int, String>();
            databaseConnection.Open();
            MySqlDataReader reader;
            try
            {
                reader = getProjectNamesQuery.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {

                }
            }
            catch (MySqlException e)
            {
                Debug.Print(e.Message);
                return null;
            }
            finally
            {
                databaseConnection.Close();
            }
            return returnValues;
        }

        public Dictionary<int, String[]> getProjectsByBID(int builder_id, String orderBy, Boolean excludeDeclined)
        {
            String exclusion = "";
            if (excludeDeclined)
            {
                exclusion = "AND decline_id != -1 ";
            }

            String order = "";
            if (orderBy.Equals("Project Name"))
            {
                order = "ORDER BY project_name ASC ";
            }
            else if (orderBy.Equals("Submission Date"))
            {
                order = "ORDER BY date_created DESC ";
            }
            else if (orderBy.Equals("Approval Date"))
            {
                order = "ORDER BY approval_timestamp DESC ";
            }
            else if (orderBy.Equals("Last Requested Date"))
            {
                order = "ORDER BY last_requested DESC ";
            }



            MySqlCommand getBuilderProjects = new MySqlCommand("SELECT id, " +
                                                                      "project_name, " +
                                                                      "date_created, " +
                                                                      "approval_timestamp, " +
                                                                      "last_modified " +
                                                                 "FROM Projects " +
                                                                "WHERE builder_id = @builderId " +
                                                                  "AND approval_id >= 0 " +
                                                                exclusion +
                                                                order,
                                              databaseConnection);
            getBuilderProjects.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builder_id;

            Dictionary<int, String[]> returnValues = new Dictionary<int, String[]>();

            databaseConnection.Open(); 
            MySqlDataReader reader;
            try
            {
                reader = getBuilderProjects.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    returnValues.Add(reader.GetInt32(0), new String[] { reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4) });
                }
            }
            catch (MySqlException e)
            {
                Debug.Print(e.Message);
                return null;
            }
            databaseConnection.Close();
            return returnValues;
        }

        public Project[] getProjects(int builder_id)
        {

            MySqlCommand selectBuilderProjects = new MySqlCommand("SELECT id, project_name, first_crossroad, second_crossroad, cardinal, location_notes, " +
                                                                         "aquisition_price, improvement_cost, date_created, last_modified, last_requested_timestamp, " +
                                                                         "approval_timestamp, decline_timestamp, total_lot_count" +
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
                    String city = reader.GetString(4);
                    String state = reader.GetString(5);
                    String c = reader.GetString(6);
                    String ln = reader.GetString(7);
                    Decimal aq = reader.GetDecimal(8);
                    Decimal ic = reader.GetDecimal(9);
                    DateTime dc = reader.GetDateTime(10);
                    DateTime lu = reader.GetDateTime(11);
                    DateTime lr = reader.GetDateTime(12);
                    DateTime a = reader.GetDateTime(13);
                    DateTime d = reader.GetDateTime(14);
                    int tlc = reader.GetInt32(15);
                    projectCount++;
                    Project newProject = new Project(i, builder_id, pn, fcs, scs, city, state, c, ln, aq, ic, dc, lu, lr, a, d, tlc);
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
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
            reader.Close();
            databaseConnection.Close();

            return projects;
        }

        public Project getProposal(int proposal_id)
        {
            MySqlCommand getProposal = new MySqlCommand("SELECT id, project_name, first_crossroad, second_crossroad, city, state, cardinal, location_notes, " +
                                                                         "aquisition_price, improvement_cost, date_created, last_modified, last_requested_timestamp, " +
                                                                         "approval_timestamp, decline_timestamp, total_lot_count, builder_id " +
                                                                    "FROM Projects " +
                                                                   "WHERE id = @ProposalId;",
                                                                databaseConnection);

            getProposal.Parameters.Add("@ProposalId", MySqlDbType.Int32).Value = proposal_id;

          
            MySqlDataReader reader;
            databaseConnection.Open();
            try
            {
                reader = getProposal.ExecuteReader(CommandBehavior.SequentialAccess);
                if (reader.Read())
                {
                    int i = reader.GetInt32(0);
                    String pn = reader.GetString(1);
                    String fcs = reader.GetString(2);
                    String scs = reader.GetString(3);
                    String city = reader.GetString(4);
                    String state = reader.GetString(5);
                    String c = reader.GetString(6);
                    String ln = reader.GetString(7);
                    Decimal aq = reader.GetDecimal(8);
                    Decimal ic = reader.GetDecimal(9);
                    DateTime dc = reader.GetDateTime(10);
                    DateTime lu = reader.GetDateTime(11);
                    DateTime lr = reader.GetDateTime(12);
                    DateTime a = reader.GetDateTime(13);
                    DateTime d = reader.GetDateTime(14);
                    int tlc = reader.GetInt32(15);
                    int builder_id = reader.GetInt32(16);

                    Project newProject = new Project(i, builder_id, pn, fcs, scs, city, state, c, ln, aq, ic, dc, lu, lr, a, d, tlc);
                    return newProject;
                }
            }
            catch (MySqlException e)
            {
                Debug.Print(e.Message);
                return null;
            }
            finally
            {
                databaseConnection.Close();
            }

            return null;
         
        }



        public Dictionary<int, String[]> getProposalsByBID(int builder_id, String orderBy, Boolean includeDeclined = false, Boolean includeAwaitingBuilder = false, Boolean includeAwaitingApproval = false)
        {
            String exclusion = "";
            if (!includeDeclined)
            {
                exclusion = "AND decline_id != -1 ";
            }
            if (!includeAwaitingBuilder)
            {
                exclusion += "AND (last_modified_timestamp <= last_requested_timestamp) ";
            }
            if (!includeAwaitingApproval)
            {
                exclusion += "AND (last_modified_timestamp > last_requested_timestamp || creation_timestamp > last_requested_timestamp) ";
            }

            String order = "";
            if (orderBy.Equals("Project Name"))
            {
                order = "ORDER BY project_name ASC ";
            }
            else if (orderBy.Equals("Submission Date"))
            {
                order = "ORDER BY date_created DESC ";
            }
            else if (orderBy.Equals("Approval Date"))
            {
                order = "ORDER BY approval_timestamp DESC ";
            }
            else if (orderBy.Equals("Last Requested Date"))
            {
                order = "ORDER BY last_requested DESC ";
            }



            MySqlCommand getBuilderProjects = new MySqlCommand("SELECT id," +
                                                                      "project_name, " +
                                                                      "date_created," +
                                                                      "approval_timestamp," +
                                                                      "last_modified " +
                                                                 "FROM Projects " +
                                                                "WHERE builder_id = @builderId " +
                                                                  "AND approval_id = -1 " +
                                                                exclusion +
                                                                order,
                                              databaseConnection);
            getBuilderProjects.Parameters.Add("@builderId", MySqlDbType.Int32).Value = builder_id;

            Dictionary<int, String[]> returnValues = new Dictionary<int, String[]>();
            MySqlDataReader reader;
            databaseConnection.Open();
            try
            {
                reader = getBuilderProjects.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    returnValues.Add(reader.GetInt32(0), new String[] { reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4) });
                }
            }
            catch (MySqlException e)
            {
                Debug.Print(e.Message);
                return null;
            }
            databaseConnection.Close();
            return returnValues;
        }

        public int acceptProposal(int projectId, int userId)
        {
            MySqlCommand updateProject = new MySqlCommand("UPDATE Projects " +
                                                                "SET approval_timestamp = NOW(), " +
                                                                    "approval_id = @userId " +
                                                              "WHERE id = @id",
                                                             databaseConnection);

            updateProject.Parameters.Add("@userId", MySqlDbType.Int32).Value =  userId;
            updateProject.Parameters.Add("@id", MySqlDbType.Int32).Value = projectId;

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = updateProject.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            finally
            {
                databaseConnection.Close();
            }
            return 1;
        }

        public int declineProposal(int projectId, int userId)
        {
            MySqlCommand updateProject = new MySqlCommand("UPDATE Projects" +
                                                                "SET decline_timestamp = NOW(), " +
                                                                    "decline_id = @userId " +
                                                              "WHERE id = @id",
                                                             databaseConnection);

            updateProject.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
            updateProject.Parameters.Add("@id", MySqlDbType.Int32).Value = projectId;

            databaseConnection.Open();

            MySqlDataReader reader;
            try
            {
                reader = updateProject.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return -1;
            }
            finally
            {
                databaseConnection.Close();
            }
            return 1;
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

        public int insertProjectScheduleEntry(int project_id, int projected_lots_purchased, Decimal projected_value_purchased, DateTime schedule_date)
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

        public int updateProjectScheduleEntry(int id, int projected_lots_purchased, Decimal projected_value_purchased, DateTime schedule_date)
        {
            MySqlCommand updateNewProjectSchedule = new MySqlCommand("UPDATE Project_Schedule_Entry" +
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

        public ProjectScheduleEntry[] getProjectSchedule(int project_id)
        {
            MySqlCommand selectBuilderProjects = new MySqlCommand("SELECT id, project_id, projected_lots_purchased, actual_lots_purchased, lots_sold," +
                                                                     "projected_value_purchased, actual_value_purchased, value_sold, projected_draw," +
                                                                     "actual_draw, schedule_date, date_created, last_modified" +
                                                                 "FROM Project_Schedule " +
                                                                "WHERE project_id = @projectId",
                                                                databaseConnection);
            selectBuilderProjects.Parameters.Add("@projectId", MySqlDbType.Int32).Value = project_id;

            List<ProjectScheduleEntry> projectScheduleList = new List<ProjectScheduleEntry>();
            ProjectScheduleEntry[] projectSchedule = new ProjectScheduleEntry[0];
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
                    ProjectScheduleEntry newProjectSchedule = new ProjectScheduleEntry(i, project_id, plp, alp, ls, pvp, avp, pvs, avs, pd, ad, sd, dc, lm);
                    projectScheduleList.Add(newProjectSchedule);
                }
                projectSchedule = new ProjectScheduleEntry[projectScheduleCount];
                List<ProjectScheduleEntry>.Enumerator projectScheduleEnum = projectScheduleList.GetEnumerator();
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
        public DateOrganizer dateObject;
        
        public BuilderDocumentData(int i, int bid, String dn, String fn, DateTime dc, DateTime lu, DateTime lr, DateTime a)
        {
            id = i;
            builderId = bid;
            docName = dn;
            fileName = fn;
            dateObject = new DateOrganizer(dc, lu, lr, a, null, true);
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
    }

    public class Project
    {
        private int id;
        private int builderId;
        private String projectName;
        private String firstCrossStreet;
        private String secondCrossStreet;
        private String city;
        private String state;
        private String cardinal;
        private String location_notes;
        private Decimal aquisitionPrice;
        private Decimal improvementCost;
        private int totalLotCount;
        public DateOrganizer dateObject;
        
        public Project(int i, int bid, String pn, String fcs, String scs, String cty, String stt, String card, String ln, Decimal aq, Decimal ic, DateTime dc, DateTime lu, DateTime lr, DateTime a, DateTime d, int tlc)
        {
            id = i;
            builderId = bid;
            projectName = pn;
            firstCrossStreet = fcs;
            secondCrossStreet = scs;
            city = cty;
            state = stt;
            cardinal = card;
            location_notes = ln;
            improvementCost = ic;
            totalLotCount = tlc;
            aquisitionPrice = 0;
            dateObject = new DateOrganizer(dc, lu, lr, a, d, true);
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

        public string getFirstCrossStreet()
        {
            return firstCrossStreet;
        }

        public string getSecondCrossStreet()
        {
            return secondCrossStreet;
        }

        public string getCity()
        {
            return city;
        }

        public string getState()
        {
            return state;
        }

        public string getCardinal()
        {
            return cardinal;
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

        public int getLotCount()
        {
            return totalLotCount;
        }
    }


    public class ProjectDocumentData
    {
        private int id;
        private int projectId;
        private String docName;
        private String fileName;
        public DateOrganizer dateObject;
        
        public ProjectDocumentData(int i, int pid, String dn, String fn, DateTime dc, DateTime lu, DateTime lr, DateTime a, DateTime d)
        {
            id = i;
            projectId = pid;
            docName = dn;
            fileName = fn;
            dateObject = new DateOrganizer(dc, lu, lr, a, d, true);
        }
        public int getProjectId()
        {
            return projectId;
        }
        public String getDocumentName()
        {
            return docName;
        }
        public String getFileName()
        {
            return fileName;
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

    public class ProjectScheduleEntry
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
        private DateTime lastUpdated;

        public ProjectScheduleEntry(int i, int pid, int plp, int alp, int ls, Decimal pvp, Decimal avp,
            Decimal pvs, Decimal avs, Decimal pd, Decimal ad, DateTime sd, DateTime dc, DateTime lu)
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
            lastUpdated = lu;
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
        public DateTime getScheduelDate()
        {
            return scheduelDate;
        }
        public DateTime getLastUpdated()
        {
            return lastUpdated;
        }
    }

    public class dateAggregateObject
    {
        public dateAggregateObject()
        {
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

    public class DateOrganizer
    {
        
        private DateTime dateCreated;
        private DateTime lastUpdated;
        private DateTime lastRequested;
        private DateTime approoved;
        private DateTime declined;
        private Boolean hasApproval;

        public DateOrganizer(DateTime dc, DateTime lu, DateTime lr, DateTime a, DateTime? d, Boolean ha)
        {
            dateCreated = dc;
            lastUpdated = lu;
            lastRequested = lr;
            approoved = a;
            try
            {
                declined = (DateTime)d;
            }
            catch
            {
                declined = DateTime.MinValue;
            }
            hasApproval = ha;
        }

        private Boolean upToDate()
        {
            if (lastUpdated > lastRequested || !hasApproval)
            {
                return true;
            }
            return false;
        }

        private Boolean isApproved()
        {
            if ((approoved > lastRequested && approoved >= lastUpdated && declined == null) || !hasApproval)
            {
                return true;
            }
            return false;
        }

        private Boolean isDeclined()
        {
            if (declined != null && (DateTime)declined > dateCreated && hasApproval)
            {
                return true;
            }
            return false;
        }

        public CruxDB.itemStatus getStatus()
        {
            //-1 = declined, 0 = needs update, 1 = needs approval, 2 = approoved
            if (isDeclined())
            {
                return CruxDB.itemStatus.APPROVED;
            }
            if (upToDate() && !isApproved())
            {
                return CruxDB.itemStatus.NEEDSAPPROVAL;
            }
            else if(isApproved())
            {
                return CruxDB.itemStatus.APPROVED;
            }
            return CruxDB.itemStatus.NEEDSUPDATE;
        }
    }
}