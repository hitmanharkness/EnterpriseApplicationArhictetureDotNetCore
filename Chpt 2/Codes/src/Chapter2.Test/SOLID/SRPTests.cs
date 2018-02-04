using System;
using Xunit;
using Chapter2.SRP.Decorator;

namespace Chapter2.Test.SOLID
{
    public class SRPTests
    {
        [Fact]
        public void Test_SRP_Decorator()
        {
            var student = GetFakeStudent();

            IPersistor<Student> studentPersistence = new OraclePersistorDecorator<Student>(new XMLPersistorDecorator<Student>(new DefaultPersistor<Student>()));

            Assert.True(studentPersistence.Persist(student));
        }

        private Student GetFakeStudent()
        {
            return new Student()
            {
                Id = "1A",
                Name = "Habib Qureshi",
                DOB = new DateTime(1980, 05, 01)
            };
        }
    }
}
