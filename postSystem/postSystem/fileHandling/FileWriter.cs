using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace postSystem.fileHandling;
public class FileWriter
{
    /// <summary>
    /// Writes and saves a document locally, if the user has chosen this through SaveStatus
    /// </summary>
    /// <param name="itemList"></param>
    /// <param name="sum"></param>
    public static void WriteFile(List<string[]> itemList, List<float> sum)
    {
        bool saveFile = SaveStatus.Save();

        if (saveFile)
        {
            // Give the file a name (sets name to New_File if no name is given)
            Console.WriteLine("\nGive your document a name:");
            string name = Regex.Replace(Console.ReadLine(), "[^a-zA-ZæøåÆØÅ0-9]", "");
            if (name == "")
            {
                name = "New_File";
            }
            
            // Setting filenames and path
            string fileName = name + ".pdf";
            string logoFile = "images/Logo.png";
            string signatureFile = "images/Signature.png";
            string sealFile = "images/Seal.png";

            // Creating and opening a new file to be written
            Document shippingList = new Document();
            PdfWriter.GetInstance(shippingList, new FileStream(fileName, FileMode.Create));

            shippingList.Open();

            // Readying images and setting their position
            Image logo = Image.GetInstance(logoFile);
            logo.SetAbsolutePosition(200, 730);
            logo.ScaleToFit(200, 200);

            Image seal = Image.GetInstance(sealFile);
            seal.SetAbsolutePosition(350, 50);
            seal.ScaleToFit(200, 200);

            Image signature = Image.GetInstance(signatureFile);
            signature.ScaleToFit(200, 200);

            // Adding text with some adjustment parameters for style and placement
            Paragraph introText = new Paragraph("\n\n\n\nThank you for choosing the I&B-Turbo™ Postal services\n" +
                                                "Please review your order below.\n\n\n\n");
            introText.Alignment = Element.ALIGN_CENTER;

            Font bold = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);
            Paragraph paragraph = new Paragraph(new Phrase("     " +
                                                           "I&B has registered the following items for shipping:\n\n", bold));

            Paragraph legalInfo = new Paragraph("\n\n\n\nPlease note that all items are shipped at your own risk!\n" +
                                                "I&B will not be held accountable if any or all items in this shipment\n" +
                                                "is either lost or damaged during transport.\n" +
                                                "\n" +
                                                "If you have further questions, you may contact us at:\n" +
                                                "service@ibturbo.com\n");

            // Creating the table that is going to hold the shiping data
            PdfPTable table = new PdfPTable(6);
            table.AddCell(new PdfPCell(new Phrase("Item", bold)));
            table.AddCell(new PdfPCell(new Phrase("Weight (g)", bold)));
            table.AddCell(new PdfPCell(new Phrase("Package type", bold)));
            table.AddCell(new PdfPCell(new Phrase("Package price (kr)", bold)));
            table.AddCell(new PdfPCell(new Phrase("Postage type", bold)));
            table.AddCell(new PdfPCell(new Phrase("Postage Price (kr)", bold)));

            // Inserting the shipping data into the table
            foreach (string[] strings in itemList)
            {
                foreach (string s in strings)
                {
                    table.AddCell(s);
                }
            }

            // Adding the sums from SumCalculator
            Paragraph total = new Paragraph($"\nQuantity of items: {sum[0]}                " +
                                            $"Total weight: {sum[1]} g              " +
                                            $"Total price: {sum[2]},-");
            total.Alignment = Element.ALIGN_CENTER;

            // Adding everything to the document in the correct order
            shippingList.Add(logo);
            shippingList.Add(seal);
            shippingList.Add(introText);
            shippingList.Add(paragraph);
            shippingList.Add(table);
            shippingList.Add(total);
            shippingList.Add(new Chunk(new LineSeparator()));
            shippingList.Add(legalInfo);
            shippingList.Add(signature);
            shippingList.Close();

            // Writes notification to user
            Console.WriteLine($"Your document was saved as: {fileName}\n" +
                              $"Save location: {Path.GetFullPath(fileName)}");
        }
    }
}