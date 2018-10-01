var express = require('express');
var bodyParser = require('body-parser');
var app = express();
app.use(bodyParser.urlencoded({ extended: true }));

app.listen(3000);

app.post('/form_receiver', function(req, res){
  var description = req.body.description;//req에 내용이 담겨서 옴. req body 부분에 보통 내용을 담을거임. description 부분은 내가 이름 마음대로 준 것임. 변수 명이라고 보면 됨.
  console.log('post receive: ', description);
  res.send('post sender:'+description);
});
