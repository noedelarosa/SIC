using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

namespace Empresa.Comun.Validacion{

    public class HdError: IDataErrorInfo  // Handle Error
    {
        public Dictionary<string, string> DicErrors = new Dictionary<string, string>();

        public bool IsValid() { if (DicErrors.Count > 0) { return false; } return true; }

        public void BorrarError(string llv){
            DicErrors.Remove(llv);
        }

        public void AgregoError(string llv, string msj){
            if (!DicErrors.ContainsKey(llv)){
                DicErrors.Add(llv, msj);
            }
        }

        public string Error{
            get {
                if (!DicErrors.Count.Equals(0)){
                    var e = this.DicErrors.GetEnumerator();
                    
                    e.MoveNext();
                    return e.Current.Value;
                }
                else {
                    return null;
                }
            }
        }

        public string this[string columnName]{
            get{
                if (DicErrors.ContainsKey(columnName))
                {
                    return DicErrors[columnName];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
