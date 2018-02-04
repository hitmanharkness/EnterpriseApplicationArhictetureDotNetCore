using System;
using Chapter2.SRP.Decorator;

namespace Chapter2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestSRP();
        }

        public static void TestSRP()
        {
            var student = new Student()
            {
                Id = "1A",
                Name = "Habib Qureshi",
                DOB = new DateTime(1980, 05, 01)
            };

            //var persistor = new DefaultPersistor<Student>();
            ////persistor.Persist(student);

            //var xmlPersistor = new XMLPersistorDecorator<Student>(persistor);
            //xmlPersistor.Persist(student);

            IPersistor<Student> studentPersistence = new OraclePersistorDecorator<Student>(new JSONPersistorDecorator<Student>(new XMLPersistorDecorator<Student>(new DefaultPersistor<Student>())));

            studentPersistence.Persist(student);
        }
    }
}
