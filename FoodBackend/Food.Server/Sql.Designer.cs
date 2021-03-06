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
        ///   Looks up a localized string similar to SELECT * FROM app.dish d order by d.Name;.
        /// </summary>
        internal static string AllDishes {
            get {
                return ResourceManager.GetString("AllDishes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select d.Id, d.Name, d.Description, d.Difficulty, d.Duration, d.Author, d.TimeAdded 
        ///from app.dish d order by d.Name limit @Limit offset @Offset .
        /// </summary>
        internal static string AllDishesLight {
            get {
                return ResourceManager.GetString("AllDishesLight", resourceCulture);
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
        ///   Looks up a localized string similar to SELECT * FROM app.tag t order by t.Name;.
        /// </summary>
        internal static string AllTags {
            get {
                return ResourceManager.GetString("AllTags", resourceCulture);
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
        ///   Looks up a localized string similar to DELETE FROM app.dish_ingredient WHERE 
        ///Dish_id_fk = @DishId AND
        ///Ingredient_id_fk= @IngredientId.
        /// </summary>
        internal static string DeleteDishIngredient {
            get {
                return ResourceManager.GetString("DeleteDishIngredient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM app.dish_tag WHERE 
        ///Dish_id_fk = @Dish_id_fk AND
        /// Tag_id_fk=@Tag_id_fk.
        /// </summary>
        internal static string DeleteDishTag {
            get {
                return ResourceManager.GetString("DeleteDishTag", resourceCulture);
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
        ///   Looks up a localized string similar to DELETE FROM app.tag WHERE Id=@Id.
        /// </summary>
        internal static string DeleteTag {
            get {
                return ResourceManager.GetString("DeleteTag", resourceCulture);
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
        ///   Looks up a localized string similar to SELECT * FROM app.ingredient i WHERE i.id=@id;.
        /// </summary>
        internal static string FindIngredient {
            get {
                return ResourceManager.GetString("FindIngredient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT i.Id, i.Name, i.Description, di.Amount, di.Unit FROM
        /// app.dish_ingredient di, app.ingredient i 
        /// WHERE di.Ingredient_id_fk = i.Id AND
        ///di.Dish_id_fk = @Id order by i.Name;
        ///.
        /// </summary>
        internal static string FindIngredientForDish {
            get {
                return ResourceManager.GetString("FindIngredientForDish", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM app.tag i WHERE i.id=@id;.
        /// </summary>
        internal static string FindTag {
            get {
                return ResourceManager.GetString("FindTag", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT t.Id, t.Name 
        ///FROM app.tag t, app.dish_tag dt 
        ///WHERE t.id=dt.Tag_id_fk 
        ///and dt.Dish_id_fk = @id order by t.Name;.
        /// </summary>
        internal static string FindTagsForDish {
            get {
                return ResourceManager.GetString("FindTagsForDish", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO app.dish
        ///(Id, Name, Description, Recipe, Difficulty, Duration, Author, TimeAdded) 
        ///VALUES (@Id, @Name, @Description, @Recipe, @Difficulty, @Duration, @Author, @TimeAdded).
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
        ///   Looks up a localized string similar to INSERT INTO app.dish_tag
        ///(Id, Dish_id_fk, Tag_id_fk) 
        ///VALUES (@Id, @Dish_id_fk, @Tag_id_fk).
        /// </summary>
        internal static string InsertDishTag {
            get {
                return ResourceManager.GetString("InsertDishTag", resourceCulture);
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
        ///   Looks up a localized string similar to INSERT INTO app.tag
        ///(Id, Name) 
        ///VALUES (@Id, @Name).
        /// </summary>
        internal static string InsertTag {
            get {
                return ResourceManager.GetString("InsertTag", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select 
        ///	d.Id, 
        ///	d.Name, 
        ///    d.Description, 
        ///    d.Difficulty, 
        ///    d.Duration, 
        ///    d.Author, 
        ///    d.TimeAdded 
        ///from 
        ///	app.dish d
        ///where exists 
        ///	(
        ///		select 
        ///			1 
        ///		from 
        ///			app.dish_tag dt 
        ///		inner join app.tag t
        ///			on dt.Tag_id_fk = t.id 
        ///		where 
        ///			dt.Dish_id_fk = d.Id AND
        ///            t.Name like @Parameter
        ///    ) or d.Name like @Parameter or 
        ///	d.Author like @Parameter ORDER by d.Name 
        ///	limit @Limit offset @Offset
        ///
        ///
        ///	.
        /// </summary>
        internal static string SearchInDishesAndTags {
            get {
                return ResourceManager.GetString("SearchInDishesAndTags", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE app.dish SET
        ///Name = @Name , Description = @Description, Recipe = @Recipe, Difficulty = @Difficulty, Duration  = @Duration, Author = @Author
        ///WHERE Id=@Id.
        /// </summary>
        internal static string UpdateDish {
            get {
                return ResourceManager.GetString("UpdateDish", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE app.ingredient SET
        ///Name = @Name, Description = @Description WHERE Id=@Id
        ///.
        /// </summary>
        internal static string UpdateIngredient {
            get {
                return ResourceManager.GetString("UpdateIngredient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE app.tag set
        ///Name = @Name WHERE
        ///Id = @Id.
        /// </summary>
        internal static string UpdateTag {
            get {
                return ResourceManager.GetString("UpdateTag", resourceCulture);
            }
        }
    }
}
