using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G06_221119 {
	class Program {
		static void Main(string[] args) {
			PersonList people = new PersonList();
			Person p1 = new Person("01024078113", "Ioane", "Mamulashvili", new DateTime(2000, 1, 28), GenderType.Male);
			Person p2 = new Person("01024078116", "Giorgi", "Naneishvili", new DateTime(1992, 10, 24), GenderType.Male);

			p1.Children.Add(p2);

			people.Add(p1);
			
			//people.Save(@"D:\SaveLog.bin");
			//PersonList.Save(@"D:\SaveLog.bin", people);

			//people.Load(@"D:\SaveLog.Bin");

			foreach (var person in people) {
				Console.WriteLine(person);
			}

			Console.ReadKey();
		}
	}
}
