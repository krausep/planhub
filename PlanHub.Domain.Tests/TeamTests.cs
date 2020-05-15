using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanHub.Domain.Exceptions;
using PlanHub.Domain.Teams;
using System;

namespace PlanHub.Domain.Tests
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void TeamMember_FirstNameChange()
        {
            var teamMember = new TeamMember(Guid.NewGuid(), "abc", null, "def", "sir", false);

            teamMember.ChangeFirstName("cba");

            Assert.AreEqual("cba", teamMember.FirstName);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainValidationException), "First name must not be blank or empty")]
        public void TeamMember_FirstNameCannotBeEmpty()
        {
            // assuming valid team member to start with
            var teamMember = new TeamMember(Guid.NewGuid(), "abc", null, "def", "sir", false);

            teamMember.ChangeFirstName("");
        }

        [TestMethod]
        [ExpectedException(typeof(DomainValidationException), "First name must not be blank or empty")]
        public void TeamMember_FirstNameCannotBeNull()
        {
            // assuming valid team member to start with
            var teamMember = new TeamMember(Guid.NewGuid(), "abc", null, "def", "sir", false);

            teamMember.ChangeFirstName(null);
        }

        [TestMethod]
        public void TeamMember_FirstNameCanBe50Characters()
        {
            // assuming valid team member to start with
            var teamMember = new TeamMember(Guid.NewGuid(), "abc", null, "def", "sir", false);

            teamMember.ChangeFirstName("12345678901234567890123456789012345678901234567890");
        }

        [TestMethod]
        [ExpectedException(typeof(DomainValidationException), "First name must be less than 50 characters")]
        public void TeamMember_FirstNameCannotBeGreaterThan50Characters()
        {
            // assuming valid team member to start with
            var teamMember = new TeamMember(Guid.NewGuid(), "abc", null, "def", "sir", false);

            teamMember.ChangeFirstName("12345678901234567890123456789012345678901234567890!");
        }
    }
}
