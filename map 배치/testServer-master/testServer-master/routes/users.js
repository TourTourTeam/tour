var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});


router.post('/new', function(req,res,next){
  console.log(req.body);
    res.send({"success" : "true", "map" : "1"});
});

router.post('/login', function(req, res, next){
  console.log(req.body);
  res.send({"success" : "true", "map" : "1"});
});


module.exports = router;
