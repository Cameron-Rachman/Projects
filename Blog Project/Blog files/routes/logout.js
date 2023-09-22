const express = require('express');
const router = express.Router();
const LoginManager = require("../loginManager").LoginManager;

router.get('/', (req, res) => {
    LoginManager.logout();
    LoginManager.setUsername(null);
    LoginManager.setUserID(null);
    res.redirect('/');
});

module.exports = router;