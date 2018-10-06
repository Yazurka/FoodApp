SELECT i.Id, i.Name, i.Description, di.Amount, di.Unit, di.Comment FROM
 app.dish_ingredient di, app.ingredient i 
 WHERE di.Ingredient_id_fk = i.Id AND
di.Dish_id_fk = @Id order by i.Name;
