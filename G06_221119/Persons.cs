using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace G06_221119 {
	class Person {
		public Person(string personalID, string firstName, string lastName, DateTime birthDate, GenderType gender) : this() {
			PersonalID = personalID;
			FirstName = firstName;
			LastName = lastName;
			BirthDate = birthDate;
			Gender = gender;
		}

		public Person() {
			Children = new List<Person>();
		}

		//koleqciashi ar unda moxdes ertidaigive personalID mqone pirovneba.
		public string PersonalID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public GenderType Gender { get; set; }

		public List<Person> Children { get; private set; }

		public override string ToString() {
			return $"{PersonalID} {FirstName} {LastName} {BirthDate:dd.MM.yyyy} {Gender}";
		}
	}

	enum GenderType : byte {
		Male = 0,
		Female = 1,
	}
}
