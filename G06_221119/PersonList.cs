using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace G06_221119 {
	class PersonList : List<Person> {
		private bool PersonExists(Person person) {
			foreach (var item in this) {
				if (person.PersonalID == item.PersonalID) {
					return true;
				}
			}
			return false;
		}

		new public void Add(Person person) {
			if (!PersonExists(person)) {
				base.Add(person);
			} else {
				throw new Exception("Such person already exists!");
			}
		}

		public void Load(string filePath) {
			PersonList.Load(filePath, this);
		}

		public static void Load(string filePath , ICollection<Person> people) {
			people.Clear();
			using (var reader = new BinaryReader(new FileStream(filePath, FileMode.Open))) {
				while (reader.PeekChar() != -1) {
					Person person = new Person {
						PersonalID = reader.ReadString(),
						FirstName = reader.ReadString(),
						LastName = reader.ReadString(),
						BirthDate = DateTime.FromBinary(reader.ReadInt64()),
						Gender = (GenderType)reader.ReadByte()
					};
					people.Add(person);
				}
			}
		}
		
		public void Save(string filePath) {
			PersonList.Save(filePath, this);
		}

		public static void Save(string filePath, IEnumerable<Person> people) {
			using (var writer = new BinaryWriter(new FileStream(filePath, FileMode.Create))) {
				foreach (var person in people) {
					writer.Write(person.PersonalID);
					writer.Write(person.FirstName);
					writer.Write(person.LastName);
					writer.Write(person.BirthDate.ToBinary());
					writer.Write((byte)person.Gender);
				}
			}
		}
	}
}
