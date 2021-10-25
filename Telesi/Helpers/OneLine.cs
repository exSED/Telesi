using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telesi.Types;
using Telesi.Helpers;

namespace Telesi.Helpers
{
    class OneLine{
        private DataLength dl = new DataLength();
        private AllPaths ap = new AllPaths();
        public string oneLine(string path_){
            if (File.Exists(path_)){
                string refe = String.Empty;
                string[] dataInventory = File.ReadAllLines(path_);
                if (dataInventory.Length != 0 && dataInventory[0]!=String.Empty){
                    for (int i = 0; i < dataInventory.Length ; i++)
                    {
                        refe += dataInventory[i] + "\n";
                    }
                    return refe;
                }else{
                    return null;
                }
            }else{
                MessageBox.Show("El vacio es inexistencia");
                return null;
            }
        }
        public string NewInv(string path_, string what){
            if (File.Exists(path_)){
                string refe = String.Empty;
                string[] dataInventor = File.ReadAllLines(path_);
                List<string> dataInventory = new List<string>();
                if (dataInventor.Length != 0 && dataInventor[0] != String.Empty)
                {
                    for (int i = 0; i < dataInventor.Length; i++)
                    {
                        dataInventory.Add(dataInventor[i]);
                    }
                    dataInventory.Remove(what);
                    if (dataInventory.Count > 0)
                    {
                        for (int i = 0; i < dataInventory.Count - 1; i++)
                        {
                            refe += dataInventory[i] + "\n";
                        }
                        refe += dataInventory[dataInventory.Count - 1];
                        return refe;
                    }else{
                        return null;
                    }
                }else{
                    return null;
                }

            }else{
                MessageBox.Show("El vacio es inexistencia");
                return null;
            }
        }
        public string NewPro(string path_, string what, string par, int  index_)
        {
            if (File.Exists(path_))
            {
                string refe = String.Empty;
                string[] dataInventor = File.ReadAllLines(path_);
                List<string> dataInventory = new List<string>();
                if (dataInventor.Length != 0 && dataInventor[0] != String.Empty)
                {
                    for (int i = 0; i < dataInventor.Length; i++)
                    {
                        dataInventory.Add(dataInventor[i]);
                    }
                    dataInventory.Insert(index_, par);
                    dataInventory.Remove(what);
                    if (dataInventory.Count > 0)
                    {
                        for (int i = 0; i < dataInventory.Count - 1; i++)
                        {
                            refe += dataInventory[i] + "\n";
                        }
                        refe += dataInventory[dataInventory.Count - 1];
                        return refe;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            else
            {
                MessageBox.Show("El vacio es inexistencia");
                return null;
            }
        }
        public string newPorsIvo_(List<Products> PL)
        {
            string dr = "";
            for (int i= 0; i < PL.Count-1 ;i++)
            {
                dr += PL[i].id_ + "-" + PL[i].name_ + "-" + PL[i].count_ + "-" + PL[i].price_ + "|";
            }
            dr += PL[PL.Count-1].id_ + "-" + PL[PL.Count-1].name_ + "-" + PL[PL.Count-1].count_ + "-" + PL[PL.Count-1].price_;
            return dr;
        }
        public string newInven_(List<Products> PL)
        {
            string dr = "";
            for (int i = 0; i < PL.Count - 1; i++)
            {
                dr += PL[i].id_ + "\t" + PL[i].name_ + "\t" + PL[i].count_ + "\t" + PL[i].price_ + "\r\n";
            }
            dr += PL[PL.Count-1].id_ + "\t" + PL[PL.Count-1].name_ + "\t" + PL[PL.Count-1].count_ + "\t" + PL[PL.Count-1].price_;
            return dr;
        }
        public string sobrInvo_(List<Invoice> PL)
        {
            string dr = "";
            for (int i = 0; i < PL.Count - 1; i++)
            {
                dr += PL[i].number_ + "\t" + PL[i].date_ + "\t" + PL[i].total_ + "\r\n";
            }
            dr += PL[PL.Count - 1].number_ + "\t" + PL[PL.Count - 1].date_+ "\t" + PL[PL.Count - 1].total_;
            return dr;
        }
    }
}