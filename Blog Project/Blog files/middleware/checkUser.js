const User = require("../model/User").User;
const LoginManager = require("../loginManager").LoginManager;

let checkUser = (req, res, next) => {
    User.all(rows =>{
        let user = rows.find(user => user.username === req.body.username);
        if(user != null){
            console.log("exist");
            res.render('../views/pages/registration', {errorMessage: "Username Taken", pageTitle:'Registration'});
        } else {
            next();
        }
    });

}

module.exports = {
    checkUser
}