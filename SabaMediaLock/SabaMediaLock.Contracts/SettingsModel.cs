using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SabaMediaLock.Contracts
{
    [Serializable]
    public enum SkinKind { Default, Flash }

    [Serializable]
    public enum FormType 
    {
        ActivationSucceeded, ActivationFailed, SmsActivation, InternetActivation, ActivationType, EnablingSoftware
    }

    [Serializable]
    public enum ItemType { Button, RadioButton, Form, Text};

    [Serializable]
   public  class SettingsModel
    {
        /// <summary>
        /// Some random fake bytes for encryption
        /// </summary>
        public byte[] AAA { get; set; }

        public bool UseDefaultWizard { get; set; }
        public string ServiceAddress { get; set; }
        public string MediaFilePath { get; set; }
        public string SoftwareName { get; set; }
        public int SerialLen { get; set; }
        public string Password { get; set; }
        public string Theme { get; set; }
        public string SoftwareUniqueName { get; set; }
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }
        public bool Encrypted { get; set; }
        public bool EncryptedResource { get; set; }
        public bool UseDefaultWindowButtons { get; set; }
        public SkinKind SkinKind { get; set; }       

       public List<DefaultFormSetting> DefaultFormsSettings { get; set; }
       public List<FlashFormSetting> FlashFormsSettings { get; set; }
    }

    [Serializable]
    public class FormItem
    {
        public string ItemName { get; set; }
        public string PropertyName {get;set;}
        public string PropertyValue {get;set;}
        public ItemType ItemType { get;set;}
    }

    [Serializable]
    public class FormSetting
    {
        public FormType FormType { get; set; }
    }

    [Serializable]
    public class DefaultFormSetting : FormSetting
    {
        public List<FormItem> Items{get;set;}
    }

    [Serializable]
    public class FlashFormSetting : FormSetting
    {
        public string FilePath { get; set; }
    }
}
