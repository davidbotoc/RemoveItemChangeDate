using System;
using System.Linq;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new testdbEntities();

            /*var person = new person
            {
                name = "Test2",
                borrowDate = DateTime.Now.AddDays(28)
            };

            db.persons.Add(person);
            db.SaveChanges();*/

            var query = db.persons.ToList();

            while (true)
            {
                if (query != null)
                {
                    //var person = new person();

                    //var dateQuery = db.persons.ToList().LastOrDefault();
                    //Console.WriteLine(dateQuery.borrowDate);

                    //Console.WriteLine("Person's Name:");
                    //person.name = Console.ReadLine();

                    //person.borrowDate = dateQuery.borrowDate.AddDays(14);
                    //Console.WriteLine(person.borrowDate);

                    //db.persons.Add(person);
                    //db.SaveChanges();

                    //DeleteRecord(person.id);

                    ///

                    Console.WriteLine("Name: ");
                    var kbName = Console.ReadLine();
                    //var queryName = db.persons.Where(x => x.name.Equals(kbName)).FirstOrDefault();

                    //Console.WriteLine(queryName.name + " " + queryName.borrowDate);

                    var removed = false;
                    foreach (var item in query)
                    {
                        if (item.name.Equals(kbName))
                        {
                            db.persons.Remove(item);
                            removed = true;
                        }
                        else
                        {
                            if (removed)
                            {
                                Console.WriteLine(item.name + " " + item.borrowDate);
                                item.borrowDate = item.borrowDate - TimeSpan.FromDays(14);
                                Console.WriteLine(item.name + " " + item.borrowDate);
                            }
                        }
                    }
                    db.SaveChanges();
                }

                var r = Console.ReadLine();

                if (r == "x" || r == "X")
                {
                    break;
                }
            }

            query = db.persons.ToList();

            foreach (var q in query)
            {
                Console.WriteLine(q.name + " " + q.borrowDate);
            }

        }

        public static void DeleteRecord(int id)
        {
            var db = new testdbEntities();
            var nameQuery = db.persons.Find(id);

            Console.WriteLine(nameQuery.id + " " + nameQuery.name + " " + nameQuery.borrowDate);
        }
    }
}
