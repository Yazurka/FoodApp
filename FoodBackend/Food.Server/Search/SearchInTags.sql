select d.Id, d.Name, d.Description, d.Difficulty, d.Duration, d.Author, d.TimeAdded from app.dish d
inner join app.dish_tag dt
on d.Id = dt.Dish_id_fk
inner join app.tag t
on dt.Tag_id_fk = t.id where t.Name like @Parameter;