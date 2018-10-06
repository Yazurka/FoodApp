SELECT i.Id, i.Name, i.Description, di.Amount, di.Unit, di.Comment FROM
 dish_ingredient di, ingredient i 
 WHERE di.Ingredient_id_fk = i.Id AND
di.Dish_id_fk = @Id order by i.Name;
