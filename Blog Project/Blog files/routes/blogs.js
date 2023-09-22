const express = require('express');
const router = express.Router();
const Blog = require('../model/Blog').Blog;
const LoginManager = require("../loginManager").LoginManager;

router.get('/', (req, res) => {
    console.log('Request for blogs in table');
    let blog = Blog.all(rows => {
      res.render('../views/pages/blogs', {isLoggedIn: LoginManager.getLoginStatus(), blogs : rows, pageTitle: "Blogs" });
    })
});

module.exports = router;

