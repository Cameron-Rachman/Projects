//import db.js module
var db = require('./db');

class User {
    //fetch all registered users
    static all(callback)
    {  
        const sql = "SELECT * FROM user";
        db.all(sql, [], (err, rows) => {
            if (err)
                return console.error(err.message);
            callback(rows);
        });
    }

    //select a specific user
    static find(name, callback)
    {   
        db.get('select * from user where username = ?', name, (err, row) => {
            if (err)
                return console.error(err.message);
            callback(row);
        });
    }

    //populate user data into table
    static create(data, callback)
    {   let sql = "insert into user(username, password) values (?, ?)";
        db.run(sql, data.username, data.password, callback);
    }

    //To remove an user
    static delete(name, callback)
    {  if (!name)
        return callback(new Error('Please provide an user name'));
        db.run('delete from user where name = ?', name, callback);
    }
}

module.exports = db;
module.exports.User = User;