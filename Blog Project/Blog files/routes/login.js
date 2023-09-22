const express = require('express');
const router = express.Router();
const User = require("../model/User").User;
const LoginManager = require("../loginManager").LoginManager;


router.get('/', (req, res) => {
    res.render('../views/pages/login', {errorMessage: null, pageTitle:'Login'});
});

router.post('/',  (req, res) => {
    User.all(async rows =>{
        let user = rows.find(user => user.username === req.body.username);
        if(user == null){
            res.status(404);
            res.render('../views/pages/login', {errorMessage: "User doesn't exist", pageTitle:"Login"});
        } else {
            try {
                if (req.body.password == user.password) {
                    LoginManager.setUsername(req.body.username);
                    LoginManager.setUserID(user.userid);
                    LoginManager.login();
                    res.redirect('/');
                    console.log("Logged in");
                } else {
                    console.log("Password Incorrect");
                    res.status(401);
                    res.render('../views/pages/login', {errorMessage: "Password Incorrect", pageTitle:'Login'});
                }
            } catch {
                res.status(500);
                console.log("Something went wrong")
                res.redirect('/login');
            }
        }
    });
});

module.exports = router;