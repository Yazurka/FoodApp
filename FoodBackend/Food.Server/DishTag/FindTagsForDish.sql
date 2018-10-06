SELECT t.Id, t.Name 
FROM tag t, dish_tag dt 
WHERE t.id=dt.Tag_id_fk 
and dt.Dish_id_fk = @id order by t.Name;