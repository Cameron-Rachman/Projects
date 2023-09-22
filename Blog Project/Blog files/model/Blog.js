//import db.js module
var db = require('./db');

class Blog {
    //fetch all blogs
    static all(callback)
    {  
        const sql = "SELECT * FROM blog";
        db.all(sql, [], (err, rows) => {
            if (err)
                return console.error(err.message);
            callback(rows);
        });
    }

    //select a specific blog according to a specific search term
    static find(searchTerm, callback)
    {   db.get('select * from blog where searchTerm = ? and ((content like '%' || ? || '%') or (title like '%' || ? || '%'))', searchTerm, callback);
    }

    //populate blog data into table
    static create(data, callback)
    {   let sql = "insert into blog(creator, createDate, title, searchTerm, content) values (?, ?, ?, ?, ?)";
        db.run(sql, data.creator, data.createDate, data.title, data.searchTerm, data.content, callback);
    }

    //To remove a blog
    static delete(title, callback)
    {  if (!title)
        return callback(new Error('Please provide a title'));
        db.run('delete from blog where title = ?', title, callback);
    }
}

module.exports = db;
module.exports.Blog = Blog;