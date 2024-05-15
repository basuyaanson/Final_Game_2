using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class GetLogininfo()
    {
        public static bool StartMenu = false;
        public static string UserName;

        public static J_Score score;

        // records.RemoveAll(r => r.Time == "00");
        //新增成績
        public static void AddScoer(string name, int score, string time, int wave, int leve, int hero)
        {
            //獲得文件
            string Json_Score = System.IO.File.ReadAllText(@".\\Score.json");
            List<J_Score> records;

            if (File.Exists(@".\\Score.json"))
            {
                string existingJson = File.ReadAllText(@".\\Score.json");
                records = JsonConvert.DeserializeObject<List<J_Score>>(existingJson);
            }
            else
            {
                records = new List<J_Score>();
            }

            // 添加新数据
            records.Add(new J_Score
            {
                Name = name,
                Score = score,
                Time = time,
                Wave = wave,
                Level = leve,
                Hero = hero
            });

            // 将更新后的数据写回JSON文件
            string updatedJson = JsonConvert.SerializeObject(records, Formatting.Indented);
            File.WriteAllText("Score.json", updatedJson);
            //

        }
    }
}
