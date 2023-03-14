using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VisualNovelKP.Resouces;

namespace VisualNovelKP.Model
{
    public static class CardGenerator
    {
        private static Random random = new Random();

        public static Label? DebugLabel;

        public static List<Image> GenerateListOfUniqueCardExceptRed(int count)
        {
           

            List<Image> list = new List<Image>(count);
            List<(int page, int row, int column)> adresses = new(count);

            for (int i = 0; i < count; i++)
            {
                (int page, int row, int column) adress;

                do
                    adress = (random.Next(3, 43), random.Next(1, 4), random.Next(1, 4));
                while (IsRed(adress) || adresses.Contains(adress));

                adresses.Add(adress);
            }

            #region Debug
            //var a = (List<(int page, int row, int column)> adresses) =>
            //{
            //    var result = "";
            //    foreach (var adress in adresses)
            //        result += $"({adress.page}, {adress.row}, {adress.column})\n";
            //    return result;
            //};
            //label.Text = a(adresses);
            #endregion

            for (int i = 0; i < count; i++)
                list.Add(CardsResouces.ResourceManager.GetObject(string.Format("Page{0}_row_{1}_column_{2}", adresses[i].page, adresses[i].row, adresses[i].column)) as Image);
            return list;
        }

        private static bool IsRed((int page, int row, int column) adress) => 
            adress.row == 3 && adress.column == 1 && (adress.page != 22 || adress.page != 27 || adress.page != 29 || adress.page <= 32) ||
            adress.row == 1 && adress.column == 3 && adress.page > 32;
    }
}
