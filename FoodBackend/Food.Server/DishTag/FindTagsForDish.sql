SELECT t.Id, t.Name 
FROM app.tag t, app.dish_tag dt 
WHERE t.id=dt.Tag_id_fk 
and dt.Dish_id_fk = @id;