using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dataverse.Shared.Extensions
{
	public static class SdkExtensions
	{
		/// <summary>
		/// Use this method to compare whether two EntityReference instances are equal
		/// </summary>
		/// <remarks>If both references are null or if both objects' Id and LogicalName properties are equals, this method returns true.</remarks>
		/// <param name="source"></param>
		/// <param name="target"></param>
		/// <returns>A Boolean indicating whether both objects are equal.</returns>
		public static bool CustomEquals(this EntityReference source, EntityReference target)
		{
			if ((source == null && target == null) ||
				 (source != null && target != null && source.Id == target.Id && source.LogicalName == target.LogicalName))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Use this method to compare whether two OptionSetValue instances are equal
		/// </summary>
		/// <remarks>If both references are null returns true or if the property Value of both objects are equal, this method returns true.</remarks>
		/// <param name="source"></param>
		/// <param name="target"></param>
		/// <returns>A Boolean indicating whether both objects are equal.</returns>
		public static bool CustomEquals(this OptionSetValue source, OptionSetValue target)
		{
			if ((source == null && target == null) ||
				 (source != null && target != null && source.Value == target.Value))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
