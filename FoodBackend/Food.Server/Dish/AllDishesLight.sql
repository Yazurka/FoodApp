SELECT 
		d.Id, d.Name, 
		d.Description, 
		d.Difficulty, 
		d.Duration,
		d.Author, 
		d.TimeAdded 
FROM
		dish d 
ORDER BY 
		d.Name 
OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY;