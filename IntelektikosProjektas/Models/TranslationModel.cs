using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelektikosProjektas.Models
{
    public class TranslationModel
    {
        public Translatable translatable { get; set; }
        public string translateText { get; set; }
        public int Id { get; set; }

        public TranslationModel(Translatable translatable, string text, int id)
        {
            this.translatable = translatable;
            this.translateText = text;
            this.Id = id;
        }

        public TranslationModel()
        {
        }

        public List<TranslationModel> getList()
        {
            List<TranslationModel> list = new List<TranslationModel>();

            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;;database=intelektika;user=root;");

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM intelektika.translation left join translatable on translation.translatable = translatable.id;", conn);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new TranslationModel(new Translatable(reader["originalText"].ToString()), reader["translateText"].ToString(), Convert.ToInt32(reader["translatable"])));
                }
            }

            conn.Close();

            return list;
        }
    }
}
