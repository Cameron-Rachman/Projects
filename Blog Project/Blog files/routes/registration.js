const express = require('express');
const router = express.Router();
const User = require("../model/User").User;
const { checkUser } = require('../middleware/checkUser');

router.get('/', (req, res) => {
    res.render('../views/pages/registration', {pageTitle:'Registration', errorMessage: null});
});

router.post('/', checkUser, async (req, res) => {
    try {
      const user = {
        username:req.body.username,
        password: req.body.password,
      }
      User.create(user);
      res.redirect('/login');
    } catch {
        res.redirect('/registration');
    }
});

module.exports = router;