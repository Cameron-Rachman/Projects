const express = require('express');
const router = express.Router();
const Blog = require('../model/Blog').Blog;
const LoginManager = require("../loginManager").LoginManager;

router.get('/', (req, res) => {
    res.render('../views/pages/create', {isLoggedIn: LoginManager.getLoginStatus(), pageTitle: "Create", errorMessage: null });
});

router.post('/', async (req, res) => {
    try {
        const blogs = {  
            creator: LoginManager.getUserID(),
            createDate: req.body.createDate, 
            title: req.body.title, 
            searchTerm: req.body.searchTerm, 
            content: req.body.content,
        }
        Blog.create(blogs);
        res.redirect('/blogs');
    } catch {
        res.redirect('/create');
    }
});

module.exports = router;
