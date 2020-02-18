using MySql.Data.MySqlClient;

namespace Software_Project.Handlers {

    class Handler {

        private MySqlConnection conn = new MySqlConnection("Server=localhost;Uid=root;Pwd=root;");

        public Handler() {

            Connect();

        }

        public void Close_Connection(){

            conn.Close();

        }

        private void Connect() {

            conn.Open();
            MySqlCommand stm = new MySqlCommand("create database if not exists main; use main;", conn);
            stm.ExecuteScalar();
            Create_Tables();

        }

        private void Create_Tables(){

            MySqlCommand cmd = new MySqlCommand("create table if not exists users(username varchar(50)); insert into users values('Hristo'),('Pesho');", conn);
            cmd.ExecuteScalar();

        }

    }

}
