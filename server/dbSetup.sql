CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) COMMENT 'User Name',
  email VARCHAR(255) UNIQUE COMMENT 'User Email',
  picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE Table recipes(
  id INT NOT Null PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP ,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP ,
  title TEXT NOT NULL,
  instructions TEXT,
  img TEXT Not NULL,
  category ENUM('brecfast', 'lunch', 'dinner', 'snack', 'dessert'),
  creator_id VARCHAR(255) NOT NULL,
  Foreign Key (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
)

select * FROM recipes

DROP Table recipes

select recipes.*, accounts.* FROM recipes INNER JOIN accounts ON accounts.id = recipes.creator_id

SELECT recipes.*, accounts.* FROM recipes INNER JOIN accounts.id = recipes.creator_id WHERE recipes.id 

UPDATE recipes SET title = @Title, instructions = @Instruvtions, img = @Img WHERE id = @Id LIMIT 1;

DELETE FROM recipes WHERE id = @recipesId LIMIT 1