using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ado.net_assignemt
{
   class MoviesDetails
    {

        List<Movies> li = new List<Movies>()
    {
        new Movies() { MovieId = 100, MovieName = "Bahubali", Actor = "Prabhas",
            Actress = "Tamanna", YOR = 2015 },
        new Movies() { MovieId = 200, MovieName = "Bahubali2", Actor = "Prabhas",
            Actress = "Anushka", YOR = 2017 },
        new Movies() { MovieId = 300, MovieName = "Robot", Actor = "Rajini",
            Actress = "Aish", YOR = 2010 },
        new Movies() { MovieId = 400, MovieName = "3 idiots", Actor = "Amir",
            Actress = "kareena", YOR = 2009 },
        new Movies() { MovieId = 500, MovieName = "Saaho", Actor = "Prabhas",
            Actress = "shraddha", YOR = 2019 },
    };


        public void Show1()
        {//1. display list of movienames acted by prabhas
            var res1 = from m in li
                       where m.Actor == "Prabhas"
                       select m.MovieName;
            Console.WriteLine("===movies acted by prabhas==");
            foreach (var r1 in res1)
            {
                Console.WriteLine(r1);
            }
            //2. display list of all movies released in year 2019
            var res2 = from m in li
                       where m.YOR == 2019
                       select m.MovieName;
            Console.WriteLine("==movies releases in 2019====");
            foreach (var r2 in res2)
            {
                Console.WriteLine(r2);
            }
            // 3.display the list of movies who acted together by prabhas and anushka
            var res3 = from m in li
                       where m.Actor == "Prabhas" && m.Actress == "Anushka"
                       select m.MovieName;

            Console.WriteLine("==movies acted by prabhas and anushka====");
            foreach (var r3 in res3)
            {
                Console.WriteLine(r3);
            }
            //  4.display the list of all actress who acted with prabhas
            var res4 = from m in li
                       where m.Actor == "Prabhas"
                       select m.Actress;
            Console.WriteLine("==actress acted with prabhas ");
            foreach (var r4 in res4)
            {
                Console.WriteLine(r4);
            }
            //  5.display the list of all movies released from 2010 - 2018
            var res5 = from m in li
                       where m.YOR >= 2010 && m.YOR <= 2018
                       select m.MovieName;

            Console.WriteLine("==movies btw 2010 and 2018=== ");
            foreach (var r5 in res5)
            {
                Console.WriteLine(r5);
            }
            //  6.sort YOR in descending order and display all its records
            var res6 = from m in li
                       orderby m.YOR descending
                       select m;
            Console.WriteLine("==sort YOR in descending order=== ");
            foreach (var r6 in res6)
            {
                Console.WriteLine($"{r6.MovieId} {r6.MovieName} {r6.Actor} {r6.Actress} {r6.YOR}");

            }
            // 7.display max movies acted by each acto
            var res7 = from m in li
                       group m by m.Actor into g
                       select new { Actor = g.Key, Movies = g.Count() };
            Console.WriteLine("count of movies");

            foreach (var r7 in res7)
            {
                Console.WriteLine($"{r7.Actor} {r7.Movies}");

            }
            // 8.display the name of all movies which is 5 characters long
            var res8 = from m in li
                       where m.MovieName.Length == 5
                       select m.MovieName;
            Console.WriteLine("==names of movies lenght 5=== ");
            foreach (var r8 in res8)
            {
                Console.WriteLine(r8);

            }
            // 9.display names of actor and actress where movie released inyear 2017
            // 2009 and 2019
            var res9 = from m in li
                       where m.YOR == 2009 || m.YOR == 2017 || m.YOR == 2019
                       select new { m.Actor, m.Actress };

            Console.WriteLine("==released in 2009,2017,2019=== ");
            foreach (var r9 in res9)
            {
                Console.WriteLine(r9);

            }
            // 10.display the name of movies which start with 'b' and ends with 'i
            var res10 = from m in li
                        where m.MovieName.StartsWith("B") && m.MovieName.EndsWith("i")
                        select m.MovieName;
            Console.WriteLine("==name start with b end with i=== ");
            foreach (var r10 in res10)
            {
                Console.WriteLine(r10);

            }
            //11.display name of actress who not acted with Rajini and print in descendingorder
            var res11 = from m in li
                        where m.Actor != "Rajini"
                        orderby m.Actress descending
                        select m.Actress;
            Console.WriteLine("===actress who not acted with Rajini== ");
            foreach (var r11 in res11)
            {
                Console.WriteLine(r11);

            }
            //12
            var res12 = from m in li
                        select new { Moviename=m.MovieName ,Cast=m.Actor+"-"+m.Actress};
            Console.WriteLine("===moviename and cast== ");
            foreach (var r12 in res12)
            {
                Console.WriteLine($"{r12.Moviename}  {r12.Cast}");

            }

        }
    }
}
