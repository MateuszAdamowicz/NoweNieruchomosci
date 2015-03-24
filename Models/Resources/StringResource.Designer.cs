﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StringResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Models.Resources.StringResource", typeof(StringResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Adres email nie jest prawidłowy..
        /// </summary>
        internal static string EmailNotValid {
            get {
                return ResourceManager.GetString("EmailNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Adres email jest wymagany..
        /// </summary>
        internal static string EmailRequired {
            get {
                return ResourceManager.GetString("EmailRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Prawidłowe formaty dla szerokości geograficznej to 50 , 50,90 lub 50.90.
        /// </summary>
        internal static string LatNotValid {
            get {
                return ResourceManager.GetString("LatNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Prawidłowe formaty dla długości geograficznej to 15, 15,72 lub 15.72.
        /// </summary>
        internal static string LngNotValid {
            get {
                return ResourceManager.GetString("LngNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Maksymalna długość dla pola {0} to {1} znaków..
        /// </summary>
        internal static string MaxLength {
            get {
                return ResourceManager.GetString("MaxLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Maksymalna długość dla tego pola to {1} znaków..
        /// </summary>
        internal static string MaxLengthProperties {
            get {
                return ResourceManager.GetString("MaxLengthProperties", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} powinna znajdować się w zakresie od {1} do {2} ..
        /// </summary>
        internal static string MaxRange {
            get {
                return ResourceManager.GetString("MaxRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Numer telefonu nie jest poprawny. Poprawny numer składa się z 6-18 cyfr.
        /// </summary>
        internal static string PhoneNotValid {
            get {
                return ResourceManager.GetString("PhoneNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Numer telefonu jest wymagany..
        /// </summary>
        internal static string PhoneNumberRequired {
            get {
                return ResourceManager.GetString("PhoneNumberRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cena powinna składać się z maksymalnie 7 cyfr..
        /// </summary>
        internal static string PriceNotValid {
            get {
                return ResourceManager.GetString("PriceNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pole {0} jest wymagane..
        /// </summary>
        internal static string Required {
            get {
                return ResourceManager.GetString("Required", resourceCulture);
            }
        }
    }
}