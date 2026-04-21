using System;
using System.Collections.Generic;
using System.Text;

namespace Savables
{
	public interface ISavable
	{
		string Name { get; }
		public void Save();
	}
}
