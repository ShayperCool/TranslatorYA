using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator {
	class YandexResponseJson {
		public int Code { get; set; }
		public string Lang{ get; set; }
		public string[] Text{ get; set; }
	}
}
