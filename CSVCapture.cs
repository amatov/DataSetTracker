using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVCapture : MonoBehaviour {


	public string CSVFile = "";
	private int icounter = 1;
	public bool bCaptureData = false;


	// Use this for initialization
	public void RestartCSV () {
		icounter = 1;
		CSVFile = "";
		bCaptureData = true;

	}

	//private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
	//{
	//	if (e.Cancelled || e.Error != null) {
	//		print ("Email not sent: " + e.Error.ToString ());
	//	} else {
	//		print ("Email successfully sent.");
	//	}
	//}

	public void AddLine2CSV(string newString){

		if (bCaptureData == false) {
			return;
		}


		if (icounter > 600) {
			//send email from here

			//string SimpleEmailSender.STMPClient = "stmp.gmail.com";
			//int SimpleEmailSender.SMTPPort = 587;
			//string SimpleEmailSender.UserName = "datasetanalysis";
			//string UserPass = "password" ;

			//if aux == 0 {
				SimpleEmailSender.emailSettings.STMPClient = "stmp.gmail.com";
				SimpleEmailSender.emailSettings.SMTPPort = 587;
				SimpleEmailSender.emailSettings.UserName = "datasetanalysis";
				SimpleEmailSender.emailSettings.UserPass = "password" ;
				Debug.Log (SimpleEmailSender.emailSettings.UserName);

				SimpleEmailSender.Send("alexandre.matov@gmail.com", "movie# (mean speed, std) = ", CSVFile, "");	
				//Debug.Log ("just sent test email);



			return;
		}

		if (newString != "0") { 
			CSVFile = CSVFile + "\n" + icounter + " " + newString; // This way we dont guarantee 600 values as if there are many 0s there will be less than 600 meaningful values
			icounter++;

			Debug.Log (CSVFile);
		}
	}

	public void GetCSVData(){


			//mail.From = new MailAddress("datasetanalysis@gmail.com\t");
			//mail.To.Add("alexandre.matov@gmail.com");

			//SmtpClient smtpServer = new SmtpClient("stmp.google.com");
			//smtpServer.Port = 587;//993;//GIVE CORRECT PORT HERE
			//mail.Subject = "test unity email";
			//mail.Body = "testing another method to send an email";
			//smtpServer.Credentials = new System.Net.NetworkCredential("stmp.google.com", "password") as ICredentialsByHost;
			//smtpServer.EnableSsl = true;
			//ServicePointManager.ServerCertificateValidationCallback =
			//	delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
			//{ return true; };
			//smtpServer.Send(mail);
			//smtpServer.SendAsync(mail)
			//Debug.Log("success");
		 
		//Debug.Log ("send email");
		//string email = "alexandre.matov@gmail.com";
		//string subject = MyEscapeURL("600 EB1 speeds");
		//string body = MyEscapeURL("This email contains 600 readout points of EB1 speeds of motion");
		//string attachment = CSVFile;
		//Debug.Log("attachment : " + attachment);
		//Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body + "&attachment=" + attachment);
		//use this function to get stuff ready for email

	}

}
