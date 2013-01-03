using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExtSurat.BusinessObjects;
using System.Collections.ObjectModel;
using System.Text;

namespace ExtSurat
{
    public class SuratAutonumber
    {
        public string GenNumber(string numberingId,int month,int year)
        {
            string autonumber = string.Empty;
            string batas = string.Empty;
            NomorQuery nQ = new NomorQuery("a");
            NomorCollection nC = new NomorCollection();
            nQ.SelectAll()
                .Where(nQ.Format == numberingId);
            nQ.es.Top = 1;
            if (nC.Load(nQ))
            {
                if (nC.Count >= 1)
                {
                    foreach (Nomor n in nC)
                    {                          
                        string[] formatNumbering;
                        formatNumbering = new string[7];
                        for (int i = 1; i <= 6; i++)
                        {
                            batas = n.Batas.Trim();
                            string[] nomors = n.Nomor.Split(',');
                            string nomor = string.Empty;
                            int inomor = 0;
                            int Length = 0;
                            if (nomors[0].ToString().Trim() == i.ToString().Trim())
                            {
                                nomor = nomors[1].ToString().Trim();                                
                                Length = nomor.Length;
                                if (!int.TryParse(nomor, out inomor))
                                {
                                    inomor = 0;                                    
                                }
                                inomor++;
                                nomor = inomor.ToString().Trim();
                                for (int x = nomor.Length; x < Length; x++)
                                    nomor = "0" + nomor;
                                Nomor nmr = new Nomor();
                                if (nmr.LoadByPrimaryKey((int)n.Nomorid))
                                {
                                    nmr.Nomor = nmr.Nomor.Trim().Substring(0, 2) + nomor.Trim();
                                    nmr.Save();
                                    formatNumbering[i] = nomor;
                                }
                                continue;
                            }

                            string[] organisasis = n.Organisasi.Split(',');
                            string organisasi = string.Empty;
                            if (organisasis[0].ToString().Trim() == i.ToString().Trim())
                            {
                                organisasi = organisasis[1].ToString().Trim();
                                formatNumbering[i] = organisasi;
                                continue;
                            }

                            string[] bagians = n.Bagian.Split(',');
                            string bagian = string.Empty;
                            if (bagians[0].ToString().Trim() == i.ToString().Trim())
                            {
                                bagian = bagians[1].ToString().Trim();
                                formatNumbering[i] = bagian;
                                continue;
                            }

                            string[] subbagians = n.Subagian.Split(',');
                            string subbagian = string.Empty;
                            if (subbagians[0].ToString().Trim() == i.ToString().Trim())
                            {
                                subbagian = subbagians[1].ToString().Trim();
                                formatNumbering[i] = subbagian;
                                continue;
                            }

                            string[] bulans = n.Bulan.Split(',');
                            string bulan = string.Empty;
                            if (bulans[0].ToString().Trim() == i.ToString().Trim())
                            {
                                bulan = bulans[1].ToString().Trim();
                                formatNumbering[i] = FromNumberToRoman(month);
                            }

                            string[] tahuns = n.Tahun.Split(',');
                            string tahun = string.Empty;
                            if (tahuns[0].ToString().Trim() == i.ToString().Trim())
                            {
                                tahun = tahuns[1].ToString().Trim();
                                formatNumbering[i] = tahun;
                            }
                        }
                        for (int j = 1; j < formatNumbering.Length; j++)
                        {
                            if (string.IsNullOrEmpty(formatNumbering[j]))
                                continue;                            
                            autonumber = autonumber + formatNumbering[j] + batas;
                        }
                        if (autonumber.Substring(autonumber.Length - 1, 1).Trim() == batas)
                        {
                            autonumber = autonumber.Substring(0, autonumber.Length - 1);
                        }
                    }
                    return autonumber;
                }
                else
                    return "e";                
            }
            else
                return "e";
        }

        static Tuple<IList<Tuple<string, int>>, int> GenerateBaseNumbers()
        {
            const string letters = "IVXLCDM";

            var tuples = new List<Tuple<string, int>>();
            Tuple<string, int> subtractor = null;

            int num = 1;
            int maxNumber = 0;

            for (int i = 0; i < letters.Length; i++)
            {
                string currentLetter = letters[i].ToString();

                if (subtractor != null)
                {
                    tuples.Add(Tuple.Create(subtractor.Item1 + currentLetter, num - subtractor.Item2));
                }

                tuples.Add(Tuple.Create(currentLetter, num));

                bool isEven = i % 2 == 0;

                if (isEven)
                {
                    subtractor = tuples[tuples.Count - 1];
                }

                maxNumber += isEven ? num * 3 : num;
                num *= isEven ? 5 : 2;
            }

            return Tuple.Create((IList<Tuple<string, int>>)new ReadOnlyCollection<Tuple<string, int>>(tuples), maxNumber);
        }

        static readonly Tuple<IList<Tuple<string, int>>, int> RomanBaseNumbers = GenerateBaseNumbers();

        static string FromNumberToRoman(int num)
        {
            if (num <= 0 || num > RomanBaseNumbers.Item2)
            {
                throw new ArgumentOutOfRangeException();
            }

            StringBuilder sb = new StringBuilder();

            int i = RomanBaseNumbers.Item1.Count - 1;

            while (i >= 0)
            {
                var current = RomanBaseNumbers.Item1[i];

                if (num >= current.Item2)
                {
                    sb.Append(current.Item1);
                    num -= current.Item2;
                }
                else
                {
                    i--;
                }
            }

            return sb.ToString();
        }
    }
}