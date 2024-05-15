using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class J_About//json類
    {
        public string Title { get; set; }
        public List<string> Content { get; set; }
    }
    public class J_Score//json類
    {
        public string Name { get; set; }
        public string Time { get; set; }
        public int Score { get; set; }
        public int Wave { get; set; }
        public int Level { get; set; }
        public int Hero { get; set; }
    }
}
