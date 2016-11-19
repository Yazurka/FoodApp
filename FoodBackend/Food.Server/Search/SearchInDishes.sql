select d.Id, d.Name, d.Description, d.Difficulty, d.Duration, d.Author, d.TimeAdded from app.dish d
where d.Name like @Parameter or d.Author like @Parameter;