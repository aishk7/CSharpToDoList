using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class ToDoList
    {

        public int id { get; set; }
        public string name  { get; set; }
        public string msg { get; set; }
        public string status { get; set; }
        public int prio { get; set; }
        public DateTime dead { get; set; }

        
        public ToDoList(int id, string name, string msg,  string status, int prio, DateTime dead)
        {
            this.id = id;
            this.name = name;
            this.msg = msg;
            this.status = status;
            this.prio = prio;
            this.dead = dead;
        }



    }
}
