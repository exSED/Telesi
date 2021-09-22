using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesi.Helpers
{
    class OneLine{
        private DataLength dl = new DataLength();
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
    }
}
