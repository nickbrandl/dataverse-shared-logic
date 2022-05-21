using Dataverse.Shared.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System;

namespace UnitTests
{
	[TestClass]
	public class SdkExtensionsTests
	{
		[TestMethod]
		public void EntityReference_Equals_BothNull_Valid()
		{
			EntityReference sourceNull = null, targetNull = null;

			Assert.IsTrue(sourceNull.CustomEquals(targetNull));
		}

		[TestMethod]
		public void EntityReference_Equals_NotNull_Valid()
		{
			var sourceNotNull = new EntityReference("account", new Guid("a2caa1ca-794c-4702-8fb2-1436d35f422a"));
			var targetDifferentType = new EntityReference("contact", new Guid("a2caa1ca-794c-4702-8fb2-1436d35f422a"));
			var targetDifferentId = new EntityReference("contact", new Guid("318ce11e-9f89-4d7e-bb62-cfafa35dbf40"));

			Assert.IsFalse(sourceNotNull.CustomEquals(targetDifferentType));
			Assert.IsFalse(sourceNotNull.CustomEquals(targetDifferentId));
		}

		[TestMethod]
		public void EntityReference_Equals_Mixed_Valid()
		{
			EntityReference sourceNull = null, targetNotNull = new EntityReference("account", new Guid("a2caa1ca-794c-4702-8fb2-1436d35f422a"));

			Assert.IsFalse(sourceNull.CustomEquals(targetNotNull));
		}

		[TestMethod]
		public void OptionSetValue_Equals_BothNull_Valid()
		{
			OptionSetValue sourceNull = null, targetNull = null;

			Assert.IsTrue(sourceNull.CustomEquals(targetNull));
		}

		[TestMethod]
		public void OptionSetValue_Equals_NotNull_Valid()
		{
			var sourceNotNull = new OptionSetValue(1);
			var targetNotNull = new OptionSetValue(2);

			Assert.IsFalse(sourceNotNull.CustomEquals(targetNotNull));
		}

		[TestMethod]
		public void OptionSetValue_Equals_Mixed_Valid()
		{
			OptionSetValue sourceNull = null, targetNotNull = new OptionSetValue(1);

			Assert.IsFalse(sourceNull.CustomEquals(targetNotNull));
		}
	}
}
