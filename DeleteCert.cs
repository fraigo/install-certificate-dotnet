using System;
using System.Security.Cryptography.X509Certificates;

namespace AddCertToRootStore {
    class Program {
        static void Main (string[] args) {
            String file = @"rootCA.pem";
            if (args.Length >0)
            {
                file = args[0];
            }
            X509Store store = new X509Store (StoreName.Root,
                                             StoreLocation.CurrentUser);
            store.Open (OpenFlags.ReadWrite);
            X509Certificate2Collection collection = new X509Certificate2Collection();
            X509Certificate2 cert = new X509Certificate2 (file);
            byte[] encodedCert = cert.GetRawCertData();
            if (store.Certificates.Contains(cert)){
                //Console.WriteLine ("The certificate will be removed");
                try{
					store.Remove (cert);			
				}catch(Exception e){
					Console.Error.WriteLine(e.Message);
					Environment.Exit(1);
					System.Windows.Forms.Application.Exit();
				}
				
            }else{
                //Console.WriteLine ("The certificate is not installed");
            }
            store.Close ();
			Environment.Exit(0);
            System.Windows.Forms.Application.Exit();
        }
    }
}
