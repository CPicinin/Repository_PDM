using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDM.View
{
    public partial class Config : System.Web.UI.Page
    {
        public static string arquivoTxt = @"C:\Users\Gestao_02\Source\Repos\Repository_PDM2\PDM\PDM.View\template\img\db.txt";
        protected void Page_Init(object sender, EventArgs e)
        {
            string[] lineV = new string[5];
            string line;
            int i = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(arquivoTxt);
            while ((line = file.ReadLine()) != null)
            {
                lineV[i] = line;
                i++;
            }
            file.Close();
            txtServidor.Text = lineV[0];
            txtInstancia.Text = lineV[1];
            txtUsuario.Text = lineV[2];
            txtSenha.Text = lineV[3];
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string[] lineV = new string[5];
            
            lineV[0] = txtServidor.Text;
            lineV[1] = txtInstancia.Text;
            lineV[2] = txtUsuario.Text;
            lineV[3] = txtSenha.Text;
            System.IO.File.WriteAllLines(arquivoTxt, lineV);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}
        /*string[] lines = { "First line", "Second line", "Third line" };
        // WriteAllLines creates a file, writes a collection of strings to the file,
        // and then closes the file.  You do NOT need to call Flush() or Close().
        System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);


        // Example #2: Write one string to a text file.
        string text = "A class is the most powerful data type in C#. Like a structure, " +
                       "a class defines the data and behavior of the data type. ";
        // WriteAllText creates a file, writes the specified string to the file,
        // and then closes the file.    You do NOT need to call Flush() or Close().
        System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText.txt", text);

        // Example #3: Write only some strings in an array to a file.
        // The using statement automatically flushes AND CLOSES the stream and calls 
        // IDisposable.Dispose on the stream object.
        // NOTE: do not use FileStream for text files because it writes bytes, but StreamWriter
        // encodes the output as text.
        using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
        {
            foreach (string line in lines)
            {
                // If the line doesn't contain the word 'Second', write the line to the file.
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
            }
        }

        // Example #4: Append new text to an existing file.
        // The using statement automatically flushes AND CLOSES the stream and calls 
        // IDisposable.Dispose on the stream object.
        using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt", true))
        {
            file.WriteLine("Fourth line");
        }*/