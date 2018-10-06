select d.Id, d.Name, d.Description, d.Difficulty, d.Duration, d.Author, d.TimeAdded 
from dish d order by d.Name limit @Limit offset @Offset 
