using MySql.Data.MySqlClient;

namespace EnglishTrainer
{
    public static class DatabaseHelper
    {
        private const string ConnectionString = "Server=localhost;Database=english_trainer;Uid=root;Pwd=password;";

        public static void InitializeDatabase()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                string createResultsTableQuery = @"CREATE TABLE IF NOT EXISTS Results (
                                            Id INT PRIMARY KEY AUTO_INCREMENT,
                                            UserName VARCHAR(100) NOT NULL,
                                            CorrectAnswers INT NOT NULL,
                                            TimeSpent INT NOT NULL)";
                string createWriteAnswerTableQuery = @"CREATE TABLE IF NOT EXISTS WriteAnswerQuestions (
                                            Id INT PRIMARY KEY AUTO_INCREMENT,
                                            Question TEXT NOT NULL,
                                            Answer TEXT NOT NULL)";
                string createMultipleChoiceTableQuery = @"CREATE TABLE IF NOT EXISTS MultipleChoiceQuestions (
                                            Id INT PRIMARY KEY AUTO_INCREMENT,
                                            Question TEXT NOT NULL,
                                            Option1 TEXT NOT NULL,
                                            Option2 TEXT NOT NULL,
                                            Option3 TEXT NOT NULL,
                                            CorrectOption INT NOT NULL)";
                string createCorrectMistakeTableQuery = @"CREATE TABLE IF NOT EXISTS CorrectMistakeQuestions (
                                            Id INT PRIMARY KEY AUTO_INCREMENT,
                                            IncorrectText TEXT NOT NULL,
                                            CorrectedText TEXT NOT NULL)";

                using (var command = new MySqlCommand(createResultsTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new MySqlCommand(createWriteAnswerTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new MySqlCommand(createMultipleChoiceTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new MySqlCommand(createCorrectMistakeTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void SaveResult(string userName, int correctAnswers, int timeSpent)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                string insertQuery = @"INSERT INTO Results (UserName, CorrectAnswers, TimeSpent)
                                       VALUES (@UserName, @CorrectAnswers, @TimeSpent)";
                using (var command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@CorrectAnswers", correctAnswers);
                    command.Parameters.AddWithValue("@TimeSpent", timeSpent);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static MySqlDataReader GetResults()
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            string selectQuery = "SELECT * FROM Results";
            using (var command = new MySqlCommand(selectQuery, connection))
            {
                return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
        }

        public static MySqlDataReader GetWriteAnswerQuestions()
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            string selectQuery = "SELECT * FROM WriteAnswerQuestions";
            using (var command = new MySqlCommand(selectQuery, connection))
            {
                return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
        }

        public static MySqlDataReader GetMultipleChoiceQuestions()
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            string selectQuery = "SELECT * FROM MultipleChoiceQuestions";
            using (var command = new MySqlCommand(selectQuery, connection))
            {
                return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
        }

        public static MySqlDataReader GetCorrectMistakeQuestions()
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            string selectQuery = "SELECT * FROM CorrectMistakeQuestions";
            using (var command = new MySqlCommand(selectQuery, connection))
            {
                return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
        }
    }
}
