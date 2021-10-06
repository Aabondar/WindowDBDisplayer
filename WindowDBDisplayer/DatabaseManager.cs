using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;

namespace TestTaskWindowsApp
{
    static class DatabaseManager
    {
        private static string connectionString = null; //Строка соединения с базой данных
        private const string configFileName = @"\ConnectionString.txt";
        private const string configFileDefaultText = @"Connection String = ";
        public static DataTable rawData { get; private set; }

        public static void InitializeConnectionString() //Создаем конфигурационный файл для connection string-а, в случае если его нет
        {
            try
            {
                if (!File.Exists(Environment.CurrentDirectory + configFileName)) //Создаем файл по шаблону, сообщаем пользователю о необходимости ввести connection string и закрываем приложение
                {
                    File.WriteAllText(Environment.CurrentDirectory + configFileName, configFileDefaultText);
                    MessageBox.Show("File 'ConnectionString.txt' created in the application root directory, but it still has to be filled, please.",
                                                              "Attention!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    Environment.Exit(-2);
                }
                else //Если connection string в файле не пустой, извлекаем его. Иначе сообщаем о проблеме и выходим из приложения
                {
                    try
                    {
                        string strBuffer;
                        var file = new StreamReader(Environment.CurrentDirectory + configFileName);
                        strBuffer = file.ReadLine();
                        strBuffer = strBuffer.Remove(0, configFileDefaultText.Length - 1);
                        connectionString = strBuffer.Trim();
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Proper work of the application requires You to set the SQL server connection string in the file 'ConnectionString.txt' please.",
                                                                  "Warning!", MessageBoxButton.OK, MessageBoxImage.Hand);
                        Environment.Exit(-1);
                    }

                    if (connectionString == null || connectionString == string.Empty)
                    {
                        MessageBox.Show("Proper work of the application requires You to set the SQL server connection string in the file 'ConnectionString.txt' please.",
                                                                  "Warning!", MessageBoxButton.OK, MessageBoxImage.Hand);
                        Environment.Exit(-1);
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Failed to create or access file 'ConnectionString.txt'!",
                                                          "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
                Environment.Exit(-3);
            }
        }

        public static void ReadFromDB(ObservableCollection<CarParts> carPartsCollection) //Метод для вызова процедуры чтения нужных нам данных с базы данных
        {
            string queryString = @"USE AutoSpareParts
                                   EXEC ReadFromDB";
            
            try
            {
                rawData = new DataTable();

                using (SqlConnection connection = new SqlConnection(connectionString)) //Заполняем DataTable данными с базы
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(queryString, connection);
                    adapter.Fill(rawData);
                }

                for (int i = 0; i < rawData.Rows.Count; i++)
                {
                    string venCodeParser = (string)rawData.Rows[i]["Vencode"] + "       " + (string)rawData.Rows[i]["Brand"];

                    while (venCodeParser.IndexOf(".") != -1) //Убираем точки из артикула и добавляем бренд
                    {
                        venCodeParser = venCodeParser.Remove(venCodeParser.IndexOf("."), 1);
                    }

                    string partNameString;

                    if ((string)rawData.Rows[i]["Name"] == null || (string)rawData.Rows[i]["Name"] == string.Empty) //Если в поле названия зап. части ничего нет - выводим "не найдено"
                        partNameString = "не найдено";
                    else
                        partNameString = (string)rawData.Rows[i]["Name"];

                    string linkedNumberParser = (string)rawData.Rows[i]["Number"];

                    while (linkedNumberParser.IndexOf(" ") != -1) //Убираем пробелы из связанного номера
                    {
                        linkedNumberParser = linkedNumberParser.Remove(linkedNumberParser.IndexOf(" "), 1);
                    }
                    while (linkedNumberParser.IndexOf("-") != -1) //Убираем дефисы из связанного номера
                    {
                        linkedNumberParser = linkedNumberParser.Remove(linkedNumberParser.IndexOf("-"), 1);
                    }
                    while (linkedNumberParser.IndexOf(".") != -1) //Убираем точки из связанного номера
                    {
                        linkedNumberParser = linkedNumberParser.Remove(linkedNumberParser.IndexOf("."), 1);
                    }

                    carPartsCollection.Add(new CarParts  //Создаем экземпляры CarParts и заполняем их обработанными данными с базы
                    {
                        venCode = venCodeParser,
                        partName = partNameString,
                        linkedNumber = linkedNumberParser + "  " + (string)rawData.Rows[i]["LinkedName"]
                    });
                }
            }

            catch (SqlException)
            {
                MessageBox.Show("Database access error. Please check if the connection string is properly installed.",
                                "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
    }
}


