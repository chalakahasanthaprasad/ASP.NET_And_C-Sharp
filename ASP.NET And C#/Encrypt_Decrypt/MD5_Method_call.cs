
protected void Page_Load(object sender, EventArgs e)
        
		
		
		//This is ASP.NET CODE
		{
            try
            {
                Encrypt_Decrypt en = new Encrypt_Decrypt();
                string EncryptText = en.EncryptString("PassW0rD");
				//This is C# CODE
                Console.WriteLine("MD5 Encrypted : " + EncryptText);
                Console.WriteLine("MD5 Decrypted : " + en.DecryptString(EncryptText));
				
				//This is ASP.NET CODE
                Response.Write("MD5 Encrypted : " + EncryptText);
                Response.Write("MD5 Decrypted : " + en.DecryptString(EncryptText));
            }
            catch (Exception ex)
            {
				//This is C# CODE
                Console.WriteLine(ex.ToString());
				
				//This is ASP.NET CODE
                Response.Write(ex.ToString());
            }


			