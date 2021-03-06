﻿using System;
using System.Linq;
using DevUtils.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.Enum
{
    /// <summary>
    /// EnumExtensions test class
    /// </summary>
    [TestClass]
    public class EnumExtensions
    {
        #region Auxiliar
        /// <summary>
        /// The <c>UserRoleEnum</c> type provides a private enumeration that is
        /// used to test methods in the <c>TestEnumExtensions</c> type.
        /// </summary>
        /// <remarks>
        /// This enumeration is only intended for testing purposes and should
        /// not be used in production code.
        /// </remarks>
        private enum UserRoleEnum
        {
            Admin = 1,
            User = 2
        }

        /// <summary>
        /// The <c>UserTypeEnum</c> type provides a private enumeration that is
        /// used to test methods in the <c>TestEnumExtensions</c> type.
        /// </summary>
        /// <remarks>
        /// This enumeration is only intended for testing purposes and should
        /// not be used in production code.
        /// </remarks>
        private enum UserTypeEnum
        {
            Admin = 1,
            User = 2
        } 
        #endregion

        /// <summary>
        /// Test ToEnum method from enum
        /// </summary>
        [TestMethod]
        public void TestEnumerationIsConvertedToSpecifiedEnumerationType()
        {
            const UserRoleEnum role1 = UserRoleEnum.Admin;
            const UserRoleEnum role2 = UserRoleEnum.User;
            
            var result = role1.ToEnum<UserTypeEnum>();
            Assert.AreEqual(UserTypeEnum.Admin, result, "Error setting enum, expected UserTypeEnum.Admin");

            result = role2.ToEnum<UserTypeEnum>();
            Assert.AreEqual(UserTypeEnum.User, result, "Error setting enum, expected UserTypeEnum.User");
        }

        /// <summary>
        /// Test ToEnum method from string
        /// </summary>
        [TestMethod]
        public void TestStringIsProperlyConvertedToEnumType()
        {
            const string value = "Friday";
            object result = value.ToEnum<DayOfWeek>();

            Assert.IsInstanceOfType(result, typeof(DayOfWeek), "Invalid instance type");
            Assert.AreEqual(DayOfWeek.Friday, result, "Error converting string to Enum");
        }

        /// <summary>
        /// Test ToEnum method from string
        /// </summary>
        [TestMethod]
        public void TestStringIsNotConvertedToEnumTypeWhenStringIsNull()
        {
            const string value = null;
            object result = value.ToEnum<DayOfWeek>();

            Assert.IsInstanceOfType(result, typeof(DayOfWeek), "Invalid instance type");
            Assert.AreEqual(DayOfWeek.Sunday, result, "Error converting string to Enum");
        }

        /// <summary>
        /// Test ToEnum method from int
        /// </summary>
        [TestMethod]
        public void Test32BitIntegerValueIsConvertedToEnumerationType()
        {
            const int role1 = 1;
            const int role2 = 2;

            var result = role1.ToEnum<UserTypeEnum>();
            Assert.AreEqual(UserTypeEnum.Admin, result, "Error setting enum, expected UserTypeEnum.Admin");

            result = role2.ToEnum<UserTypeEnum>();
            Assert.AreEqual(UserTypeEnum.User, result, "Error setting enum, expected UserTypeEnum.User");
        }

        /// <summary>
        /// Test FromEnumToInt method
        /// </summary>
        [TestMethod]
        public void TestEnumerationIsConvertedTo32BitIntegerType()
        {
            const UserRoleEnum role1 = UserRoleEnum.Admin;
            const UserRoleEnum role2 = UserRoleEnum.User;
            
            var result = role1.FromEnumToInt();
            Assert.AreEqual(1, result, "Error getting enum value, expected 1");

            result = role2.FromEnumToInt();
            Assert.AreEqual(2, result, "Error getting enum value, expected 2");
        }

        /// <summary>
        /// Test FromEnumToString method
        /// </summary>
        [TestMethod]
        public void TestEnumerationIsConvertedToStringValue()
        {
            const UserRoleEnum role1 = UserRoleEnum.Admin;
            const UserRoleEnum role2 = UserRoleEnum.User;
            
            var result = role1.FromEnumToString();
            Assert.AreEqual("1", result, "Error getting enum value, expected 1");

            result = role2.FromEnumToString();
            Assert.AreEqual("2", result, "Error getting enum value, expected 2");
        }

        /// <summary>
        /// Test FromEnum method
        /// </summary>
        [TestMethod]
        public void TestConvertEnumToIList()
        {
            var value1 = new UserRoleEnum().FromEnum();
            var value2 = UserRoleEnum.User.FromEnum();
            Assert.AreEqual(string.Join(",", value1), string.Join(",", value2), "Error getting list from enum, expected same");

            var count = ((UserRoleEnum[]) System.Enum.GetValues(typeof (UserRoleEnum))).Count();
            Assert.AreEqual(count, value1.Count, "Error getting list from enum, expected same");
        }
    }
}
