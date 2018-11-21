var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var User = require('../database/user_schema');

router.get('/',function(req,res,next){
    User.find({})
    .sort({id:1})
    .exec(function(err,user){
        if(err){
            res.status(500);
            res.json({success:false, err:err});
        }
        else{
            res.json({success:true, data:user})
        }
    });
 });
 
 router.post('/',function(req,res,next){
     User.findOne({})
     .sort({id:-1})
     .exec(function(err,user){
         if(err){
             res.status(500);
             res.json({sucess:false,err:err});
         }
         else{
             res.locals.lastId = user?user.id:0;
             next();
         }
     });
 },
 function(req,res,next){
     var newUser = new User(req.body);
     newUser.id=res.locals.lastId+1;
     newUser.save(function(err,hero){
         if(err){
             res.status(500);
             res.json({success:false, message:err});
         }
         else{
             res.json({success:true, data:user});
         }
     })
 });
 
 router.get('/:id',function(req,res,next){
     User.findOne({id:req.params.id})
     .exec(function(err,user){
         if(err){
             res.status(500);
             res.json({sucess:false, err:err});
         }
         else if(!user){
             res.json({success:false, err:"user not found"});
         }
         else{
             res.json({success:true, data:user});
         }
     });
 });
 
 router.put('/:id',function(req,res,next){
     User.findOneAndUpdate({id:req.params.id}, req.body)
     .exec(function(err,user){
         if(err){
             res.status(500);
             res.json({sucess:false, err:err});
         }
         else if(!user){
             res.json({success:false, err:"user not found"});
         }
         else{
             res.json({success:true});
         }
     });
 });

 module.exports = router;