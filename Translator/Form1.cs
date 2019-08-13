﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Translator {
	public partial class Form1 : Form {

		static string _apiKey = "yandex_api_key_here";

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			this.TopMost = true;
		}

		private void Button1_Click(object sender, EventArgs e) {
			try{
				textBox2.Text = "Перевод...";
				TranslateTextAsync();
			} catch(Exception ex){
				textBox2.Text = "Ошибка перевода";
			}
		}

		private async void TranslateTextAsync(){
			await Task.Run(() => TranslateText());
		}

		private void TranslateText(){
			WebRequest wr = WebRequest.Create($"https://translate.yandex.net/api/v1.5/tr.json/translate?key={_apiKey}&text={textBox1.Text}&lang={textBox3.Text}");
			WebResponse response = wr.GetResponse();
			using (Stream stream = response.GetResponseStream()) {
				using (StreamReader reader = new StreamReader(stream)) {
					YandexResponseJson yrj = JsonConvert.DeserializeObject<YandexResponseJson>(reader.ReadToEnd());
					textBox2.Invoke((MethodInvoker)(() => textBox2.Text = yrj.Text[0]));
				}
			}
		}

		private void CheckBox1_CheckedChanged(object sender, EventArgs e) {
			this.TopMost = checkBox1.Checked;
		}

		private void TextBox1_KeyPress(object sender, KeyPressEventArgs e) {
			if(e.KeyChar == Convert.ToChar(Keys.Enter)){
				textBox2.Text = "Перевод...";
				TranslateTextAsync();
			}
		}
	}
}
