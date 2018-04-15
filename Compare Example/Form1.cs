using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compare_Example.Annotations;

namespace Compare_Example
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private async void CompareButton_Click(object sender, EventArgs e)
		{
			var result = await Compare(richTextBoxLeft.Text, richTextBoxRight.Text);

			ResultTextBox.Text = ((int)(result * 100)).ToString(CultureInfo.InvariantCulture) + @"%";
		}

		private async void FindDuplicatesButton_Click(object sender, EventArgs e)
		{
			if( !double.TryParse(ThresholdTextBox.Text, out var parseResult)) return;

			var result = await FindDuplicates(richTextBoxLeft.Text, parseResult);

			richTextBoxRight.Text = result;
		}

		/// <summary>
		/// Compare two strings
		/// </summary>
		/// <param name="str1">First string</param>
		/// <param name="str2">Second string</param>
		/// <returns> Similarity in range from 0 to 1 </returns>
		private static async Task<double> Compare(string str1, string str2)
		{
			return await Task.Run(() => StringsComparison.CompareStrings(str1, str2));
		}

		/// <summary>
		/// Searching for duplicates in string. Indicate duplicates according to given threshold.
		/// </summary>
		/// <param name="str">String of values separated by \n or \r or \r\n</param>
		/// <param name="threshold">Threshold</param>
		/// <returns> String of duplicates in format of Dup1~Dup2 separated by NewLine</returns>
		private static async Task<string> FindDuplicates([NotNull]string str, double threshold)
		{
			return await Task.Run(() =>
			{
				if (string.IsNullOrEmpty(str)) return "";

				var result = new Dictionary<string, List<string>>();
				var lines = str.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

				foreach (var line1 in lines)
				{
					foreach (var line2 in lines)
					{
						if (line1 == line2) continue;

						if (StringsComparison.CompareStrings(line1, line2) < threshold) continue;

						if (result.TryGetValue(line2, out var list))
							list.Add(line1);
						else
							result.Add(line2, new List<string> {line1});
					}
				}

				return result.Aggregate(new StringBuilder(),
					(rslt, item) => rslt.AppendFormat("{0}{1}~{2}", rslt.Length > 0 ? "\n" : "", item.Key, string.Join(";", item.Value)),
					rslt => rslt.ToString());
			});
		}
	}
}
