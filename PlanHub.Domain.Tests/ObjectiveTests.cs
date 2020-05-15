using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanHub.Domain.Entities;
using PlanHub.Domain.Exceptions;
using System;

namespace PlanHub.Domain.Tests
{
    [TestClass]
    public class ObjectiveTests
    {
        [TestMethod]
        [ExpectedException(typeof(DomainValidationException), "Objective description must not be empty")]
        public void ObjectiveNameCannotBeBlank()
        {
            var objective = new Objective(Guid.NewGuid(), ValueTypes.OrganizationLevel.CompanyLevel, "Company objective", null, 100);
            objective.ChangeObjectiveDescription("");
        }

        [TestMethod]
        [ExpectedException(typeof(DomainValidationException), "Objective description must be less than 200 characters")]
        public void ObjectiveNameCannotBeGreatherThan200Characters()
        {
            var objective = new Objective(Guid.NewGuid(), ValueTypes.OrganizationLevel.CompanyLevel, "Company objective", null, 100);

            objective.ChangeObjectiveDescription("1234567890".PadRight(201));
        }

        [TestMethod]
        public void ObjectiveNameCanBeChanged()
        {
            var objective = new Objective(Guid.NewGuid(), ValueTypes.OrganizationLevel.CompanyLevel, "Company objective", null, 100);

            objective.ChangeObjectiveDescription("New improved objective");
            Assert.AreEqual("New improved objective", objective.Description);
        }
    }
}
