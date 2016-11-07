﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Food.Server {
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
    internal class Sql {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Sql() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Food.Server.Sql", typeof(Sql).Assembly);
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
        ///   Looks up a localized string similar to SELECT * FROM app.dish;.
        /// </summary>
        internal static string AllDishes {
            get {
                return ResourceManager.GetString("AllDishes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM app.dish_ingredient;.
        /// </summary>
        internal static string AllDishIngredients {
            get {
                return ResourceManager.GetString("AllDishIngredients", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM app.ingredient;.
        /// </summary>
        internal static string AllIngredients {
            get {
                return ResourceManager.GetString("AllIngredients", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM app.recipe;.
        /// </summary>
        internal static string AllRecipes {
            get {
                return ResourceManager.GetString("AllRecipes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM app.dish WHERE Id=@Id.
        /// </summary>
        internal static string DeleteDish {
            get {
                return ResourceManager.GetString("DeleteDish", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM app.dish_ingredient WHERE Id=@Id.
        /// </summary>
        internal static string DeleteDishIngredient {
            get {
                return ResourceManager.GetString("DeleteDishIngredient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM app.ingredient WHERE Id=@Id.
        /// </summary>
        internal static string DeleteIngredient {
            get {
                return ResourceManager.GetString("DeleteIngredient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM app.recipe WHERE Id=@Id.
        /// </summary>
        internal static string DeleteRecipe {
            get {
                return ResourceManager.GetString("DeleteRecipe", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM app.dish i WHERE i.id=@id;.
        /// </summary>
        internal static string FindDish {
            get {
                return ResourceManager.GetString("FindDish", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM app.dish_ingredient i WHERE i.id=@id;.
        /// </summary>
        internal static string FindDishIngredient {
            get {
                return ResourceManager.GetString("FindDishIngredient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM app.ingredient i WHERE i.id=@id;.
        /// </summary>
        internal static string FindIngredient {
            get {
                return ResourceManager.GetString("FindIngredient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM app.recipe i WHERE i.id=@id;.
        /// </summary>
        internal static string FindRecipe {
            get {
                return ResourceManager.GetString("FindRecipe", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO app.dish
        ///(Id, Name, Description) 
        ///VALUES (@Id, @Name, @Description).
        /// </summary>
        internal static string InsertDish {
            get {
                return ResourceManager.GetString("InsertDish", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO app.dish_ingredient
        ///(Id, Amount, Unit, Ingredient_id_fk, Dish_id_fk) 
        ///VALUES (@Id, @Amount, @Unit, @Ingredient_id_fk, @Dish_id_fk).
        /// </summary>
        internal static string InsertDishIngredient {
            get {
                return ResourceManager.GetString("InsertDishIngredient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO app.ingredient
        ///(Id, Name, Description) 
        ///VALUES (@Id, @Name, @Description).
        /// </summary>
        internal static string InsertIngredient {
            get {
                return ResourceManager.GetString("InsertIngredient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO app.recipe
        ///(Id, Dish_id_fk, Description, Description_short, Difficulty, Duration ) 
        ///VALUES (@Id, @DishId, @Description, @DescriptionShort, @Difficulty, @Duration).
        /// </summary>
        internal static string InsertRecipe {
            get {
                return ResourceManager.GetString("InsertRecipe", resourceCulture);
            }
        }
    }
}
