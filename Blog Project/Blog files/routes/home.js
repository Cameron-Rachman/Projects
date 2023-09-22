const express = require('express');
const router = express.Router();
const LoginManager = require("../loginManager").LoginManager;

router.get('/', (req, res) => {
  console.log(LoginManager.getUserID());
  res.render('../views/pages/home', {isLoggedIn: LoginManager.getLoginStatus(), user: LoginManager.getUsername(), pageTitle: "Home" });
});

module.exports = router;

