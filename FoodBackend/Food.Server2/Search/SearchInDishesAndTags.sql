select 
	d.Id, 
	d.Name, 
    d.Description, 
    d.Difficulty, 
    d.Duration, 
    d.Author, 
    d.TimeAdded 
from 
	app.dish d
where exists 
	(
		select 
			1 
		from 
			app.dish_tag dt 
		inner join app.tag t
			on dt.Tag_id_fk = t.id 
		where 
			dt.Dish_id_fk = d.Id AND
            t.Name like @Parameter
    ) or d.Name like @Parameter or 
	d.Author like @Parameter ORDER by d.Name 
	limit @Limit offset @Offset


	