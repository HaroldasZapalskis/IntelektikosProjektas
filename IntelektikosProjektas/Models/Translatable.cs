using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelektikosProjektas.Models
{
    public class Translatable
    {
        public string originalText { get; set; }

        public Translatable(string text)
        {
            this.originalText = text;
        }

        public string saveText()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;;database=intelektika;user=root;");

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `intelektika`.`translatable`(`originalText`) VALUES('" + this.originalText + "');", conn);

            cmd.ExecuteReader();

            conn.Close();

            return " executing: Model Translatable: saveText()";
        }
    }
}
