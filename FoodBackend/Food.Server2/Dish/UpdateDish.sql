UPDATE app.dish SET
Name = @Name , Description = @Description, Recipe = @Recipe, Difficulty = @Difficulty, Duration  = @Duration, Author = @Author
WHERE Id=@Id