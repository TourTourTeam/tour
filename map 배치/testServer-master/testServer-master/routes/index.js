var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
  console.log(req.body);
  res.send({"name":"hhm", "map": "hello"})
});

router.post('/', function(req,res,next){
    console.log(req.body);
    res.render('index', { title: 'Express' });
});

module.exports = router;
