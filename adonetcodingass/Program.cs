using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonetcodingass
{
    internal class Program
    {
        static void Main(string[] args)
        {
           EduTrackDatabase edu= new EduTrackDatabase();
            edu.DisplayCourses();
            edu.AddnewStudent();
            edu.search();
            edu.Displayenrollcouress();
            edu.update();
            edu.CloseConnection();
            edu.getstoredprocedure();
            Disconnected d=new Disconnected();
            d.LoadData();
            d.updateCredits();
            d.Addcourse();
            d.DelStudent();
        }
    }
}
