using System;
using System.IO;
using System.Xml.Linq;
using FileInforming.Infrastructure;

namespace FileInforming
{
    public class SettingManager : ISettingManager
    {        
        private XDocument xdoc;
                
        public SettingManager()
        {            
            try
            {                
                xdoc = XDocument.Load("Settings.xml");
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }            
            catch (FileNotFoundException ex)
            {                
                throw ex;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        
        public object GetParam(string param)
        {
            object xElement_Value;
            try
            {
                xElement_Value = xdoc.Element("settings").Element(param).Value;
            }
            catch(NullReferenceException ex)
            {                
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return xElement_Value;
        }
    }
}
